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
    public partial class TitleLienSearchResults : ContentPage
    {
        readonly TitleLienSearchResultsViewModel _viewModel;

        public TitleLienSearchResults()
        {
            InitializeComponent();
            
            BindingContext = _viewModel = new TitleLienSearchResultsViewModel();
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
            Application.Current.MainPage = new NavigationPage(new TitleLienSearch());
        }
    }
}