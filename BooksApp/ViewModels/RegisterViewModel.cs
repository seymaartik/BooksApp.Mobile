using System;
using System.Threading.Tasks;
using BooksApp.Model;
using BooksApp.Provider;
using BooksApp.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BooksApp.ViewModels
{
    public class RegisterViewModel:BaseViewModel
    {
        Register registerProvider;
        public RegisterViewModel()
        {
            registerProvider = new Register();
        }

        private string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                SetValue(ref _Name, value);
                OnPropertyChanged(nameof(Name));
            }
        }


        private string _Email;
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                SetValue(ref _Email, value);
                OnPropertyChanged(nameof(Email));
            }
        }


        private string _Password;
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                SetValue(ref _Password, value);
                OnPropertyChanged(nameof(Password));
            }
        }

        public async Task Register()
        {
            try
            {
                if (!String.IsNullOrEmpty(Email) && !String.IsNullOrEmpty(Password))
                {
                    RegisterModel model = new RegisterModel
                    {
                        email = Email,
                        password = Password,
                        name = Name
                    };

                    Root root = await registerProvider.RegisterOperation(model);

                    if (root.message.success.Contains("User registered successfully."))
                    {
                        Preferences.Set("UserEmail", model.email.ToString());
                        Preferences.Set("UserPassword", model.password.ToString());
                        Preferences.Set("UserName", model.name);
                        SelectionStuation.IsCameFromRegister = true;
                        await Application.Current.MainPage.Navigation.PushAsync(new SelectionPage());
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Something Went Wrong! Please Try Again Later :)", "OK");
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error!", "Please check your Email Address or Password", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error!", "Please check your Email Address or Password", "OK");
            }
        }
    }
}
