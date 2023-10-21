using AlgimedDesktopTest.WpfImplementation.Models;
using AlgimedDesktopTest.WpfImplementation.ViewModels.Base;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Globalization;

namespace AlgimedDesktopTest.WpfImplementation.ViewModels;

public class StepItemViewModel : ListItemViewModel<StepModel>
{
    private const string Separator = ".";
    private const string Pattern = @"^[0-9]+\.[0-9]+$";

    private readonly NumberFormatInfo _formatProvider;

    private bool _checkTimer;
    private bool _checkSpeed;
    private bool _checkVolume;

    public DelegateCommand<string> TimerCommand { get; set; }
    public DelegateCommand<string> SpeedCommand { get; set; }
    public DelegateCommand<string> VolumeCommand { get; set; }

    public StepItemViewModel(
        IRegionManager regionManager,
        IEventAggregator eventAggregator,
        IDialogService dialogService) : base(regionManager, eventAggregator, dialogService)
    {
        _formatProvider = new() { NumberDecimalSeparator = Separator };

        TimerCommand = new(TimerCommandExecute);
        SpeedCommand = new(SpeedCommandExecute);
        VolumeCommand = new(VolumeCommandExecute);
    }

    public override void OnNavigatedTo(NavigationContext navigationContext)
    {
        base.OnNavigatedTo(navigationContext);

        // we not change any number text box here so we should allow save default value
        _checkTimer = true;
        _checkSpeed = true;
        _checkVolume = true;
    }

    protected override bool CheckSaveCondition()
    {
        return _checkTimer && _checkSpeed && _checkVolume;
    }

    protected override string GetRegexPattern() => Pattern;

    private void TimerCommandExecute(string text)
    {
        CheckDoubleText(text, ref _checkTimer);
    }

    private void SpeedCommandExecute(string text)
    {
        CheckDoubleText(text, ref _checkSpeed);
    }

    private void VolumeCommandExecute(string text)
    {
        CheckDoubleText(text, ref _checkVolume);
    }

    private void CheckDoubleText(string text, ref bool check)
    {
        try
        {
            check = _regex.IsMatch(
                double.Parse(text, _formatProvider).ToString(_formatProvider)
            );
        }
        catch (Exception ex)
        {
            ShowExceptionDialog(ex);
            check = false;
        }
    }
}
