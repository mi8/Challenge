using Challenge.Models;
using Challenge.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Challenge.ViewModels
{
    public class PagedStarshipsViewModel : BaseViewModel
    {
        
        public ObservableCollection<Starship> PagedStarships { get; set; }

        public bool PreviousIsVisible { get; set; }
        public bool NextIsVisible { get; set; }

        public string NextUrl { get; set; }
        public string PreviousUrl { get; set; }

        public PagedStarshipsViewModel(string url)
        {
            Title = "Starships";
            var starshipsApi = ConnectToApi.GetDatasFromUrlAsync<PagedStarships>(url).Result;
            SetIsVisible(starshipsApi);
            PreviousUrl = starshipsApi.PreviousPage;
            NextUrl = starshipsApi.NextPage;
            PagedStarships = new ObservableCollection<Starship>(starshipsApi.Starships);
        }

        //Set our button Next and Previous visible or not by checking if there is a previous/next page from the model we get from the API.

        private void SetIsVisible(PagedStarships starship)
        {
            if (starship.PreviousPage == null)
            {
                PreviousIsVisible = false;
            }
            else
            {
                PreviousIsVisible = true;
            }
            if (starship.NextPage == null)
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
