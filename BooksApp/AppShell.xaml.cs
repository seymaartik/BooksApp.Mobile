using System;
using System.Collections.Generic;
using BooksApp.Views;
using Xamarin.Forms;

namespace BooksApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            SaveRoutes();
        }

        private void SaveRoutes()
        {
            Routing.RegisterRoute("Login", typeof(LoginPage));
            Routing.RegisterRoute("Register", typeof(RegisterPage));
            Routing.RegisterRoute("Profil", typeof(ProfilePage));
            Routing.RegisterRoute("Home", typeof(HomePage));
            Routing.RegisterRoute("Library", typeof(LibraryPage));
            Routing.RegisterRoute("Explare", typeof(ExplarePage));
            Routing.RegisterRoute("Groups", typeof(GroupsPage));
            Routing.RegisterRoute("Selection", typeof(SelectionPage));

            //Routing.RegisterRoute("//Home/GittiğinSayfa", typeof(SayfanınAdı)); Direk yol
            //Routing.RegisterRoute("//Login/Home", typeof(HomePage));
            //farklı sayfalardan aynı route erişmek isteyen yönlendirmelerde hata meydana gelmektedir. Bunun önüne geçmek için her yolun yazılması şart!!
            //Yönlendirme örneği için LoginViewModel'e bakınız Satır 106


        }
    }
}
