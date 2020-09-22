using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using KLRMobile.Models;
using KLRMobile.Views;
using KLRMobile.ViewModels;

namespace KLRMobile.Views
{
    public partial class SearchResults : ContentPage
    {
        SearchResultsViewModel _viewModel;
        private string SearchType { get; set; }

        public SearchResults(string type)
        {
            InitializeComponent();
            SearchType = type;

            BindingContext = _viewModel = new SearchResultsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            switch (SearchType) {
                case "Marriage":
                    Application.Current.MainPage = new NavigationPage(new MarriageLicenseSearch());
                    break;
                case "LandRecords":
                    Application.Current.MainPage = new NavigationPage(new LandRecordsSearch());
                    break;
                default:
                    Application.Current.MainPage = new NavigationPage(new LandRecordsSearch());
                    break;
            }
        }
    }
}