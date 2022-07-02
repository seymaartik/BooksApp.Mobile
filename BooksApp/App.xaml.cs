using System;
using BooksApp.Views;
using BooksApp.DataContext;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BooksApp.Services;

namespace BooksApp
{
    public partial class App : Application
    {
        public Context ctx;
        public App()
        {
            InitializeComponent();
            DependencyService.Register<IFoursquare, Foursquare>();
            ctx = new Context();
            //MainPage = new NavigationPage(new LoginPage());

            //apiden sonra maşnpage düzenledik
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
