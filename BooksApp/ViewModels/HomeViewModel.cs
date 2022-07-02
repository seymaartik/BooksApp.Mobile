using System;
using System.Windows.Input;
using BooksApp.DataContext;
using BooksApp.Model;
using BooksApp.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BooksApp.ViewModels
{
   
    public class HomeViewModel : BaseViewModel
    {
        public Context context;
        public HomeViewModel()
        {
            //context = Context.Instance;
            //userEmail = context.user.email;
            string userName = Preferences.Get("UserName", "");
            string userMail = Preferences.Get("UserEmail", "");
            if (!string.IsNullOrEmpty(userName))
            {
                WelcomeText = "Hoşgeldiniz " +userName;

            }
            else
            {
                WelcomeText = "Hoşgeldiniz " + userMail;
            }
        }

        private string _userEmail;
        public string WelcomeText
        {
            get { return _userEmail; }
            set
            {
                _userEmail = value;
                OnPropertyChanged(nameof(WelcomeText)); // Notify that there was a change on this property
            }
        }
        

    }

}
