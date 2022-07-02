using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BooksApp.Model;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace BooksApp.ViewModels
{
    public class LibaryViewModel :BaseViewModel
    {

        private ObservableCollection<Datum> _Books;

        public ObservableCollection<Datum> Books
        {
            get
            {
                return _Books;
            }
            set
            {
                SetValue(ref _Books, value);
                OnPropertyChanged(nameof(Books));
            }
        }

        public LibaryViewModel()
        {
            

        }

        public void GetMyFavoriteBooks()
        {
            string userEmail = Preferences.Get("UserEmail", "");

            string favBookJson = Preferences.Get(userEmail, "");
            Books = new ObservableCollection<Datum>();
            List<Datum> myFavoriteBooks = JsonConvert.DeserializeObject<List<Datum>>(favBookJson);

            if (myFavoriteBooks != null && myFavoriteBooks.Count > 0)
            {
                foreach (Datum book in myFavoriteBooks.ToList())
                {
                    //if (!String.IsNullOrEmpty(book.image_url_s))
                    //{
                    //    book.ImageUri = new Uri(book.image_url_s);
                    //}
                    //else if (!String.IsNullOrEmpty(book.image_url_m))
                    //{
                    //    book.ImageUri = new Uri(book.image_url_m);
                    //}
                    //else if (!String.IsNullOrEmpty(book.image_url_l))
                    //{
                    //    book.ImageUri = new Uri(book.image_url_l);
                    //}
                    Books.Add(book);
                }
            }
        }
    }
}
