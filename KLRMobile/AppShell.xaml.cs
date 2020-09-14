using System;
using KLRMobile.Views;
using Xamarin.Forms;

namespace KLRMobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Navigation.PushModalAsync(new LoginPage());
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
