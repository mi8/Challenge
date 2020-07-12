using Challenge.Models;
using Challenge.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Challenge.ViewModels
{
    public class PagedFilmsViewModel : BaseViewModel
    {
        public ObservableCollection<Film> PagedFilms { get; set; }

        public bool PreviousIsVisible { get; set; }
        public bool NextIsVisible { get; set; }

        public string NextUrl { get; set; }
        public string PreviousUrl { get; set; }

        public PagedFilmsViewModel(string url)
        {
            Title = "Films";
            var filmsApi = ConnectToApi.GetDatasFromUrlAsync<PagedFilms>(url).Result;
            SetIsVisible(filmsApi);
            PreviousUrl = filmsApi.PreviousPage;
            NextUrl = filmsApi.NextPage;
            PagedFilms = new ObservableCollection<Film>(filmsApi.Films);
            
        }

        //Set our button Next and Previous visible or not by checking if there is a previous/next page from the model we get from the API.
        private void SetIsVisible(PagedFilms film)
        {
            if (film.PreviousPage == null)
            {
                PreviousIsVisible = false;
            }
            else
            {
                PreviousIsVisible = true;
            }
            if (film.NextPage == null)
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
