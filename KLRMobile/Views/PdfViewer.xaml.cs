using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using KLRMobile.ViewModels;

namespace KLRMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PdfViewer : ContentPage
    {
        private Stream fileStream;
        
        public PdfViewer(Stream docStream)
        {
            InitializeComponent();
            fileStream = docStream;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            pdfViewerControl.LoadDocument(fileStream);
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}