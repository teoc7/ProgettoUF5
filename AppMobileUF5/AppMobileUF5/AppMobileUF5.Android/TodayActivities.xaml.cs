using AppMobileUF5.Models;
using AppMobileUF5.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

         protected override void OnAppearing()
        {
            base.OnAppearing();
            
            chiamataAPi();
        }
        public void chiamataAPi()
        {
            Activity att = new Activity();
            att.Description = "desc";
            att.Title = "sviluppo web";
            att.Activity_date = new DateTime(2019,2,20);


         //  activities.AttivitàGiornaliera = att;
        }


        
        
        
        
        
        
        
        
        //GEOLOCALIZZAZIONE CHECKIN CHECKOUT
        
    
//try
//            {
//                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
//        var location = await Geolocation.GetLocationAsync(request);


//                if (location != null)
//                {
//                    await DisplayAlert("gps", "Latitude:" + location.Latitude + "\nLongitude:" + location.Longitude + "\nAltitude" + location.Altitude, "OK");
//        Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
//                }


//    //coordinate campus reti: 45.609344, 8.849487
//    //coordinate mie: 45.6086928, 8.8474045
//    Xamarin.Essentials.Location its = new Xamarin.Essentials.Location(45.609344, 8.849487);
//    double dist = Xamarin.Essentials.Location.CalculateDistance(location, its, DistanceUnits.Kilometers); //distanza in kilometri --> metri = dist*1000


//    await DisplayAlert("distanza", dist.ToString() + "\nDistanza metri:" + (dist*1000).ToString(), "OK");


//            }
//            catch (Exception excp)
//            {
//                Console.WriteLine(excp);
//            }







    }
}