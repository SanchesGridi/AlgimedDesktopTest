using AlgimedDesktopTest.Database.Contexts;
using AlgimedDesktopTest.Database.Entities;
using AlgimedDesktopTest.Database.Entities.Base;
using AlgimedDesktopTest.Database.Utils;
using AlgimedDesktopTest.Shared.Excel.Interfaces;
using AlgimedDesktopTest.Shared.Services.Interfaces;
using AlgimedDesktopTest.WpfImplementation.Events;
using AlgimedDesktopTest.WpfImplementation.Extensions;
using AlgimedDesktopTest.WpfImplementation.Models;
using AlgimedDesktopTest.WpfImplementation.Models.Base;
using AlgimedDesktopTest.WpfImplementation.Utils;
using AlgimedDesktopTest.WpfImplementation.ViewModels.Base;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace AlgimedDesktopTest.WpfImplementation.ViewModels;

public class ListViewModel : ViewModelBase
{
    private const string WarningDialogTitle = "Warning";
    private const string DetailsDialogTitle = "Steps are skipped!";
    private const string Details = "All modes was saved successfully, but steps are skipped!";
    private const string ExceptionMessage = "Please select an item!";
    private const int NewItemId = 0;

    private readonly IFileService _fileService;
    private readonly IExcelService _excelService;
    private readonly IMapper _mapper;

    private bool _initialized;

    private ModeModel? _selectedMode;
    public ModeModel? SelectedMode
    {
        get => _selectedMode;
        set => SetProperty(ref _selectedMode, value);
    }

    private ObservableCollection<ModeModel>? _modes;
    public ObservableCollection<ModeModel>? Modes
    {
        get => _modes ??= new();
        set => SetProperty(ref _modes, value);
    }

    private StepModel? _selectedStep;
    public StepModel? SelectedStep
    {
        get => _selectedStep;
        set => SetProperty(ref _selectedStep, value);
    }

    private ObservableCollection<StepModel>? _steps;
    public ObservableCollection<StepModel>? Steps
    {
        get => _steps ??= new();
        set => SetProperty(ref _steps, value);
    }

    public DelegateCommand ListViewLoadedCommand { get; }
    public DelegateCommand<string> NavigateToModeCommand { get; set; }
    public DelegateCommand RemoveModeCommand { get; }
    public DelegateCommand<string> NavigateToStepCommand { get; }
    public DelegateCommand RemoveStepCommand { get; }
    public DelegateCommand LoadFromXlsxCommand { get; }

    public ListViewModel(
        IRegionManager regionManager,
        IEventAggregator eventAggregator,
        IDialogService dialogService,
        IFileService fileService,
        IExcelService excelService,
        IMapper mapper) : base(regionManager, eventAggregator, dialogService)
    {
        _fileService = fileService;
        _excelService = excelService;
        _mapper = mapper;

        ListViewLoadedCommand = new(ListViewLoadedCommandExecute);
        NavigateToModeCommand = new(NavigateToModeCommandExecute);
        RemoveModeCommand = new(RemoveModeCommandExecute);
        NavigateToStepCommand = new(NavigateToStepCommandExecute);
        RemoveStepCommand = new(RemoveStepCommandExecute);
        LoadFromXlsxCommand = new(LoadFromXlsxCommandExecute);

        _eventAggregator.GetEvent<ItemEvent<ModeModel>>().Subscribe(async x => await SubscribeItemAsync<ModeModel, ModeEntity>(x, Modes!));
        _eventAggregator.GetEvent<ItemEvent<StepModel>>().Subscribe(async x => await SubscribeItemAsync<StepModel, StepEntity>(x, Steps!));
    }

    private async void ListViewLoadedCommandExecute()
    {
        try
        {
            if (!_initialized)
            {
                using var context = _application.GetContainer().Resolve<AppDbContext>();
                var modes = await _mapper.ListFromContextAsync<ModeEntity, List<ModeModel>>(context);
                var steps = await _mapper.ListFromContextAsync<StepEntity, List<StepModel>>(context);
                Modes!.AddRange(modes);
                Steps!.AddRange(steps);

                _initialized = true;
            }
        }
        catch (Exception ex)
        {
            ShowExceptionDialog(ex);
        }
    }

