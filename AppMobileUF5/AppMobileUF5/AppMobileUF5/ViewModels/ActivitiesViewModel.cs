using AppMobileUF5.Models;
using AppMobileUF5.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppMobileUF5.ViewModels
{
    public class ActivitiesViewModel : BasePageViewModel
    {

        //public List<PastActivity> attivitaPass { get; set; }

        public ActivityComplete attivitaGiornaliera { get; set; }

        public ActivityComplete attivitaPassate { get; set; }


        public Command LoadItemsCommand { get; set; }
        public ActivitiesViewModel()
        {
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }
        async Task ExecuteLoadItemsCommand()
        {
            //inserire dati

        }
        //public async Task Check_in()
        //{
        //    CheckIn c_In = new CheckIn();
        //    c_In.check_in = DateTime.Now;
        //    c_In.date_presence = DateTime.Now;
        //    c_In.id_presence = 0;
        //    c_In.check_out = DateTime.Now;
        //    c_In.fk_calendar = Item.calendar.id_calendar;
        //    RestService.CheckIn(c_In);
        //}
    }
}
