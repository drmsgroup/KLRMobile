using KLRMobile.Models;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace KLRMobile.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        public IList<County> Counties { get; set; }
        public SearchViewModel()
        {
            Title = "Search";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamain-quickstart"));
            Counties = new List<County>
            {
                new County { Name = "Calloway" },
                new County { Name = "Graves" }
            };
        }

        public ICommand OpenWebCommand { get; }
    }
}