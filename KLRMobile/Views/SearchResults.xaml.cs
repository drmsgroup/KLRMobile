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
using KLRMobile.Services;

namespace KLRMobile.Views
{
    public partial class SearchResults : ContentPage
    {
        readonly SearchResultsViewModel _viewModel;
        private string SearchType { get; set; }

        public SearchResults(string type)
        {
            InitializeComponent();
            SearchType = type;

            BindingContext = _viewModel = new SearchResultsViewModel();
        }

        private async void ShowPdf(object sender, EventArgs e)
        {
            var imageDataStore = new ImageMockDataStore();
            var images = await imageDataStore.GetItemsAsync();
            Application.Current.MainPage = new NavigationPage(new PdfViewer(images.First().imageStream));
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