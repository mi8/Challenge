using Challenge.Models;
using Challenge.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Challenge.ViewModels
{
    public class PagedPeopleViewModel : BaseViewModel
    {
        
        public ObservableCollection<People> PagedPeople { get; set; }
        
        public bool PreviousIsVisible { get; set; }
        public bool NextIsVisible { get; set; }

        public string NextUrl { get; set; }
        public string PreviousUrl { get; set; }

        public PagedPeopleViewModel(string url)
        {
            Title = "People";
            var peopleApi = ConnectToApi.GetDatasFromUrlAsync<PagedPeople>(url).Result;
            SetIsVisible(peopleApi);
            PreviousUrl = peopleApi.PreviousPage;
            NextUrl = peopleApi.NextPage;
            PagedPeople = new ObservableCollection<People>(peopleApi.People);
        }

        //Set our button Next and Previous visible or not by checking if there is a previous/next page from the model we get from the API.

        private void SetIsVisible(PagedPeople people)
        {
            if(people.PreviousPage == null)
            {
                PreviousIsVisible = false;
            }
            else
            {
                PreviousIsVisible = true;
            }
            if(people.NextPage == null)
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
