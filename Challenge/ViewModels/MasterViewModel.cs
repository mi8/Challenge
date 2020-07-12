using Challenge.Models;
using Challenge.Services;
using Challenge.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Challenge.ViewModels
{
    public class MasterViewModel : BaseViewModel
    {
        public ObservableCollection<MasterMenuItem> MenuItems { get; set; }
        

        public MasterViewModel()
        {
            Title = "Menu";            
            Root Urls = ConnectToApi.GetRootUrlAsync().Result;
            MenuItems = new ObservableCollection<MasterMenuItem>();
            
            //Generate our Menu

            MenuItems.Add(new MasterMenuItem
            {
                Text = "Films",
                Detail = "All the films saga",
                ImagePath = "icon.png",
                TargetPage = Urls.FilmsUrl,
                TargetType = typeof(PagedFilmsPage)
            });

            MenuItems.Add(new MasterMenuItem
            {
                Text = "People",
                Detail = "All the people in the saga",
                ImagePath = "icon.png",
                TargetPage = Urls.PeopleUrl,
                TargetType = typeof(PagedPeoplePage)
            });

            MenuItems.Add(new MasterMenuItem
            {
                Text = "Planets",
                Detail = "All the planets in the saga",
                ImagePath = "icon.png",
                TargetPage = Urls.PlanetsUrl,
                TargetType = typeof(PagedPlanetsPage)
            });

            MenuItems.Add(new MasterMenuItem
            {
                Text = "Species",
                Detail = "All the species in the saga",
                ImagePath = "icon.png",
                TargetPage = Urls.SpeciesUrl,
                TargetType = typeof(PagedSpeciesPage)
            });

            MenuItems.Add(new MasterMenuItem
            {
                Text = "Starships",
                Detail = "All the starships in the saga",
                ImagePath = "icon.png",
                TargetPage = Urls.StarshipsUrl,
                TargetType = typeof(PagedStarshipsPage)
            });

            MenuItems.Add(new MasterMenuItem
            {
                Text = "Vehicles",
                Detail = "All the vehicles in the saga",
                ImagePath = "icon.png",
                TargetPage = Urls.VehiclesUrl,
                TargetType = typeof(PagedVehiclesPage)
            });

            MenuItems.Add(new MasterMenuItem
            {
                Text = "Find a Number",
                Detail = "Find a number between 1 and 50000",
                ImagePath = "icon.png",
                TargetType = typeof(FindNumberPage)
            });
        }
    }
}
