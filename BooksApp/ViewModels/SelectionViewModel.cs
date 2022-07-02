using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using BooksApp.Model;
using BooksApp.Provider;
using Xamarin.Forms;

namespace BooksApp.ViewModels
{
    public class SelectionViewModel : BaseViewModel
    {
        Provider.Book bookProvider;
        public SelectionViewModel()
        {
            bookProvider = new Provider.Book();
        }

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

        public async Task GetAllBooks()
        {
            try
            {
                Books = new ObservableCollection<Datum>();
                Model.Book bookList = new Model.Book();
                bookList = await bookProvider.GetAllBooks();
                
                if (bookList != null && bookList.data.Count > 0)
                {
                    foreach (Datum book in bookList.data.ToList())
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
            catch (Exception ex)
            {

            }
        }
    }
}
