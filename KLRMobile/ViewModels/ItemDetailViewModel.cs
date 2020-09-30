using System;
using System.Diagnostics;
using System.Threading.Tasks;
using KLRMobile.Models;
using Xamarin.Forms;

namespace KLRMobile.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private int itemId;
        private string text;
        private string description;
        public int Id { get; set; }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public int ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }        

        public async void LoadItemId(int itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
