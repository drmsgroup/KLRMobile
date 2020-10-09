using KLRMobile.Models;
using KLRMobile.Services;
using KLRMobile.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace KLRMobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public List<User> Items { get; }

        public bool _invalidLoginVisible { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public Command LoadItemsCommand { get; }
        public LoginViewModel() {
            LoginCommand = new Command(OnLogin);
            Items = UserDataStore.GetItemsAsync(true).Result.ToList();
            InvalidLoginIsVisible = false;
        }

        public bool InvalidLoginIsVisible {
            get
            {
                return _invalidLoginVisible;
            }
            set
            {
                _invalidLoginVisible = value;
                OnPropertyChanged(nameof(InvalidLoginIsVisible));
            }
        }

        private void OnLogin(object obj)
        {
            var user = Items.Where(i => i.EmailAddress.ToLower() == EmailAddress.ToLower() && i.Password == Password).FirstOrDefault();
            if (user != null) {
                Application.Current.MainPage = new NavigationPage(new LaunchScreen());
            } else {
                InvalidLoginIsVisible = true;
            }
        }
    }
}
