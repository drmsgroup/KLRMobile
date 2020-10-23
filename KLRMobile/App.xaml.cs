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
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzM4NDQxQDMxMzgyZTMzMmUzME5vMS9iSGU4eS9Eb3ZLbWZ5TStLRUV1T0diMGE0SDBONWZKOFNaNWNxdmc9");
            
            DependencyService.Register<LandRecordsMockDataStore>();
            DependencyService.Register<MarriageLicenseMockDataStore>();
            DependencyService.Register<TitleLienMockDataStore>();
            DependencyService.Register<UserMockDataStore>();
            DependencyService.Register<ImageMockDataStore>();
            DependencyService.Register<SettingsMockDataStore>();

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
