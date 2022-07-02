using BooksApp.ViewModels;
using Xamarin.Forms;


namespace BooksApp.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            ViewModel = new LoginViewModel();
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.GetLoginInformation();
            BindingContext = ViewModel;
        }

        public LoginViewModel ViewModel
        {
            get
            {
                return BindingContext as LoginViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }
        
        void LoginButton_Clicked(System.Object sender, System.EventArgs e)
        {
            ViewModel.LoginCommand.Execute(null);
        }

        void cbRemember_CheckedChanged(System.Object sender, Xamarin.Forms.CheckedChangedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            ViewModel.RememberMe(checkBox.IsChecked);
        }

        async void RegisterButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage(), true);
        }
    }
}
