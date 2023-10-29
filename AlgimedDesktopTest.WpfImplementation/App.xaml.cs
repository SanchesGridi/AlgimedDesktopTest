using AlgimedDesktopTest.Database.Contexts;
using AlgimedDesktopTest.Database.Factories;
using AlgimedDesktopTest.Shared.Devices.Classes;
using AlgimedDesktopTest.Shared.Devices.Interfaces;
using AlgimedDesktopTest.Shared.Excel.Classes;
using AlgimedDesktopTest.Shared.Excel.Interfaces;
using AlgimedDesktopTest.Shared.Services.Classes;
using AlgimedDesktopTest.Shared.Services.Interfaces;
using AlgimedDesktopTest.WpfImplementation.Extensions;
using AlgimedDesktopTest.WpfImplementation.Services.Classes;
using AlgimedDesktopTest.WpfImplementation.Services.Interfaces;
using AlgimedDesktopTest.WpfImplementation.Utils;
using AlgimedDesktopTest.WpfImplementation.ViewModels;
using AlgimedDesktopTest.WpfImplementation.Views;
using Prism.Ioc;
using Prism.Regions;
using System.Windows;

namespace AlgimedDesktopTest.WpfImplementation
{
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry
                .RegisterSingleton<IFileService, FileService>()
                .RegisterSingleton<IExcelService, ExcelService>()
                .RegisterSingleton<IDeviceService, DeviceService>()
                .RegisterSingleton<IPasswordService, PasswordService>()
                .RegisterSingleton<IPasswordBoxService, PasswordBoxService>()
                .Register<AppDbContext>(() => ContextFactory.Create())
                .RegisterAutoMapperInstance();

            containerRegistry.RegisterDialog<DetailsDialog, DetailsDialogViewModel>(Consts.Dialogs.DetailsDialog);
            containerRegistry.RegisterDialog<WarningDialog, WarningDialogViewModel>(Consts.Dialogs.WarningDialog);

            containerRegistry.RegisterForNavigation<MainWindow, MainWindowViewModel>();
            containerRegistry.RegisterForNavigation<RegistrationPage, RegistrationPageViewModel>();
            containerRegistry.RegisterForNavigation<AuthorizationPage, AuthorizationPageViewModel>();
            containerRegistry.RegisterForNavigation<ItemsPage, ItemsPageViewModel>();
            containerRegistry.RegisterForNavigation<ListView, ListViewModel>();
            containerRegistry.RegisterForNavigation<ModeItemView, ModeItemViewModel>();
            containerRegistry.RegisterForNavigation<StepItemView, StepItemViewModel>();

            Container.Resolve<IRegionManager>()
                .RegisterViewWithRegion(RegionNames.PageRegion, nameof(RegistrationPage))
                .RegisterViewWithRegion(RegionNames.PageRegion, nameof(AuthorizationPage))
                .RegisterViewWithRegion(RegionNames.PageRegion, nameof(ItemsPage))
                .RegisterViewWithRegion(RegionNames.ContentRegion, nameof(ListView))
                .RegisterViewWithRegion(RegionNames.ContentRegion, nameof(ModeItemView))
                .RegisterViewWithRegion(RegionNames.ContentRegion, nameof(StepItemView));
        }
    }
}
