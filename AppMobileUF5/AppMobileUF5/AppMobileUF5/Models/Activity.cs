using System;
using System.Collections.Generic;
using System.Text;

namespace AppMobileUF5.Models
{
    public class Activity
    {
       
        public int Id_activity { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Activity_date { get; set; }
        public int Fk_society { get; set; }
        public int Fk_student { get; set; }
        public bool Deleted { get; set; }
    }
    public class ActivityComplete : Activity
    {
        public ActivityComplete()
        {

        }
        public ActivityComplete(Activity activity, IEnumerable<Registration> registrations, Society society)
        {
            this.Society = society;
            this.Registrations = registrations;
            this.Activity_date = activity.Activity_date;
            this.Description = activity.Description;
            this.Fk_student = activity.Fk_student;
            this.Id_activity = activity.Id_activity;
            this.Title = activity.Title;
            this.Deleted = activity.Deleted;
        }
        public Society Society { get; set; }
        public IEnumerable<Registration> Registrations { get; set; }
    }
}

