using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AppMobileUF5.Models;
using Xamarin.Forms;
using System.Net.Http.Headers;

namespace AppMobileUF5.Services
{
    public class RestService
    {
        private HttpClient client;

        public static string prefixApi = "https://rsystem-test.azurewebsites.net/";

        //   private string grant_type = "password";



        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }


        //api login

        public async Task<AccountFull> Login(Account account)
        {

            string weburl = prefixApi + "login";
            //string weburl = "http://localhost:61948/Auth";
            //string weburl = "http://192.168.137.1:61948/Auth";
            // UserPost contentjson = new UserPost { email = user.email, password = user.password };
            var content = JsonConvert.SerializeObject(account);
            var conten = new StringContent(content, Encoding.UTF8, "application/json");
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Application.Current.Properties["token"].ToString());
            try
            {
                HttpResponseMessage response = await client.PostAsync(weburl, conten);
                //var result = await response.Content.ReadAsStringAsync();
                //return JsonConvert.DeserializeObject<string>(result);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    AccountFull acc= JsonConvert.DeserializeObject<AccountFull>(result);
                    return acc;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {

                return null;
            }
        }


        //api todayAct
        public static async Task<HttpResponseMessage> GetLogToday()
        {
            AccountFull ac = (AccountFull)Application.Current.Properties["Account"];
            int id = ac.Id_account;
            DateTime today = DateTime.Now;
            string weburl = prefixApi + $"activity/getdestinationbyaccount/{id}/{today.Date.ToString("yyyy-MM-dd")}";
            //string weburl = "http://localhost:61948/Auth";
            //string weburl = "http://192.168.137.1:61948/Auth";

            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            // UserPost contentjson = new UserPost { email = user.email, password = user.password };
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Application.Current.Properties["token"].ToString());

            //var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await client.GetAsync(weburl);
                // this result string should be something like: "{"token":"rgh2ghgdsfds"}"
                //var result = await response.Content.ReadAsStringAsync();
                //return JsonConvert.DeserializeObject<string>(result);
                return response;
            }
            catch (Exception e)
            {

                return new HttpResponseMessage { StatusCode = System.Net.HttpStatusCode.ServiceUnavailable };
            }
        }


        //api past
        public static async Task<HttpResponseMessage> GetLogPast()
        {

            AccountFull ac = (AccountFull)Application.Current.Properties["Account"];
            int id = ac.Id_account;
            DateTime today = DateTime.Now;
            string weburl = prefixApi + $"activity/getallactivitiesofstudentbeforedate/{id}/{today.Date.ToString("yyyy-MM-dd")}";

            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Application.Current.Properties["token"].ToString());

            try
            {
                HttpResponseMessage response = await client.GetAsync(weburl);
                //var result = await response.Content.ReadAsStringAsync();
                //return JsonConvert.DeserializeObject<string>(result);
                return response;
            }
            catch (Exception e)
            {

                return new HttpResponseMessage { StatusCode = System.Net.HttpStatusCode.ServiceUnavailable };
            }
        }

      


        //api checkin
        public static async Task<string> Check(int id_attivita)
        {
            try
            {
                ActivityComplete acc = (ActivityComplete)Application.Current.Properties["Activity"];
                int id = acc.Id_activity;
                DateTime today = DateTime.Now;
                string apiUri = prefixApi + $"registration/check/{id}/{today.Date.ToString("yyyy-MM-dd")}";
                var client = new HttpClient();
                client.BaseAddress = new Uri(apiUri);

                string jsonData = "";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Application.Current.Properties["token"].ToString());
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(apiUri, content);

                
                var result = await response.Content.ReadAsStringAsync();

                return result;
            }

            catch (Exception ex)
            {
                var t = ex.Message;
                return null;

            }
        }

        // api chechout
        public static async Task<string> PostCheckOut(int id_attivita)
        {
            try
            {
                string apiUri = prefixApi + "PostCheck_InByActivityId/" + id_attivita;
                var client = new HttpClient();
                client.BaseAddress = new Uri(apiUri);

                string jsonData = "";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Application.Current.Properties["token"].ToString());
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(apiUri, content);

                // this result string should be something like: "{"token":"rgh2ghgdsfds"}"
                var result = await response.Content.ReadAsStringAsync();

                return result;
            }

            catch (Exception ex)
            {
                var t = ex.Message;
                return null;

            }
        }


    }
}