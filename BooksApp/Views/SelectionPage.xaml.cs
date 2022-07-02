using System;
using System.Collections.Generic;
using System.Linq;
using BooksApp.Model;
using BooksApp.ViewModels;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BooksApp.Views
{
    public partial class SelectionPage : ContentPage
    {
        public SelectionPage()
        {
            ViewModel = new SelectionViewModel();
            InitializeComponent();
            if (SelectionStuation.IsCameFromRegister)
            {
                IconMenu.IsVisible = false;
            }
            else
            {
                IconMenu.IsVisible = true;
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //burda apiden gelecek kitap listesiyle dolacak
            //lstMva.BindingContext = BookSelection.BindingWithGrouping();

            await ViewModel.GetAllBooks();
            lstMva.ItemsSource = ViewModel.Books;
            BindingContext = ViewModel;
        }

        public SelectionViewModel ViewModel
        {
            get
            {
                return BindingContext as SelectionViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }

        private async void onSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            ListView lst = (ListView)sender;
            var selectedMVA = (Datum)e.SelectedItem;
            var isOk = await DisplayAlert(selectedMVA.title, selectedMVA.author, "Detail", "Cancel");

            if (isOk)
            {
                await Navigation.PushAsync(new DetailBook(selectedMVA));
            }

            lst.SelectedItem = null;
        }

        private async void onRefresh(object sender, EventArgs e)
        {
            //eğer ki yeni eklenen kitaplar varsa burda tekrardan load edilecek

            BookSelection.RefreshCount++;
            await ViewModel.GetAllBooks();
            lstMva.IsRefreshing = false;
        }

        private void onTextChanged(object sender, TextChangedEventArgs e)
        {
            if (sbSearchBar.Text.Length >= 2)
            {
                lstMva.ItemsSource = ViewModel.Books.Where(x => x.title.ToLower().StartsWith(sbSearchBar.Text.ToLower())).ToList();
            }
            else if (String.IsNullOrEmpty(e.NewTextValue))
            {
                lstMva.ItemsSource = ViewModel.Books;
            }
        }

        private void onDetail(object sender, EventArgs e)
        {
            //Navigation.PopModalAsync(new DetailBook( selectedItem ));
        }

        private void onAdd(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;

            Datum selectedMVA = item.BindingContext as Datum;

            MyFavoriteBooks.MyFavoriteBooksList.Add(selectedMVA);

            ViewModel.Books.Remove(selectedMVA);
        }

        async void MenuItem_Clicked(System.Object sender, System.EventArgs e)
        {
            MenuItem item = (MenuItem)sender;

            Datum selectedMVA = item.BindingContext as Datum;

            await Navigation.PushAsync(new DetailBook(selectedMVA));
        }

        async void Completed_Activated(System.Object sender, System.EventArgs e)
        {
            SelectionStuation.IsCameFromRegister = false;
            if (MyFavoriteBooks.MyFavoriteBooksList.Count <= 2)
            {
                await DisplayAlert("Uyarı!", "En az 3 kitap seçmelisiniz.", "Tamam");
            }
            else
            {
                var myFavoriteBookListJson = JsonConvert.SerializeObject(MyFavoriteBooks.MyFavoriteBooksList);
                string userEmail = Preferences.Get("UserEmail","");

                Preferences.Remove(userEmail);
                Preferences.Set(userEmail, myFavoriteBookListJson);

                await Navigation.PushAsync(new HomePage());
            }
        }

        void MenuTapped_Tapped(System.Object sender, System.EventArgs e)
        {
            Shell.Current.FlyoutIsPresented = !Shell.Current.FlyoutIsPresented;
        } 
    }
}
