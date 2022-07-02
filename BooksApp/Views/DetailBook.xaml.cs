using System;
using System.Collections.Generic;
using System.Linq;
using BooksApp.Model;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BooksApp.Views
{
    public partial class DetailBook : ContentPage
    {
        Model.Datum _selected;
        public DetailBook(Model.Datum selected)
        {
            _selected = selected;
            InitializeComponent();
            lblTitle.Text = "Title: " + selected.title;
            lblAuthor.Text = "Author: " + selected.author;
            lblYearOfPublication.Text = "Year Of Publication: " + selected.year_of_publication.ToString();
            lblPublisher.Text = "Publisher: " + selected.publisher;
            if (SelectionStuation.IsCameFromRegister)
            {
                BookRatingBar.IsVisible = false;
            }
            else
            {
                BookRatingBar.IsVisible = true;
            }

            if (selected.created_at != null)
            {
                if (selected.created_at.ToString().Length == 1)
                {
                    if ((int)selected.created_at == 1)
                    {
                        BookRatingBar.SelectedStarValue = 1;

                    }
                    else if ((int)selected.created_at == 2)
                    {
                        BookRatingBar.SelectedStarValue = 2;

                    }
                    else if ((int)selected.created_at == 3)
                    {
                        BookRatingBar.SelectedStarValue = 3;

                    }
                    else if ((int)selected.created_at == 4)
                    {
                        BookRatingBar.SelectedStarValue = 4;

                    }
                    else if ((int)selected.created_at == 5)
                    {
                        BookRatingBar.SelectedStarValue = 5;

                    }
                    else
                    {
                        BookRatingBar.SelectedStarValue = 0;
                    }
                }
                else
                {
                    BookRatingBar.SelectedStarValue = 0;
                }
            }
            else
            {
                BookRatingBar.SelectedStarValue = 0;
            }
        }

        void SaveTapped_Tapped(System.Object sender, System.EventArgs e)
        {
            string userEmail = Preferences.Get("UserEmail", "");

            string favBookJson = Preferences.Get(userEmail, "");
            List<Datum> myFavoriteBooks = JsonConvert.DeserializeObject<List<Datum>>(favBookJson);

            if (myFavoriteBooks != null && myFavoriteBooks.Count > 0)
            {
                Datum selectedBook= myFavoriteBooks.Where(s => s.title == _selected.title).FirstOrDefault();
                selectedBook.created_at = (int)BookRatingBar.SelectedStarValue;

                var myFavoriteBookListJson = JsonConvert.SerializeObject(MyFavoriteBooks.MyFavoriteBooksList);

                Preferences.Remove(userEmail);
                Preferences.Set(userEmail, myFavoriteBookListJson);

            }
        }
    }
}
