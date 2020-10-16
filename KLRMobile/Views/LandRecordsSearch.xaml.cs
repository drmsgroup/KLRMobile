using KLRMobile.Models;
using KLRMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KLRMobile.Views
{
    public partial class LandRecordsSearch : ContentPage
    {
        public LandRecordsSearch()
        {
            InitializeComponent();
            var model = new SearchResultsViewModel("LandRecords");
            BindingContext = model;
        }
        private void Back_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new LaunchScreen());
        }
    }
}