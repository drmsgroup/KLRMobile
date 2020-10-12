using System;
using System.Linq;
using Xamarin.Forms;
using KLRMobile.ViewModels;
using KLRMobile.Services;

namespace KLRMobile.Views
{
    public partial class TitleLienSearchResults : ContentPage
    {
        readonly TitleLienSearchResultsViewModel _viewModel;

        public TitleLienSearchResults(TitleLienSearchResultsViewModel viewModel)
        {
            InitializeComponent();
            
            BindingContext = viewModel;
            _viewModel = viewModel;
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