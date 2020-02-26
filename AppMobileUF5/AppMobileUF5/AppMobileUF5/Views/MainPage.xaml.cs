using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppMobileUF5.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobileUF5.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            
             InitializeComponent();
            btnLogout.Clicked += OnAlertYesNoClicked;

           // todayBTN.Clicked += TodayBTN_Clicked;
           //  pastdayBTN.Clicked += PastdayBTN_Clicked;
        }
        async void OnAlertYesNoClicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Effettuare il logout?", " ", "No", "Si");
            Debug.WriteLine("Answer: " + answer);
            if (answer == false)
            {
                Navigation.PushAsync( new LoginPage());
            }
            else
            {
                Navigation.PushAsync(new MainPage());
            }
        }


        /*     private void PastdayBTN_Clicked(object sender, EventArgs e)
             {
                 Navigation.PushAsync(new PastActivities());
             }

             private void TodayBTN_Clicked(object sender, EventArgs e)
             {
                 Navigation.PushAsync(new TodayActivities());
             } */
    }
}