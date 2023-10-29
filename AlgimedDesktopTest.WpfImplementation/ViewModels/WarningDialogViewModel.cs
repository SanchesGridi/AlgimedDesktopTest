using AlgimedDesktopTest.WpfImplementation.Models;
using AlgimedDesktopTest.WpfImplementation.Utils;
using AlgimedDesktopTest.WpfImplementation.ViewModels.Base;
using Prism.Commands;
using Prism.Services.Dialogs;
using System.Collections.ObjectModel;

namespace AlgimedDesktopTest.WpfImplementation.ViewModels;

public class WarningDialogViewModel : DialogViewModelBase
{
    private ObservableCollection<StepModel>? _steps;
    public ObservableCollection<StepModel>? Steps
    {
        get => _steps;
        set => SetProperty(ref _steps, value);
    }

    public DelegateCommand OkCommand { get; }

    public WarningDialogViewModel()
    {
        OkCommand = new(OkCommandExecute);
    }

    public override void OnDialogOpened(IDialogParameters parameters)
    {
        base.OnDialogOpened(parameters);

        Steps = parameters.GetValue<ObservableCollection<StepModel>>(Consts.Keys.StepsKey);
    }

    private void OkCommandExecute() =>
        OnRequestClose(new DialogResult(ButtonResult.OK));
}
