
using KLRMobile.Services;
using KLRMobile.ViewModels;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace KLRMobile.Views
{
    /// <summary>
    /// Page to show the my order list. 
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TitleLienSearchResults : ContentPage
    {
        public TitleLienSearchResults(TitleLienSearchResultsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
        private async void ShowPdf(object sender, EventArgs e)
        {
            var imageDataStore = new ImageMockDataStore();
            var images = await imageDataStore.GetItemsAsync();
            await Application.Current.MainPage.Navigation.PushAsync(new PdfViewer(images.First().imageStream));
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new LaunchScreen());
        }
    }
}