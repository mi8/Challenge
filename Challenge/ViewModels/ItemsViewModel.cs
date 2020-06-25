using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;

using Xamarin.Forms;
using Xamarin.Essentials;

using Challenge.Models;
using Challenge.Views;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Challenge.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public NetworkAccess CurrentConnectivity { get; set; }

        public ItemsViewModel()
        {
            Title = "Star Systems around SOL";

            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Item;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }


        async Task ExecuteLoadItemsCommand()
        {
            CurrentConnectivity = Connectivity.NetworkAccess;

            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "EDSMOfflineData.json");
            string debugFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DebugData.json");

            if (CurrentConnectivity == NetworkAccess.Internet)
            {
                Title = "Star Systems around SOL";

                IsBusy = true;

                try
                {
                    //Get Data from EDSM api:
                    HttpClient client = new HttpClient();
                    //Get all systems around SOL
                    string baseURL = "https://www.edsm.net/api-v1/sphere-systems";
                    string requestParams = $"?systemName={"Sol"}&radius={20}";
                    var response = await client.GetStringAsync(baseURL + requestParams);
                    var items = JsonConvert.DeserializeObject<List<Item>>(response);


                    //Save data for offline mode
                    File.WriteAllText(fileName, response);

                    //DEBUG : Save other datas for offline mode to see difference when loading it
                    //Get all systems around MEENE
                    string debugBaseURL = "https://www.edsm.net/api-v1/sphere-systems";
                    string debugRequestParams = $"?systemName={"Meene"}&radius={20}";
                    var debugResponse = await client.GetStringAsync(debugBaseURL + debugRequestParams);
                    File.WriteAllText(debugFileName, debugResponse);

                    //Add all detailed systems
                    Items.Clear();

                    foreach (var item in items)
                    {
                        //Store them
                        Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                finally
                {
                    IsBusy = false;
                }
            }
            else    // No or Bad Connection >>> display offline data
            {
                Title = "OFFLINE mode";

                IsBusy = true;

                try
                {
                    List<Item> offlineItems = new List<Item>();

                    if (File.Exists(debugFileName))
                    {
                        string offlineData = File.ReadAllText(debugFileName);
                        offlineItems = JsonConvert.DeserializeObject<List<Item>>(offlineData);
                    }
                    else
                    {
                        Item noItem = new Item();
                        noItem.Name = "No saved datas found !";
                        offlineItems.Add(noItem);
                    }

                    Items.Clear();

                    foreach (var item in offlineItems)
                    {
                        //Store them
                        Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                finally
                {
                    IsBusy = false;
                }
            }  
        }
    }
}