﻿using KLRMobile.ViewModels;
using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KLRMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LaunchScreen : ContentPage
    {
        public LaunchScreen()
        {
            InitializeComponent();
            BindingContext = new LaunchScreenViewModel();
        }

        private void LandRecordsButton_OnClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new LandRecordsSearch());
        }

        private void TitleLienButton_OnClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new TitleLienSearch());
        }

        private void MarriageLicenseButton_OnClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new MarriageLicenseSearch());
        }
    }
} 