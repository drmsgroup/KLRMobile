﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using KLRMobile.Services;
using KLRMobile.Views;

namespace KLRMobile
{
    public partial class App : Application
    {

        public App ()
        {
            InitializeComponent();

            DependencyService.Register<LRMRMockDataStore>();
            DependencyService.Register<TitleLienMockDataStore>();

            MainPage = new AppShell();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}
