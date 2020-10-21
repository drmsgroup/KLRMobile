using KLRMobile.Models;
using KLRMobile.Services;
using KLRMobile.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace KLRMobile.ViewModels
{
    [Preserve(AllMembers = true)]
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; set; }
        public List<User> Items { get; }
        private string password;

        public bool _invalidLoginVisible { get; set; }
        public string EmailAddress { get; set; }
        public string Password {
            get
            {
                return this.password;
            }

            set
            {
                if (this.password == value)
                {
                    return;
                }

                this.password = value;
                this.NotifyPropertyChanged();
            }
        }
        public Command LoadItemsCommand { get; }
        public Command SignUpCommand { get; set; }

        public LoginViewModel() {
            LoginCommand = new Command(OnLogin);
            SignUpCommand = new Command(SignUpClicked);
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

        private void SignUpClicked(object obj)
        {
            // Do something
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
