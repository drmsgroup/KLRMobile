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
using Xamarin.Forms.Internals;

namespace KLRMobile.ViewModels
{
    public class TitleLienSearchResultsViewModel : BaseViewModel
    {
        private TitleLienResultItem _selectedItem;
        private County _selectedCounty;

        public string DebtorLast { get; set; }

        public ObservableCollection<TitleLienResultItem> Items { get; set; }
        public ObservableCollection<County> Counties { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<TitleLienResultItem> ItemTapped { get; }
        public Command SearchCommand { get; }
        public Command NextResultsCommand { get; }
        public Command PreviousResultsCommand { get; }
        public bool noResultsVisible { get; set; }
        public int CurrentPage { get; set; }
        public PagingParameterModel PagingModel { get; set; }

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
            NextResultsCommand = new Command(NextResults);
            PreviousResultsCommand = new Command(PreviousResults);
            Title = "Results";
            Counties = new ObservableCollection<County>();
            Items = new ObservableCollection<TitleLienResultItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<TitleLienResultItem>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
            PagingModel = new PagingParameterModel();
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await TitleLienDataStore.GetItemsPagedAsync(PagingModel);
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

        private async void OnSearch(object obj)
        {
            if (!String.IsNullOrEmpty(PagingModel.LastName)) {
                var model = new PagingParameterModel {
                    PageNumber = 1
                };
                var items = await TitleLienDataStore.GetItemsPagedAsync(model);
                if (items.Count() > 0)  {
                    Items.Clear();
                    items = items.Where(i => i.DebtorLast.ToLower().Contains(PagingModel.LastName.ToLower())).ToList();
                    foreach (var item in items) {
                        Items.Add(item);
                    }
                    Application.Current.MainPage = new NavigationPage(new TitleLienSearchResults(this));
                    CurrentPage = model.PageNumber;
                } else {
                    NoResultsVisible = true;
                }
            } else {
                NoResultsVisible = true;
            }
        }

        public async void PreviousResults()
        {
            if (!String.IsNullOrEmpty(PagingModel.LastName))
            {
                PagingModel.PageNumber--;
                var items = await TitleLienDataStore.GetItemsPagedAsync(PagingModel);
                if (items.Count() > 0)
                {
                    Items.Clear();
                    items = items.Where(i => i.DebtorLast.ToLower().Contains(PagingModel.LastName.ToLower())).ToList();
                    foreach (var item in items)
                    {
                        Items.Add(item);
                    }
                    CurrentPage = PagingModel.PageNumber;
                }
                else
                {
                    NoResultsVisible = true;
                }
            }
            else
            {
                NoResultsVisible = true;
            }
        }

        public async void NextResults()
        {
            if (!String.IsNullOrEmpty(PagingModel.LastName)) {
                PagingModel.PageNumber++;
                var items = await TitleLienDataStore.GetItemsPagedAsync(PagingModel);
                if (items.Count() > 0) {
                    Items.Clear();
                    items = items.Where(i => i.DebtorLast.ToLower().Contains(PagingModel.LastName.ToLower())).ToList();
                    foreach (var item in items)
                    {
                        Items.Add(item);
                    }
                    CurrentPage = PagingModel.PageNumber;
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