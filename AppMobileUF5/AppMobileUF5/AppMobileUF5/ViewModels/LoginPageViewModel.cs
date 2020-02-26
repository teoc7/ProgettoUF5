using System;
using System.Windows.Input;
using Xamarin.Forms;
using AppMobileUF5.ViewModels;
using System.Net.Mail;
using System.Text.RegularExpressions;
using AppMobileUF5.Models;
using AppMobileUF5.Services;
using AppMobileUF5;
using AppMobileUF5.Views;
using System.Threading.Tasks;

namespace App.Core.ViewModels
{
    public class LoginPageViewModel : BasePageViewModel
    {
        public INavigation Navigation;

        public LoginPageViewModel(INavigation _navigation)
        {

            PageTitle = "Login";
            Navigation = _navigation;
        }

        #region Properties

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                SetPropertyValue(ref _email, value);
                
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
               SetPropertyValue(ref _password, value);              
            }
        }

        private bool _isShowCancel;
        public bool IsShowCancel
        {
            get { return _isShowCancel; }
            set { SetPropertyValue(ref _isShowCancel, value); }
        }

        #endregion


        #region Commands

        private ICommand _loginCommand;
        //public ICommand LoginCommand
        //{
        //    get { return _loginCommand = _loginCommand ?? new Command(LoginAction, CanLoginAction); }
        //}

        private ICommand _cancelLoginCommand;
        public ICommand CancelLoginCommand
        {
            get { return _cancelLoginCommand = _cancelLoginCommand ?? new Command(CancelLoginAction); }
        }

        private ICommand _forgotPasswordCommand;
        public ICommand ForgotPasswordCommand
        {
            get { return _forgotPasswordCommand = _forgotPasswordCommand ?? new Command(ForgotPasswordAction); }
        }

        private ICommand _newAccountCommand;
        public ICommand NewAccountCommand
        {
            get { return _newAccountCommand = _newAccountCommand ?? new Command(NewAccountAction); }
        }

        #endregion


        #region Methods

        bool CanLoginAction()
        {
            //Metodo login

            if (string.IsNullOrWhiteSpace(this.Email) || string.IsNullOrWhiteSpace(this.Password) )/*|| !(Regex.IsMatch(this.Email, @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?")))*/  // !(Regex.IsMatch(this.Password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")))
                return false;

            return true;
        }
        bool isValidEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);



                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public async void LoginAction(Account a)
        {
            IsBusy = true;

            //// User a = new User { EMAIL = "user@user.it", PASSWORD ="user", ROLE = "user" };
            //User a = new User();
            //a.EMAIL = "user@user.it";
            //a.PASSWORD = "user";
            //a.ROLE = "user";


            //Task t = Task.Run(async () =>
            //{
                AccountFull accountFull = await new RestService().Login(a);
            string token = accountFull.Token;

            if (token != null)
            {
                    Application.Current.Properties["Account"] = accountFull;
                    Application.Current.Properties["token"] = accountFull.Token.ToString();

                    await Application.Current.SavePropertiesAsync();
            }
            else
            {

            }

            
            //TODO - perform your login action + navigate to the next page

            //Simulate an API call to show busy/progress indicator            
            // Task.Delay(20000).ContinueWith((t) => IsBusy = false);

            //Show the Cancel button after X seconds
            //Task.Delay(5000).ContinueWith((t) => IsShowCancel = true);

            //await Task.Delay(3000).ContinueWith((t) => IsBusy = false);
            //if(this._email.Length > 5 )
            //{
            //    await Navigation.PushModalAsync(new NavigationPage(new MainPage()));
            //}
            //else
            //{
            //    await Navigation.PushModalAsync(new NavigationPage(new ResetPassword()));
            //}

        }

        void CancelLoginAction()
        {
            //TODO - perform cancellation logic

            IsBusy = false;
            IsShowCancel = false;
        }

        void ForgotPasswordAction()
        {
            //TODO - navigate to your forgotten password page
            //Navigation.PushAsync(XXX);
        }

        void NewAccountAction()
        {
            //TODO - navigate to your registration page
            //Navigation.PushAsync(XXX);
        }

        #endregion
    }
}