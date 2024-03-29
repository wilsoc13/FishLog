﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FishLog.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace FishLog
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            var initialView = new Home();
            MainPage = new MainPage(initialView);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
