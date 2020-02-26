using AppMobileUF5.Models;
using AppMobileUF5.Services;
using AppMobileUF5.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobileUF5.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodayActivities : ContentPage
    {
        ActivitiesViewModel activities;
        public TodayActivities()
        {
            activities = new ActivitiesViewModel();
            BindingContext = activities;
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //  chiamataAPi today activities();
            HttpResponseMessage response = await RestService.GetLogToday();
            Debug.Print(response.ToString());
            if (response.IsSuccessStatusCode)
            {
                if (response.Content.ToString() != "null" && !String.IsNullOrEmpty(response.Content.ToString()))
                {
                    string contents = await response.Content.ReadAsStringAsync();
                    activities.attivitaGiornaliera = JsonConvert.DeserializeObject<ActivityComplete>(contents);
                    Debug.Print(activities.attivitaGiornaliera.ToString());
                }
                else
                {

                }
            }
            //GEOLOCALIZZAZIONE CHECKIN CHECKOUT
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);


                if (location != null)
                {
                    await DisplayAlert("gps", "Latitude:" + location.Latitude + "\nLongitude:" + location.Longitude + "\nAltitude" + location.Altitude, "OK");
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                }


                //coordinate campus reti: 45.609344, 8.849487
                //coordinate mie: 45.6086928, 8.8474045
                Xamarin.Essentials.Location its = new Xamarin.Essentials.Location(45.609344, 8.849487);
                double dist = Xamarin.Essentials.Location.CalculateDistance(location, its, DistanceUnits.Kilometers); //distanza in kilometri --> metri = dist*1000


                await DisplayAlert("distanza", dist.ToString() + "\nDistanza metri:" + (dist * 1000).ToString(), "OK");


            }
            catch (Exception excp)
            {
                Console.WriteLine(excp);
            }


            // chiamata check
        }
        private void btnAct_Clicked_in(object sender, EventArgs e)
        {
            string varCheckIn = (sender as Button).ClassId;
            RestService.Check(int.Parse(varCheckIn));
        }
        private void btnAct_Clicked_out(object sender, EventArgs e)
        {
            string varCheckOut = (sender as Button).ClassId;
            RestService.Check(int.Parse(varCheckOut));
        }

    }
}