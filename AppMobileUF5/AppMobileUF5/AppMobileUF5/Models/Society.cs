using System;
using System.Collections.Generic;
using System.Text;

namespace AppMobileUF5.Models
{
  public  class Society
    {
        
        public int Id_company { get; set; }
       
        public string Name { get; set; }
        public string Type { get; set; }
        public string P_iva { get; set; }
        public string Phone_number { get; set; }
        public string Email { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Postal_code { get; set; }
        public string Coordinates { get; set; }
        public int Fk_account { get; set; }
        public bool Deleted { get; set; }
    }
}
