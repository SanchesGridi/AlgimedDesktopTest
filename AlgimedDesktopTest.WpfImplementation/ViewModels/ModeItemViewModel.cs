using AlgimedDesktopTest.WpfImplementation.Events;
using AlgimedDesktopTest.WpfImplementation.Models;
using AlgimedDesktopTest.WpfImplementation.Utils;
using AlgimedDesktopTest.WpfImplementation.ViewModels.Base;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Text.RegularExpressions;

namespace AlgimedDesktopTest.WpfImplementation.ViewModels;

public class ModeItemViewModel : ViewModelBase, INavigationAware
{
    private const string Save = "Save";
    private const string Update = "Update";

    private readonly Regex _regex;

    private bool _checkMaxBottleNumber;
    private bool _checkMaxUsedTips;
    private string? _dbMode;

    private string? _dbModeUiText;
    public string? DbModeUiText
    {
        get => _dbModeUiText;
        set => SetProperty(ref _dbModeUiText, value);
    }

    private ModeModel? _item;
    public ModeModel? Item
    {
        get => _item;
        set => SetProperty(ref _item, value);
    }

    public DelegateCommand<string> MaxBottleNumberCommand { get; }
    public DelegateCommand<string> MaxUsedTipsCommand { get; }
    public DelegateCommand SaveCommand { get; }
    public DelegateCommand GoBackCommand { get; }

    public ModeItemViewModel(
        IRegionManager regionManager,
        IEventAggregator eventAggregator,
        IDialogService dialogService) : base(regionManager, eventAggregator, dialogService)
    {
        _regex = new("^[0-9]+$");

        MaxBottleNumberCommand = new(MaxBottleNumberCommandExecute);
        MaxUsedTipsCommand = new(MaxUsedTipsCommandExecute);
        SaveCommand = new(SaveCommandExecute);
        GoBackCommand = new(GoBackCommandExecute);
    }

    public void OnNavigatedTo(NavigationContext navigationContext)
    {
        _dbMode = navigationContext.Parameters.GetValue<string>(Consts.Keys.DbModeKey);
        switch (_dbMode)
        {
            case Consts.Keys.AddKey:
                DbModeUiText = Save;
                break;
            case Consts.Keys.EditKey:
                DbModeUiText = Update;
                break;
        }
        Item = navigationContext.Parameters.GetValue<ModeModel>(Consts.Keys.ItemKey);
    }

    public void OnNavigatedFrom(NavigationContext navigationContext)
    {
    }

    public bool IsNavigationTarget(NavigationContext navigationContext) => true;

    private void MaxBottleNumberCommandExecute(string text) =>
        _checkMaxBottleNumber = _regex.IsMatch(text);

    private void MaxUsedTipsCommandExecute(string text) =>
        _checkMaxUsedTips = _regex.IsMatch(text);

    private void SaveCommandExecute()
    {
        try
        {
            if (_checkMaxBottleNumber && _checkMaxUsedTips)
            {
                _eventAggregator.GetEvent<ModeEvent>().Publish((Item!, _dbMode!));
                NavigateToListView();
            }
            else
            {
                throw new InvalidOperationException("Not correct number value!");
            }
        }
        catch (Exception ex)
        {
            ShowExceptionDialog(ex);
        }
    }

    private void GoBackCommandExecute()
    {
        try
        {
            NavigateToListView();
        }
        catch (Exception ex)
        {
            ShowExceptionDialog(ex);
        }
    }

    private void NavigateToListView()
    {
        _navigation.RegionName = RegionNames.ContentRegion;
        _navigation.ViewName = Consts.ViewNames.ListView;
        Navigate();
    }
}
