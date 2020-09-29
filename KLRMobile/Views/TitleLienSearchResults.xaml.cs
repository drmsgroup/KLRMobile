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
    public partial class TitleLienSearchResults : ContentPage
    {
        readonly TitleLienSearchResultsViewModel _viewModel;

        public TitleLienSearchResults()
        {
            InitializeComponent();
            
            BindingContext = _viewModel = new TitleLienSearchResultsViewModel();
        }

        private void ShowPdf(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new PdfViewer());
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