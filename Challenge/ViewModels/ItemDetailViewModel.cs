using Challenge.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Challenge.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public Item DetailsItem { get; set; }

        public ItemDetailViewModel(Item item = null)
        {
            //Title = item?.Name;
            Title = "Star System Details";
            Item = item;

            //UpdateDetailsData();
        }

        //public async void UpdateDetailsData()
        //{
        //    //HTTP request
        //    HttpClient client = new HttpClient();
        //    string baseURL = "https://www.edsm.net/api-v1/system";
        //    string requestParams = $"?systemName={"Sol"}&showCoordinates={1}&showInformation={1}&showPrimaryStar={1}";
        //    var response2 = await client.GetStringAsync(baseURL + requestParams);

        //    DetailsItem = JsonConvert.DeserializeObject<Item>(response2);
        //    //DetailsItem.Name = Item.Name;
        //    DetailsItem.Distance = Item.Distance;
        //    DetailsItem.BodyCount = Item.BodyCount;
        //}
    }
}
