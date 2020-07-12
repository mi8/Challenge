using Challenge.Models;
using Challenge.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Challenge.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagedPlanetsPage : ContentPage
    {
        private PagedPlanetsViewModel ViewModel;
        private bool AlternedRow { get; set; }

        public PagedPlanetsPage(MasterMenuItem item)
        {
            InitializeComponent();

            this.ViewModel = new PagedPlanetsViewModel(item.TargetPage);
            this.BindingContext = this.ViewModel;
        }

        private async void OnItemSelected(object sender, EventArgs e)
        {

            var layout = (BindableObject)sender;
            var planet = (Planet)layout.BindingContext;
            await Navigation.PushAsync(new PagedPlanetsDetailPage(planet));
        }

        private void OnPreviousButtonClicked(object sender, EventArgs e)
        {
            this.BindingContext = this.ViewModel = new PagedPlanetsViewModel(ViewModel.PreviousUrl);
        }
        private void OnNextButtonClicked(object sender, EventArgs e)
        {
            this.BindingContext = this.ViewModel = new PagedPlanetsViewModel(ViewModel.NextUrl);
        }

        //Call this method each time a cell from our listview appear
        //It allow us to set a different color background by using bool states (true and false).
        private void ViewCell_Appearing(object sender, EventArgs e)
        {            
            if (this.AlternedRow)
            {
                var viewCell = (ViewCell)sender;
                if (viewCell.View != null)
                {
                    viewCell.View.BackgroundColor = Color.LightGray;
                }
            }

            this.AlternedRow = !this.AlternedRow;
        }
    }
}