using System;
using System.Collections.Generic;
using BooksApp.Model;
using BooksApp.ViewModels;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BooksApp.Views
{
    public partial class LibraryPage : ContentPage
    {
        public LibraryPage()
        {
            ViewModel = new LibaryViewModel();
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.GetMyFavoriteBooks();
            lstMva.ItemsSource = ViewModel.Books;
            BindingContext = ViewModel;
        }


        public LibaryViewModel ViewModel
        {
            get
            {
                return BindingContext as LibaryViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }

        void MenuItem_Clicked(System.Object sender, System.EventArgs e)
        {
            MenuItem item = (MenuItem)sender;

            string userEmail = Preferences.Get("UserEmail", "");

            Datum selectedMVA = item.BindingContext as Datum;
            MyFavoriteBooks.MyFavoriteBooksList.Remove(selectedMVA);
            ViewModel.Books.Remove(selectedMVA);
            var myFavoriteBookListJson = JsonConvert.SerializeObject(ViewModel.Books);

            Preferences.Remove(userEmail);
            Preferences.Set(userEmail, myFavoriteBookListJson);
        }

        async void lstMva_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            Datum selectedBook = e.SelectedItem as Datum;
            await Navigation.PushAsync(new DetailBook(selectedBook));
        }

        void lstMva_Refreshing(System.Object sender, System.EventArgs e)
        {
        }

        void MenuTapped_Tapped(System.Object sender, System.EventArgs e)
        {
            Shell.Current.FlyoutIsPresented = !Shell.Current.FlyoutIsPresented;
        }
    }
}
