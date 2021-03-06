﻿using System;
using KLRMobile.Views;
using Xamarin.Forms;

namespace KLRMobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(LaunchScreen), typeof(LaunchScreen));
            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
            //Navigation.PushModalAsync(new LoginPage());
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }

        private void OnSettingsPageClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new SettingsPage());
        }
    }
}
