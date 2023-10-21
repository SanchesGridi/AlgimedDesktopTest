using AlgimedDesktopTest.WpfImplementation.Events;
using AlgimedDesktopTest.WpfImplementation.Models.Base;
using AlgimedDesktopTest.WpfImplementation.Utils;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Text.RegularExpressions;

namespace AlgimedDesktopTest.WpfImplementation.ViewModels.Base;

public abstract class ListItemViewModel<TItem> : ViewModelBase, INavigationAware where TItem : DbEntryModel
{
    private const string Save = nameof(Save);
    private const string Update = nameof(Update);
    private const string ExceptionMessage = "Not correct number value!";

    protected readonly Regex _regex;

    protected string? _dbMode;

    private string? _dbModeUiText;
    public string? DbModeUiText
    {
        get => _dbModeUiText;
        set => SetProperty(ref _dbModeUiText, value);
    }

    private TItem? _item;
    public TItem? Item
    {
        get => _item;
        set => SetProperty(ref _item, value);
    }

    public DelegateCommand GoBackCommand { get; }
    public DelegateCommand SaveCommand { get; }

    public ListItemViewModel(
        IRegionManager regionManager,
        IEventAggregator eventAggregator,
        IDialogService dialogService) : base(regionManager, eventAggregator, dialogService)
    {
        _regex = new(GetRegexPattern());

        GoBackCommand = new(GoBackCommandExecute);
        SaveCommand = new(SaveCommandExecute);
    }

    public virtual void OnNavigatedTo(NavigationContext navigationContext)
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

        Item = navigationContext.Parameters.GetValue<TItem>(Consts.Keys.ItemKey);
    }

    public virtual void OnNavigatedFrom(NavigationContext navigationContext)
    {
    }

    public bool IsNavigationTarget(NavigationContext navigationContext) => true;

    protected void NavigateToListView()
    {
        _navigation.RegionName = RegionNames.ContentRegion;
        _navigation.ViewName = Consts.ViewNames.ListView;
        Navigate();
    }

    protected abstract bool CheckSaveCondition();

    protected abstract string GetRegexPattern();

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

    private void SaveCommandExecute()
    {
        try
        {
            if (CheckSaveCondition())
            {
                _eventAggregator.GetEvent<ItemEvent<TItem>>().Publish((Item!, _dbMode!));
                NavigateToListView();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessage);
            }
        }
        catch (Exception ex)
        {
            ShowExceptionDialog(ex);
        }
    }
}
