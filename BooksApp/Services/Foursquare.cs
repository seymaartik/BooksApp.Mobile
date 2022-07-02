using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using BooksApp.Model;
using Newtonsoft.Json;

namespace BooksApp.Services
{
    public class Foursquare:IFoursquare
    {
        //mali url verecek
        string Base_url = "http://34.65.222.211/";


        //mali client id ve secret verecek
        string ClientID = "";
        string ClientSecret = "";

        public async Task<ObservableCollection<User>> getUser(double lat,double lon)
        {
            string ll = $"{lat},{lon}";
            int radius = 250;
            int limit = 10;
            int version = 20220521;

            
            string url = Base_url + $"?ll={ll}&radius={radius}&limit={limit}&v={version}&client_id={ClientID}&client_secret={ClientSecret}";

            HttpClient client = new HttpClient();
            HttpResponseMessage respone = await client.GetAsync(url);

            if (respone.StatusCode==System.Net.HttpStatusCode.OK)
            {
                var result = await respone.Content.ReadAsStringAsync();

                var json = JsonConvert.DeserializeObject<ObservableCollection<User>>(result);

                return json;
            }

            return null;

        }
    }
}
