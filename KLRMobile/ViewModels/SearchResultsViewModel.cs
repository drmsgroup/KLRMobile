using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using KLRMobile.Models;
using KLRMobile.Views;
using System.Collections.Generic;
using System.Linq;
using KLRMobile.Services;

namespace KLRMobile.ViewModels
{
    public class SearchResultsViewModel : BaseViewModel
    {
        private LRMRResultItem _selectedItem;
        private County _selectedCounty;

        public List<LRMRResultItem> Items { get; set; }
        public ObservableCollection<County> Counties { get; }
        public Command AddItemCommand { get; }
        public Command<LRMRResultItem> ItemTapped { get; }
        public Command SearchCommand { get; }
        public PagingParameterModel PagingParameterModel {get; set;}

        public string Type { get; set; }

        public SearchResultsViewModel(string type)
        {
            Type = type;
            SearchCommand = new Command(OnSearch);
            Title = "Results";
            Items = new List<LRMRResultItem>();
            Counties = new ObservableCollection<County>();
            ItemTapped = new Command<LRMRResultItem>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
            PagingParameterModel = new PagingParameterModel();
        }

        private async void OnSearch(object obj)
        {
            IEnumerable<LRMRResultItem> items;
            switch (Type) {
                case "Marriage":
                    items = await MarriageLicenseDataStore.GetItemsPagedAsync(PagingParameterModel);
                    break;
                case "LandRecords":
                    items = await LandRecordsDataStore.GetItemsPagedAsync(PagingParameterModel);
                    break;
                default:
                    items = await MarriageLicenseDataStore.GetItemsPagedAsync(PagingParameterModel);
                    break;
            }
            
            if (items != null)
            {
                switch (Type) {
                    case "Marriage":
                        Items = items.ToList();
                        Application.Current.MainPage = new NavigationPage(new SearchResults("Marriage", this));
                        break;
                    case "LandRecords":
                        Items = items.ToList();
                        Application.Current.MainPage = new NavigationPage(new SearchResults("LandRecords", this));
                        break;
                    default:
                            break;
                }
                
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public LRMRResultItem SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
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