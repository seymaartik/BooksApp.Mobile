using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BooksApp.Views
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();

            dtpBirthDate.MinimumDate = DateTime.Now.AddYears(-55);
            dtpBirthDate.MaximumDate = DateTime.Now.AddYears(1);
            dtpBirthDate.Date = DateTime.Now;
            dtpBirthDate.Format = "yyyy-MM-dd";
        }

       private void onFavoriteBook(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FavoritePage());
        }

        
    }
}
