using System;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KLRMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PdfViewer : ContentPage
    {
        Stream fileStream;
        public PdfViewer()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            fileStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("KLRMobile.Assets.mortgage.pdf");
            ////Load the PDF
            pdfViewerControl.LoadDocument(fileStream);
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new LaunchScreen());
        }
    }
}