using System;
using System.Threading.Tasks;
using System.Windows.Input;
using BooksApp.DataContext;
using BooksApp.Model;
using BooksApp.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using BooksApp.Services;
using BooksApp.Provider;

namespace BooksApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Context context;

        //api için kullandık
        IFoursquare _rest = DependencyService.Get<IFoursquare>();
        Login loginProvider;

        public LoginViewModel()
        {
            LoginCommand = new Command(async async => await CheckUser());
            //RememberMeCommand = new Command(RememberMe(IsChecked));
            context = Context.Instance;

            loginProvider = new Login();
        }

        public void GetLoginInformation()
        {
            //buraya apiden data gelecek
            string email =  Preferences.Get("Email", "");
            string pwd = Preferences.Get("Password", "");
            IsChecked = Preferences.Get("IsChecked", false);
            if (!String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(pwd))
            {
                Email = email;
                Password = pwd;
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

        private string _Remember;
        public string Remember
        {
            get
            {
                return _Remember;
            }
            set
            {
                SetValue(ref _Remember, value);
                OnPropertyChanged(nameof(Remember));
            }
        }


        private bool _IsChecked;
        public bool IsChecked
        {
            get
            {
                return _IsChecked;
            }
            set
            {
                SetValue(ref _IsChecked, value);
                OnPropertyChanged(nameof(IsChecked));
            }
        }


        public ICommand LoginCommand { get; set; }

        public ICommand RememberMeCommand { get; set; }

        private async Task CheckUser()
        {
            //buraya apiden mail ve pass gelecek
            //api ile maiiler ve pass kontrol edilecek 
            if (!String.IsNullOrEmpty(Email) && !String.IsNullOrEmpty(Password))
            {
                //next page
                LoginModel model = new LoginModel
                {
                    email = Email,
                    password = Password
                };
                //context.user = user;
                //await Shell.Current.GoToAsync("//Home");
                //await Shell.Current.Navigation.PushAsync(new HomePage());
                //await Shell.Current.GoToAsync(nameof(HomePage)); Eğer aynı route'a farklı sayfalardan çağırılıyorsa hata oluştuğundan bu şekilde çağırılmalıdır. NOT: APPSHELL'DE Kİ SAVEROUTES METHODU UNUTULMAMALI

                Root loggedUser = await loginProvider.LoginOperation(model);

                if (loggedUser.message.success.Equals("Login Successful"))
                {
                    Preferences.Set("UserEmail", model.email.ToString());
                    Preferences.Set("UserPassword", model.password.ToString());
                    Preferences.Set("UserName",loggedUser.message.user.name);
                    Preferences.Set("Token", loggedUser.message.token.plainTextToken);
                    SelectionStuation.IsCameFromRegister = false;

                    await Application.Current.MainPage.Navigation.PushAsync(new HomePage());
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error!", "Please check your Email Address or Password", "OK");
                }
            }
            else if (Email.Equals("") || Password.Equals(""))
            {
                await Application.Current.MainPage.DisplayAlert("Error!", "Email and Pasword fields cannot be empty", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error!", "Please check your Email Address or Password", "OK");
            }
        }

        public void RememberMe(bool isChecked)
        {
            Preferences.Set("UserEmail", Email);
            Preferences.Set("UserPassword", Password);
        }
    }

}
