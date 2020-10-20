using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using KLRMobile.Services;
using KLRMobile.Views;

namespace KLRMobile
{
    public partial class App : Application
    {

        public App ()
        {
            InitializeComponent();
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzIyOTMxQDMxMzgyZTMyMmUzMG80RHpnOU5vMzVwNzczYkxsUDNFelFHU0pEd3F4NkQ0S2dQclpNdndEcFU9");
            
            DependencyService.Register<LandRecordsMockDataStore>();
            DependencyService.Register<MarriageLicenseMockDataStore>();
            DependencyService.Register<TitleLienMockDataStore>();
            DependencyService.Register<UserMockDataStore>();
            DependencyService.Register<ImageMockDataStore>();

            MainPage = new AppShell();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}
