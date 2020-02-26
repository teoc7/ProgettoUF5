using System;
using App.Core.ViewModels;
using AppMobileUF5;
using AppMobileUF5.Models;
using AppMobileUF5.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobileUF5.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        LoginPageViewModel viewModel;
        public LoginPage()
        {
            BindingContext = viewModel=new LoginPageViewModel(Navigation);
            InitializeComponent();
            LoginBTN.Clicked += LoginBTN_Clicked;
        }



        private async void LoginBTN_Clicked(object sender, EventArgs e)
        {
            Account account = new Account();

            //ad app finita 
            //account.Username = emailEntry.Text;
            // account.Password = passwordEntry.Text;


            //TESTING

            account.Username = "mstudent";
            account.Password = "student";


           viewModel.LoginAction(account);
            await Navigation.PushAsync(new MainPage());

          //  User a = new User { EMAIL = emailEntry.Text, PASSWORD = passwordEntry.Text, ROLE = "user" };



        /*    var token = await new RestService().Login(a);

            if (token != null)
            {
                Application.Current.Properties["token"] = token.ToString();

                await Application.Current.SavePropertiesAsync();
                Navigation.PushAsync(new MainPage());


            }
            else
            {

            } */
        }
    }
}