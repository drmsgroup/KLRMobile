using System.ComponentModel;
using Xamarin.Forms;
using KLRMobile.ViewModels;

namespace KLRMobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}