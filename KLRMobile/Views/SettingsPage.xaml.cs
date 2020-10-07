using KLRMobile.ViewModels;
using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KLRMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
} 