    private void NavigateToModeCommandExecute(string parameter)
    {
        try
        {
            static ModeModel InternalMapper(ModeModel selected) => new(selected.Id)
            {
                Name = selected.Name,
                MaxBottleNumber = selected.MaxBottleNumber,
                MaxUsedTips = selected.MaxUsedTips
            };

            NavigateToView(Consts.ViewNames.ModeItemView, parameter, SelectedMode!, InternalMapper, () => new(NewItemId));
        }
        catch (Exception ex)
        {
            ShowExceptionDialog(ex);
        }
    }

    private async void RemoveModeCommandExecute()
    {
        try
        {
            await RemoveEntryAsync<ModeModel, ModeEntity>(SelectedMode!, Modes!);
        }
        catch (Exception ex)
        {
            ShowExceptionDialog(ex);
        }
    }

    private void NavigateToStepCommandExecute(string parameter)
    {
        try
        {
            static StepModel InternalMapper(StepModel selected) => new(selected.Id)
            {
                Timer = selected.Timer,
                Destination = selected.Destination,
                Speed = selected.Speed,
                Type = selected.Type,
                Volume = selected.Volume,
                ModeId = selected.ModeId
            };

            var parameters = new NavigationParameters
            {
                { Consts.Keys.IdsKey, Modes!.Select(x => x.Id).OrderBy(x => x).ToArray() }
            };
            NavigateToView(
                Consts.ViewNames.StepItemView, parameter, SelectedStep!, InternalMapper, () => new(NewItemId), parameters
            );
        }
        catch (Exception ex)
        {
            ShowExceptionDialog(ex);
        }
    }

    private async void RemoveStepCommandExecute()
    {
        try
        {
            await RemoveEntryAsync<StepModel, StepEntity>(SelectedStep!, Steps!);
        }
        catch (Exception ex)
        {
            ShowExceptionDialog(ex);
        }
    }

    private async void LoadFromXlsxCommandExecute()
    {
        try
        {
            var path = _fileService.Browse();
            if (!string.IsNullOrWhiteSpace(path))
            {
                // modes:
                using var context = _application.GetContainer().Resolve<AppDbContext>();
                var loadedModes = _excelService.LoadFromXlsx<ModeEntity>(
                    new(Db.ModeMapper, Db.RowValidator) { Path = path, SheetName = Db.Modes, HeaderNames = Db.ModeHeaders }
                );
                await Db.ContextWrapper.SaveModesAsync(context, loadedModes);
                await ReloadCollectionAsync<ModeModel, ModeEntity>(context, Modes!);

                // steps:
                var loadedSteps = _excelService.LoadFromXlsx<StepEntity>(
                    new(Db.StepMapper, Db.RowValidator) { Path = path, SheetName = Db.Steps, HeaderNames = Db.StepHeaders }
                );
                var modeIds = await context.Modes.Select(x => x.Id).ToListAsync();
                var excludedSteps = loadedSteps.Where(x => !modeIds.Contains((int)x.ModeId!)).ToList();
                var includedSteps = loadedSteps.Where(x => modeIds.Contains((int)x.ModeId!)).ToList();
                if (excludedSteps.Count > 0)
                {
                    ShowWarningDialog(_mapper.Map<ObservableCollection<StepModel>>(excludedSteps), context, includedSteps);
                }
                else
                {
                    await Db.ContextWrapper.SaveStepsAsync(context, loadedSteps);
                }
                await ReloadCollectionAsync<StepModel, StepEntity>(context, Steps!);
            }
        }
        catch (Exception ex)
        {
            ShowExceptionDialog(ex);
        }
    }

