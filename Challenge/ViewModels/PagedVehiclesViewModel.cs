using Challenge.Models;
using Challenge.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Challenge.ViewModels
{
    public class PagedVehiclesViewModel : BaseViewModel
    {
        
        public ObservableCollection<Vehicle> PagedVehicles { get; set; }

        public bool PreviousIsVisible { get; set; }
        public bool NextIsVisible { get; set; }

        public string NextUrl { get; set; }
        public string PreviousUrl { get; set; }

        public PagedVehiclesViewModel(string url)
        {
            Title = "Vehicles";
            var vehiclesApi = ConnectToApi.GetDatasFromUrlAsync<PagedVehicles>(url).Result;
            SetIsVisible(vehiclesApi);
            PreviousUrl = vehiclesApi.PreviousPage;
            NextUrl = vehiclesApi.NextPage;
            PagedVehicles = new ObservableCollection<Vehicle>(vehiclesApi.Vehicles);
        }

        //Set our button Next and Previous visible or not by checking if there is a previous/next page from the model we get from the API.

        private void SetIsVisible(PagedVehicles vehicle)
        {
            if (vehicle.PreviousPage == null)
            {
                PreviousIsVisible = false;
            }
            else
            {
                PreviousIsVisible = true;
            }
            if (vehicle.NextPage == null)
            {
                NextIsVisible = false;
            }
            else
            {
                NextIsVisible = true;
            }
        }
    }
}
