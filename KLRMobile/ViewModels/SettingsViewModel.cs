using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using KLRMobile.Models;
using KLRMobile.Views;

namespace KLRMobile.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private County _selectedCounty;

        public ObservableCollection<County> Counties { get; }

        public SettingsViewModel()
        {
            Counties = new ObservableCollection<County>();
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        public County SelectedCounty {
            get => _selectedCounty;
            set
            {
                SetProperty(ref _selectedCounty, value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(LRMRResultItem item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}