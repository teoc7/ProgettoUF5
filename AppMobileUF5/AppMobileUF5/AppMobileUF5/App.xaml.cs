using Xamarin.Forms;
using AppMobileUF5.Views;
using AppMobileUF5.Services;

namespace AppMobileUF5
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

       //     MainPage = new MainPage();
       //    DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new LoginPage());
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
