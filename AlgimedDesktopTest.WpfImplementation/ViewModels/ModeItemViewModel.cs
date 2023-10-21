using AlgimedDesktopTest.WpfImplementation.Models;
using AlgimedDesktopTest.WpfImplementation.ViewModels.Base;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;

namespace AlgimedDesktopTest.WpfImplementation.ViewModels;

public class ModeItemViewModel : ListItemViewModel<ModeModel>
{
    private const string Pattern = "^[0-9]+$";

    private bool _checkMaxBottleNumber;
    private bool _checkMaxUsedTips;

    public DelegateCommand<string> MaxBottleNumberCommand { get; }
    public DelegateCommand<string> MaxUsedTipsCommand { get; }

    public ModeItemViewModel(
        IRegionManager regionManager,
        IEventAggregator eventAggregator,
        IDialogService dialogService) : base(regionManager, eventAggregator, dialogService)
    {
        MaxBottleNumberCommand = new(MaxBottleNumberCommandExecute);
        MaxUsedTipsCommand = new(MaxUsedTipsCommandExecute);
    }

    public override void OnNavigatedTo(NavigationContext navigationContext)
    {
        base.OnNavigatedTo(navigationContext);

        // we not change any number text box here so we should allow save default value
        _checkMaxBottleNumber = true;
        _checkMaxUsedTips = true;
    }

    protected override bool CheckSaveCondition()
    {
        return _checkMaxBottleNumber && _checkMaxUsedTips;
    }

    protected override string GetRegexPattern() => Pattern;

    private void MaxBottleNumberCommandExecute(string text)
    {
        CheckIntegerText(text, ref _checkMaxBottleNumber);
    }

    private void MaxUsedTipsCommandExecute(string text)
    {
        CheckIntegerText(text, ref _checkMaxUsedTips);
    }

    private void CheckIntegerText(string text, ref bool check)
    {
        try
        {
            check = _regex.IsMatch(
                int.Parse(text).ToString()
            );
        }
        catch (Exception ex)
        {
            ShowExceptionDialog(ex);
            check = false;
        }
    }
}
