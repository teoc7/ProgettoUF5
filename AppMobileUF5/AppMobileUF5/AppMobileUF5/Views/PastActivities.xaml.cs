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

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobileUF5.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PastActivities : ContentPage
    {
        ActivitiesViewModel activities;
        public PastActivities()
        {
            activities = new ActivitiesViewModel();
            BindingContext = activities;
            InitializeComponent();
             
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //if(viewModel.attivitaPass.Count == 0)
            //{
            //    viewModel.LoadItemsCommand.Execute(null);
            //}
            HttpResponseMessage response = await RestService.GetLogPast();
            Debug.Print(response.ToString());
            if (response.IsSuccessStatusCode)
            {
                if (response.Content.ToString() != "null" && !String.IsNullOrEmpty(response.Content.ToString()))
                {
                    string contents = await response.Content.ReadAsStringAsync();
                    activities.attivitaGiornaliera = JsonConvert.DeserializeObject<ActivityComplete>(contents);
                    Debug.Print(activities.attivitaPassate.ToString());
                }
                else
                {

                }
            }
        }
     
    }
}