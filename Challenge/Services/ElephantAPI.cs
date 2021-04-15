using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Challenge.Models;
using System.Text;
using System.Net.Http;
using Xamarin.Essentials;
using Newtonsoft.Json;
using System.IO;
using SQLite;
using System.Collections.ObjectModel;
using System.Linq;

namespace Challenge.Services
{
    public class ElephantAPI : IData<Elephant>
    {
        HttpClient client;
        IEnumerable<Elephant> elephants;
        SQLiteAsyncConnection localDb;
        string localDBPath;

        public ElephantAPI()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.ElephantAPIURL}/");
            localDBPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), App.LOCAL_DB_NAME);
            localDb = new SQLiteAsyncConnection(localDBPath);
            localDb.CreateTableAsync<Elephant>();
            elephants = new List<Elephant>();
        }
        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;

        public async Task<IEnumerable<Elephant>> GetElephantsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync("elephants");
                elephants = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Elephant>>(json));
                await localDb.DeleteAllAsync<Elephant>();
                await localDb.InsertAllAsync(elephants.Take<Elephant>(5));
            }
            else
            {
                elephants = await localDb.Table<Elephant>().ToListAsync();
            }

            return elephants;
        }
    }
}
