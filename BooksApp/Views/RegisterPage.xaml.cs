using System;
using System.Collections.Generic;
using BooksApp.ViewModels;
using Xamarin.Forms;

namespace BooksApp.Views
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            ViewModel = new RegisterViewModel();
            BindingContext = ViewModel;
        }

        public RegisterViewModel ViewModel
        {
            get
            {
                return (RegisterViewModel)BindingContext;
            }
            set
            {
                BindingContext = value;
            }
        }


        async void RegisterButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await ViewModel.Register();
        }
    }
}
