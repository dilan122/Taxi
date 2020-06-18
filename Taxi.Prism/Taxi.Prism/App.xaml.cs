using Prism;
using Prism.Ioc;
using Taxi.Prism.ViewModels;
using Xamarin.Essentials.Interfaces;
using Xamarin.Essentials.Implementation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Taxi.Prism.Views;
using Taxi.Common.Services;
using Syncfusion.Licensing;
using Taxi.Common.Helpers;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Taxi.Prism
{
    public partial class App
    {
     
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            SyncfusionLicenseProvider.RegisterLicense("MjcxMjQxQDMxMzcyZTM0MmUzMEt0bWRaNEVqWk8zR0R6dWhsak5PaGthaTg1L21DWlFTbG5EcDVybmRtdjQ9");
            InitializeComponent();

            await NavigationService.NavigateAsync("/TaxiMasterDetailPage/NavigationPage/HomePage");

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.Register<IRegexHelper, RegexHelper>();
            containerRegistry.Register<IGeolocatorService, GeolocatorService>();
            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<TaxiMasterDetailPage, TaxiMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<TaxiHistoryPage, TaxiHistoryPageViewModel>();
            containerRegistry.RegisterForNavigation<GroupPage, GroupPageViewModel>();
            containerRegistry.RegisterForNavigation<ModifyUserPage, ModifyUserPageViewModel>();
            containerRegistry.RegisterForNavigation<ReportPage, ReportPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<TripDetailPage, TripDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<RegisterPage, RegisterPageViewModel>();
        }
    }
}
