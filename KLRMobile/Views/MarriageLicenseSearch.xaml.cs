﻿using KLRMobile.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KLRMobile.Views
{
    public partial class MarriageLicenseSearch : ContentPage
    {
        public MarriageLicenseSearch()
        {
            InitializeComponent();
        }
        private void Back_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new LaunchScreen());
        }
        private void SearchClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new SearchResults("Marriage"));
        }
    }
}