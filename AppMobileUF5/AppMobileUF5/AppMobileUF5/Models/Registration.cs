using System;
using System.Collections.Generic;
using System.Text;

namespace AppMobileUF5.Models
{
   public class Registration
    {
        public int Id_registration { get; set; }
        public int Fk_activity { get; set; }
        public DateTime Reg_date { get; set; }
        public string Reg_type { get; set; }
        public bool Deleted { get; set; }
    }
}
