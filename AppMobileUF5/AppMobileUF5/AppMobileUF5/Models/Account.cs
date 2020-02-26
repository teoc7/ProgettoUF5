using System;
using System.Collections.Generic;
using System.Text;
using AppMobileUF5.Models;

namespace AppMobileUF5.Models
{
    public class Account
    {
        public int Id_account { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Fk_role { get; set; }
        public string Display_name { get; set; }
        public bool Available { get; set; }
        public bool Deleted { get; set; }
    }
    public class AccountFull : Account
    {
        public AccountFull(Account account, string token = default, Role role = default)
        {
            this.Fk_role = account.Fk_role;
            this.Available = account.Available;
            this.Display_name = account.Display_name;
            this.Username = account.Username;
            this.Id_account = account.Id_account;
            this.Role = role.Name;
            this.Token = token;
            this.Deleted = account.Deleted;
        }


        public AccountFull()
        {

        }
        public string Token { get; set; }
        public string Role { get; set; }
    }
    public class AccountComplexSociety : Account
    {
        public Society Society { get; set; }
        public AccountComplexSociety() { }
        public AccountComplexSociety(Account account, Society society)
        {
            this.Society = society;
            this.Fk_role = account.Fk_role;
            this.Available = account.Available;
            this.Display_name = account.Display_name;
            this.Username = account.Username;
            this.Id_account = account.Id_account;
            this.Deleted = account.Deleted;
        }
    }
   
}
