
using KLRMobile.ViewModels;
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
    }
}