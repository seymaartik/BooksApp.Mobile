//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("BooksApp.Views.HomePage.xaml", "Views/HomePage.xaml", typeof(global::BooksApp.Views.HomePage))]

namespace BooksApp.Views {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("Views/HomePage.xaml")]
    public partial class HomePage : global::Xamarin.Forms.ContentPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.TapGestureRecognizer MenuTapped;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.TapGestureRecognizer LogOut;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(HomePage));
            MenuTapped = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.TapGestureRecognizer>(this, "MenuTapped");
            LogOut = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.TapGestureRecognizer>(this, "LogOut");
        }
    }
}
