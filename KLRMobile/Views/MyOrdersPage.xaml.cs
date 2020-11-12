
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
    public partial class MyOrdersPage : ContentPage
    {
        readonly TitleLienSearchResultsViewModel _viewModel;
        public MyOrdersPage(TitleLienSearchResultsViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
            _viewModel = viewModel;
        }
    }
}