using AlgimedDesktopTest.Database.Contexts;
using AlgimedDesktopTest.Database.Entities;
using AlgimedDesktopTest.Database.Entities.Base;
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
    private const string ExceptionMessage = "Please select an item!";
    private const int NewItemId = 0;

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

    public ListViewModel(
        IRegionManager regionManager,
        IEventAggregator eventAggregator,
        IDialogService dialogService,
        IMapper mapper) : base(regionManager, eventAggregator, dialogService)
    {
        _mapper = mapper;

        ListViewLoadedCommand = new(ListViewLoadedCommandExecute);
        NavigateToModeCommand = new(NavigateToModeCommandExecute);
        RemoveModeCommand = new(RemoveModeCommandExecute);
        NavigateToStepCommand = new(NavigateToStepCommandExecute);
        RemoveStepCommand = new(RemoveStepCommandExecute);

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
            static ModeModel InternalMapper(ModeModel selected) => new(selected.GetId())
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
            static StepModel InternalMapper(StepModel selected) => new(selected.GetId())
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
                { Consts.Keys.IdsKey, Modes!.Select(x => x.GetId()).OrderBy(x => x).ToArray() }
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
                        var item = store.FirstOrDefault(x => x.GetId() == tuple.Item.GetId());
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
            var entity = await context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == selectedEntry.GetId());
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

    private static async Task<bool> OneRowAffectedAsync(AppDbContext context) =>
        await context.SaveChangesAsync() == 1;
}
