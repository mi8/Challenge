using Challenge.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;

namespace Challenge.Services
{
    public static class ConnectToApi

    {
        //Get the différents url from the root
        public async static Task<Root> GetRootUrlAsync()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage message = client.GetAsync("https://swapi.dev/api/").Result;
            if (message.IsSuccessStatusCode)
            {
                var stream = await message.Content.ReadAsStreamAsync();
                Root datas = await JsonSerializer.DeserializeAsync<Root>(stream);
                return datas;
            }

            return null;
        }

        //Get datas from the Api
        public async static Task<T> GetDatasFromUrlAsync<T>(string url)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage message = client.GetAsync(url).Result;
            if (message.IsSuccessStatusCode)
            {
                var stream = await message.Content.ReadAsStreamAsync();
                T datas = await JsonSerializer.DeserializeAsync<T>(stream);
                return datas;
            }

            return default(T);
        }

        //Call the Challenge.LocalAPI with the local adress
        public async static Task<Number> GetResultFromNumber(int number)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string url = $"https://localhost:5000/api/number/{number}";
            HttpResponseMessage message = client.GetAsync(url).Result;
            if (message.IsSuccessStatusCode)
            {
                url = $"https://localhost:5001/api/number/{number}";
                message = client.GetAsync(url).Result;
                if (message.IsSuccessStatusCode)
                {
                    var stream = await message.Content.ReadAsStreamAsync();
                    Number datas = await JsonSerializer.DeserializeAsync<Number>(stream);
                    return datas;
                }
            }
            return default(Number);
        }
    }
}
