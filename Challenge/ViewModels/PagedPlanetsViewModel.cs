using Challenge.Models;
using Challenge.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Challenge.ViewModels
{
    public class PagedPlanetsViewModel : BaseViewModel
    {
        
        public ObservableCollection<Planet> PagedPlanets { get; set; }

        public bool PreviousIsVisible { get; set; }
        public bool NextIsVisible { get; set; }

        public string NextUrl { get; set; }
        public string PreviousUrl { get; set; }

        public PagedPlanetsViewModel(string url)
        {
            Title = "Planets";
            var planetsApi = ConnectToApi.GetDatasFromUrlAsync<PagedPlanets>(url).Result;
            SetIsVisible(planetsApi);
            PreviousUrl = planetsApi.PreviousPage;
            NextUrl = planetsApi.NextPage;
            PagedPlanets = new ObservableCollection<Planet>(planetsApi.Planets);
        }

        //Set our button Next and Previous visible or not by checking if there is a previous/next page from the model we get from the API.

        private void SetIsVisible(PagedPlanets planet)
        {
            if (planet.PreviousPage == null)
            {
                PreviousIsVisible = false;
            }
            else
            {
                PreviousIsVisible = true;
            }
            if (planet.NextPage == null)
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
