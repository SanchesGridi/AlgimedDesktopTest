using AlgimedDesktopTest.Database.Contexts;
using AlgimedDesktopTest.Database.Entities;
using AlgimedDesktopTest.WpfImplementation.Events;
using AlgimedDesktopTest.WpfImplementation.Extensions;
using AlgimedDesktopTest.WpfImplementation.Models;
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
    public DelegateCommand RemoveModeCommand { get; }
    public DelegateCommand<string> NavigateToModeCommand { get; set; }

    public ListViewModel(
        IRegionManager regionManager,
        IEventAggregator eventAggregator,
        IDialogService dialogService,
        IMapper mapper) : base(regionManager, eventAggregator, dialogService)
    {
        _mapper = mapper;

        ListViewLoadedCommand = new(ListViewLoadedCommandExecute);
        RemoveModeCommand = new(RemoveModeCommandExecute);
        NavigateToModeCommand = new(NavigateToModeCommandExecute);

        _eventAggregator.GetEvent<ModeEvent>().Subscribe(ModeSubscribeAction);
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

    private async void RemoveModeCommandExecute()
    {
        try
        {
            if (SelectedMode != null)
            {
                using var context = _application.GetContainer().Resolve<AppDbContext>();
                var mode = await context.Modes.FirstOrDefaultAsync(x => x.Id == SelectedMode.GetId());
                if (mode != null)
                {
                    context.Modes.Remove(mode);
                    if (await OneRowAffectedAsync(context))
                    {
                        _application.Dispatcher.Invoke(() => Modes!.Remove(SelectedMode));
                    }
                }
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
            var item = null as ModeModel;
            if (parameter == Consts.Keys.EditKey)
            {
                if (SelectedMode == null)
                {
                    throw new InvalidOperationException("Please select an item!");
                }
                item = new ModeModel(SelectedMode.GetId())
                {
                    Name = SelectedMode.Name,
                    MaxBottleNumber = SelectedMode.MaxBottleNumber,
                    MaxUsedTips = SelectedMode.MaxUsedTips
                };
            }
            else
            {
                const int newItemId = 0;
                item = new ModeModel(newItemId);
            }

            _navigation.RegionName = RegionNames.ContentRegion;
            _navigation.ViewName = Consts.ViewNames.ModeItemView;

            Navigate(new NavigationParameters
            {
                { Consts.Keys.DbModeKey, parameter },
                { Consts.Keys.ItemKey, item }
            });
        }
        catch (Exception ex)
        {
            ShowExceptionDialog(ex);
        }
    }

    private async void ModeSubscribeAction((ModeModel Item, string DbMode) tuple)
    {
        try
        {
            using var context = _application.GetContainer().Resolve<AppDbContext>();
            if (tuple.DbMode == Consts.Keys.AddKey)
            {
                var insertable = (await context.Modes.AddAsync(_mapper.Map<ModeEntity>(tuple.Item))).Entity;
                if (await OneRowAffectedAsync(context))
                {
                    _application.Dispatcher.Invoke(() => Modes!.Add(_mapper.Map<ModeModel>(insertable)));
                }
            }
            else
            {
                var updateble = _mapper.Map<ModeEntity>(tuple.Item);
                context.Modes.Update(updateble);
                if (await OneRowAffectedAsync(context))
                {
                    _application.Dispatcher.Invoke(() =>
                    {
                        var mode = Modes!.FirstOrDefault(x => x.GetId() == tuple.Item.GetId());
                        if (mode != null)
                        {
                            var index = Modes!.IndexOf(mode);
                            Modes.Insert(index, tuple.Item);
                            Modes!.RemoveAt(index + 1);
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

    private static async Task<bool> OneRowAffectedAsync(AppDbContext context) =>
        await context.SaveChangesAsync() == 1;
}
