using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Challenge.Models;
using System.Text;
using System.Net.Http;
using Xamarin.Essentials;
using Newtonsoft.Json;


namespace Challenge.Services
{
    public class ElephantAPI : IData<Elephant>
    {
        HttpClient client;
        IEnumerable<Elephant> elephants;

        public ElephantAPI()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.ElephantAPIURL}/");

            elephants = new List<Elephant>();
        }
        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;

        public async Task<IEnumerable<Elephant>> GetElephantsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync("");
                Console.WriteLine("supertest" + json);
                elephants = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Elephant>>(json));
                Console.WriteLine(elephants);
            }
            else
            {

            }

            return elephants;
        }
    }
}
