using Newtonsoft.Json;
using NoSocialLifeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NoSocialLifeApp.Services
{
    public class FacebookClient
    {

        static string BASE_URL = "https://nosociallifeapp.azurewebsites.net/";
        /*
        public static async Task<AppIdentity> GetIdentity(string token)
        {
            HttpClient client = new HttpClient();

            //client.DefaultRequestHeaders.Add("X-ZUMO-AUTH", token);
            client.DefaultRequestHeaders.Add("X-ZUMO-AUTH", "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdGFibGVfc2lkIjoic2lkOjlmMTZkZmVjYTI3ODVhOTI4ZDYwODgwNDcyMWI5ZWUyIiwic3ViIjoic2lkOjFlZGJiM2UyYmJjZDY0NGUzNTA3MDZlYjM5OTA3MmYwIiwiaWRwIjoiZmFjZWJvb2siLCJ2ZXIiOiIzIiwiaXNzIjoiaHR0cHM6Ly9ub3NvY2lhbGxpZmVhcHAuYXp1cmV3ZWJzaXRlcy5uZXQvIiwiYXVkIjoiaHR0cHM6Ly9ub3NvY2lhbGxpZmVhcHAuYXp1cmV3ZWJzaXRlcy5uZXQvIiwiZXhwIjoxNTAyMTMxMzg0LCJuYmYiOjE0OTY5NTEwOTR9.a42ECk_-JEModWDTuPxDbH1bs2RNhd60o6nbxc5VFLs");
            client.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");

            client.BaseAddress = new Uri(BASE_URL);

            HttpResponseMessage response = await client.GetAsync(".auth/me");
            var content = await response.Content.ReadAsStringAsync();

            //AppIdentity identity = new AppIdentity();


            if (response.IsSuccessStatusCode)
            {
                //var root = JsonConvert.DeserializeObject<AppIdentity>(content);
                //identity = root[0].AppIdentity[0]. ;

                //var root = JsonConvert.DeserializeObject<????>(content);
                //JsonConvert.DeserializeObject<List<CustomerJson>>(json);
                //identity = rootList[0].identity;
            }

            return null;
        }

    */

    }
}
