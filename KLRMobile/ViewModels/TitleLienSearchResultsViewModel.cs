﻿using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using KLRMobile.Models;
using KLRMobile.Views;

namespace KLRMobile.ViewModels
{
    public class TitleLienSearchResultsViewModel : BaseViewModel
    {
        private TitleLienResultItem _selectedItem;
        private County _selectedCounty;

        public ObservableCollection<TitleLienResultItem> Items { get; }
        public ObservableCollection<County> Counties { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get;  }
        public Command<TitleLienResultItem> ItemTapped { get; }

        public TitleLienSearchResultsViewModel()
        {
            Title = "Results";
            Items = new ObservableCollection<TitleLienResultItem>();
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
                var items = await TitleLienDataStore.GetItemsAsync(true);
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