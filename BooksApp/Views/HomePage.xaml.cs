using System;
using System.Collections.Generic;
using BooksApp.DataContext;
using Xamarin.Forms;
using BooksApp.Model;
using BooksApp.ViewModels;
using Xamarin.Essentials;

namespace BooksApp.Views
{
    public partial class HomePage : ContentPage
    {
       
        public HomePage()
        {
            ViewModel = new HomeViewModel();
            InitializeComponent();

            BindingContext = ViewModel;
        }
        public HomeViewModel ViewModel
        {
            get
            {
                return BindingContext as HomeViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }

        void MenuTapped_Tapped(System.Object sender, System.EventArgs e)
        {
            Shell.Current.FlyoutIsPresented = !Shell.Current.FlyoutIsPresented;
        }

        async void LogOut_Tapped(System.Object sender, System.EventArgs e)
        {
            Preferences.Remove("UserEmail");
            Preferences.Remove("UserPassword");
            Preferences.Remove("UserName");
            await Shell.Current.GoToAsync("//Login");
        }
    }
}
