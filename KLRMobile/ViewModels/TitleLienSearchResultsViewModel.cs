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
    public class TitleLienSearchResultsViewModel : BaseViewModel
    {
        private TitleLienResultItem _selectedItem;
        private County _selectedCounty;

        public string DebtorLast { get; set; }

        public List<TitleLienResultItem> Items { get; set; }
        public ObservableCollection<County> Counties { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get;  }
        public Command<TitleLienResultItem> ItemTapped { get; }
        public Command SearchCommand { get; }
        public bool noResultsVisible { get; set; }
        public bool NoResultsVisible {
            get
            {
                return noResultsVisible;
            }
            set
            {
                noResultsVisible = value;
                OnPropertyChanged(nameof(NoResultsVisible));
            }
        }

        public TitleLienSearchResultsViewModel()
        {
            SearchCommand = new Command(OnSearch);
            Title = "Results";
            Items = TitleLienDataStore.GetItemsAsync(true).Result.ToList();
            Counties = new ObservableCollection<County>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<TitleLienResultItem>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var model = new PagingParameterModel();
                var items = await TitleLienDataStore.GetItemsPagedAsync(model);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public TitleLienResultItem SelectedItem
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

        private void OnSearch(object obj)
        {
            if (!String.IsNullOrEmpty(DebtorLast)) {
                var items = Items.Where(i => i.DebtorLast.ToLower() == DebtorLast.ToLower()).ToList();
                if (items.Count() > 0)  {
                    Items = items;
                    Application.Current.MainPage = new NavigationPage(new TitleLienSearchResults(this));
                } else {
                    NoResultsVisible = true;
                }
            } else {
                NoResultsVisible = true;
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(TitleLienResultItem item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}