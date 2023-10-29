using AlgimedDesktopTest.WpfImplementation.Utils;
using AlgimedDesktopTest.WpfImplementation.ViewModels.Base;
using Prism.Services.Dialogs;

namespace AlgimedDesktopTest.WpfImplementation.ViewModels;

public class DetailsDialogViewModel : DialogViewModelBase
{
    private string? _details;
    public string? Details
    {
        get => _details;
        set => SetProperty(ref _details, value);
    }

    public override void OnDialogOpened(IDialogParameters parameters)
    {
        base.OnDialogOpened(parameters);

        Details = parameters.GetValue<string?>(Consts.Keys.DetailsKey);
    }
}
