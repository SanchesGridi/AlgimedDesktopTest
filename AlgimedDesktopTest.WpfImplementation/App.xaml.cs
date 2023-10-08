using AlgimedDesktopTest.WpfImplementation.Enums;
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
            containerRegistry.RegisterSingleton<IStartPageOptionService, StartPageOptionService>();

            containerRegistry.RegisterForNavigation<RegistrationPage, RegistrationPageViewModel>();
            containerRegistry.RegisterForNavigation<AuthorizationPage, AuthorizationPageViewModel>();
            containerRegistry.RegisterForNavigation<ItemsPage, ItemsPageViewModel>();
            containerRegistry.RegisterForNavigation<MainWindow, MainWindowViewModel>();
            containerRegistry.RegisterForNavigation<ModeItemView, ModeItemViewModel>();
            containerRegistry.RegisterForNavigation<StepItemView, StepItemViewModel>();

            var regionManager = Container.Resolve<IRegionManager>();

            regionManager.RegisterViewWithRegion(RegionNames.PageRegion, nameof(RegistrationPage));
            regionManager.RegisterViewWithRegion(RegionNames.PageRegion, nameof(AuthorizationPage));
            regionManager.RegisterViewWithRegion(RegionNames.PageRegion, nameof(ItemsPage));
            regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, nameof(ModeItemView));
            regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, nameof(StepItemView));
        }

        protected override void OnInitialized()
        {
            // todo:
            // registration
            // authorization
            // store value
            var option = StartPageOption.Items;
            var service = Container.Resolve<IStartPageOptionService>();
            service.Set(option);

            base.OnInitialized();
        }
    }
}
