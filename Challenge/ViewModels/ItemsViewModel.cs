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
            Title = "Systems 20 ly from SOL";

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
                Title = "Systems 20 ly from SOL";

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

        ////Update Title
        //Title = "OFFLINE mode";

        //        string offlineData = File.ReadAllText(debugFileName);
        //var offlineItems = JsonConvert.DeserializeObject<List<Item>>(offlineData);

        //Items.Clear();

        //        foreach (var item in offlineItems)
        //        {
        //            //Store them
        //            Items.Add(item);
        //        }

    //BackUp
    //async Task ExecuteLoadItemsCommand()
    //{
    //    IsBusy = true;

    //    try
    //    {
    //        ////Master:
    //        //Items.Clear();
    //        //var items = await DataStore.GetItemsAsync(true);
    //        //foreach (var item in items)
    //        //{
    //        //    Items.Add(item);
    //        //}


    //        //Get Data from EDSM api:
    //        HttpClient client = new HttpClient();
    //        //Get all systems around SOL
    //        string baseURL = "https://www.edsm.net/api-v1/sphere-systems";
    //        string requestParams = $"?systemName={"Sol"}&radius={20}";
    //        var response = await client.GetStringAsync(baseURL + requestParams);
    //        var items = JsonConvert.DeserializeObject<List<Item>>(response);


    //        Items.Clear();

    //        //Add all detailed systems
    //        foreach (var item in items)
    //        {
    //            ////Add System details
    //            //string urlDetail = "https://www.edsm.net/api-v1/system";
    //            ////string paramsDetail = $"?systemName={item.Name}&showCoordinates={1}&showInformation={1}&showPrimaryStar={1}";
    //            //string paramsDetail = $"?systemName={item.Name}&showCoordinates={1}&showPrimaryStar={1}";
    //            //var responseDetailed = await client.GetStringAsync(urlDetail + paramsDetail);
    //            //var detailedItem = JsonConvert.DeserializeObject<Item>(responseDetailed);

    //            ////item.Coords = detailedItem.Coords;
    //            ////if (detailedItem.Information != null) item.Information = detailedItem.Information;
    //            ////if(detailedItem.PrimaryStar != null) item.PrimaryStar = detailedItem.PrimaryStar;

    //            //Store them
    //            Items.Add(item);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Debug.WriteLine(ex);
    //    }
    //    finally
    //    {
    //        IsBusy = false;
    //    }
    //}
}
}