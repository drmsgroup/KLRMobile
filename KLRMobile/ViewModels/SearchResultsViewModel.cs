﻿using System;
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

        public ObservableCollection<LRMRResultItem> Items { get; set; }
        public ObservableCollection<County> Counties { get; }
        public Command AddItemCommand { get; }
        public Command<LRMRResultItem> ItemTapped { get; }
        public Command SearchCommand { get; }
        public Command NextResultsCommand { get; }
        public Command PreviousResultsCommand { get; }
        public PagingParameterModel PagingParameterModel {get; set;}
        public int CurrentPage { get; set; }

        public string Type { get; set; }
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

        public SearchResultsViewModel(string type)
        {
            Type = type;
            SearchCommand = new Command(OnSearch);
            NextResultsCommand = new Command(NextResults);
            PreviousResultsCommand = new Command(PreviousResults);
            Title = "Results";
            Items = new ObservableCollection<LRMRResultItem>();
            Counties = new ObservableCollection<County>();
            ItemTapped = new Command<LRMRResultItem>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
            PagingParameterModel = new PagingParameterModel();
        }

        private async void OnSearch(object obj)
        {
            if (!String.IsNullOrEmpty(PagingParameterModel.LastName)){
                var model = new PagingParameterModel {
                    PageNumber = 1
                };
                IEnumerable<LRMRResultItem> items;
                switch (Type) {
                    case "Marriage":
                        items = await MarriageLicenseDataStore.GetItemsPagedAsync(model);
                        break;
                    case "LandRecords":
                        items = await LandRecordsDataStore.GetItemsPagedAsync(model);
                        break;
                    default:
                        items = await MarriageLicenseDataStore.GetItemsPagedAsync(model);
                        break;
                }
                Items.Clear();
                foreach (var item in items) {
                    Items.Add(item);
                }
                CurrentPage = model.PageNumber;
                if (items.Count() > 0) {
                    switch (Type) {
                        case "Marriage":
                            Application.Current.MainPage = new NavigationPage(new SearchResults("Marriage", this));
                            break;
                        case "LandRecords":
                            Application.Current.MainPage = new NavigationPage(new SearchResults("LandRecords", this));
                            break;
                        default:
                            break;
                    }
                } else {
                    NoResultsVisible = true;
                }
            } else {
                NoResultsVisible = true;
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

        public async void NextResults()
        {
            if (!String.IsNullOrEmpty(PagingParameterModel.LastName))
            {
                PagingParameterModel.PageNumber++;
                IEnumerable<LRMRResultItem> items;
                switch (Type)
                {
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
                if (items.Count() > 0)
                {
                    Items.Clear();
                    items = items.Where(i => i.FirstParty.ToLower().Contains(PagingParameterModel.LastName.ToLower())).ToList();
                    foreach (var item in items)
                    {
                        Items.Add(item);
                    }
                    CurrentPage = PagingParameterModel.PageNumber;
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

        public async void PreviousResults()
        {
            Items.Clear();
            IEnumerable<LRMRResultItem> items;
            switch (Type)
            {
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
            if (!String.IsNullOrEmpty(PagingParameterModel.LastName))
            {
                PagingParameterModel.PageNumber--;
                if (items.Count() > 0)
                {
                    Items.Clear();
                    items = items.Where(i => i.FirstParty.ToLower().Contains(PagingParameterModel.LastName.ToLower())).ToList();
                    foreach (var item in items)
                    {
                        Items.Add(item);
                    }
                    CurrentPage = PagingParameterModel.PageNumber;
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