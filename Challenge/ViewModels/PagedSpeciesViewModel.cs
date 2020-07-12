using Challenge.Models;
using Challenge.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Challenge.ViewModels
{
    public class PagedSpeciesViewModel : BaseViewModel
    {
        
        public ObservableCollection<Specie> PagedSpecies { get; set; }

        public bool PreviousIsVisible { get; set; }
        public bool NextIsVisible { get; set; }

        public string NextUrl { get; set; }
        public string PreviousUrl { get; set; }

        public PagedSpeciesViewModel(string url)
        {
            Title = "Species";
            var speciesApi = ConnectToApi.GetDatasFromUrlAsync<PagedSpecies>(url).Result;
            SetIsVisible(speciesApi);
            PreviousUrl = speciesApi.PreviousPage;
            NextUrl = speciesApi.NextPage;
            PagedSpecies = new ObservableCollection<Specie>(speciesApi.Species);
        }

        //Set our button Next and Previous visible or not by checking if there is a previous/next page from the model we get from the API.

        private void SetIsVisible(PagedSpecies specie)
        {
            if (specie.PreviousPage == null)
            {
                PreviousIsVisible = false;
            }
            else
            {
                PreviousIsVisible = true;
            }
            if (specie.NextPage == null)
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