    private void ShowWarningDialog(ObservableCollection<StepModel> excludedSteps, AppDbContext context, List<StepEntity> includedSteps)
    {
        _dialogService.ShowDialog(
            Consts.Dialogs.WarningDialog,
            new DialogParameters {
                { Consts.Keys.TitleKey, WarningDialogTitle },
                { Consts.Keys.StepsKey, excludedSteps }
            },
            async x =>
            {
                if (x.Result == ButtonResult.OK)
                {
                    await Db.ContextWrapper.SaveStepsAsync(context, includedSteps);
                }
                else
                {
                    _dialogService.ShowDialog(Consts.Dialogs.DetailsDialog, new DialogParameters
                    {
                        { Consts.Keys.TitleKey, DetailsDialogTitle },
                        { Consts.Keys.DetailsKey, Details }
                    }, _ => { });
                }
            }
        );
    }

    private void NavigateToView<TItem>(string view, string parameter, TItem selectedEntry,
        Func<TItem, TItem> mapper, Func<TItem> constructor, NavigationParameters? parameters = null)
        where TItem : DbEntryModel
    {
        TItem item;
        if (parameter == Consts.Keys.EditKey)
        {
            if (selectedEntry == null)
            {
                throw new InvalidOperationException(ExceptionMessage);
            }
            item = mapper.Invoke(selectedEntry);
        }
        else
        {
            item = constructor.Invoke();
        }

        _navigation.RegionName = RegionNames.ContentRegion;
        _navigation.ViewName = view;

        parameters ??= new();
        parameters.Add(Consts.Keys.DbModeKey, parameter);
        parameters.Add(Consts.Keys.ItemKey, item);
        Navigate(parameters);
    }

    private async Task SubscribeItemAsync<TItem, TEntity>((TItem Item, string DbMode) tuple, ObservableCollection<TItem> store)
        where TItem : DbEntryModel where TEntity : class
    {
        try
        {
            using var context = _application.GetContainer().Resolve<AppDbContext>();
            if (tuple.DbMode == Consts.Keys.AddKey)
            {
                var insertable = (await context.Set<TEntity>().AddAsync(_mapper.Map<TEntity>(tuple.Item))).Entity;
                if (await OneRowAffectedAsync(context))
                {
                    _application.Dispatcher.Invoke(() => store.Add(_mapper.Map<TItem>(insertable)));
                }
            }
            else
            {
                var updateble = _mapper.Map<TEntity>(tuple.Item);
                context.Set<TEntity>().Update(updateble);
                if (await OneRowAffectedAsync(context))
                {
                    _application.Dispatcher.Invoke(() =>
                    {
                        var item = store.FirstOrDefault(x => x.Id == tuple.Item.Id);
                        if (item != null)
                        {
                            var index = store.IndexOf(item);
                            store.Insert(index, tuple.Item);
                            store.RemoveAt(index + 1);
                        }
                    });
                }
            }
        }
        catch (Exception ex)
        {
            ShowExceptionDialog(ex);
        }
    }

    private async Task RemoveEntryAsync<TItem, TEntity>(TItem selectedEntry, ObservableCollection<TItem> storage)
        where TItem : DbEntryModel
        where TEntity : class, IBaseEntity<int>
    {
        if (selectedEntry != null)
        {
            using var context = _application.GetContainer().Resolve<AppDbContext>();
            var entity = await context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == selectedEntry.Id);
            if (entity != null)
            {
                context.Set<TEntity>().Remove(entity);
                if (await OneRowAffectedAsync(context))
                {
                    _application.Dispatcher.Invoke(() => storage.Remove(selectedEntry));
                }
            }
        }
    }

    private async Task ReloadCollectionAsync<TItem, TEntity>(AppDbContext context, ObservableCollection<TItem> storage)
        where TItem : DbEntryModel
        where TEntity : class, IBaseEntity<int>
    {
        var items = await _mapper.ListFromContextAsync<TEntity, List<TItem>>(context);
        _application.Dispatcher.Invoke(() =>
        {
            storage.Clear();
            storage.AddRange(items);
        });
    }

    private static async Task<bool> OneRowAffectedAsync(AppDbContext context) =>
        await context.SaveChangesAsync() == 1;
}
