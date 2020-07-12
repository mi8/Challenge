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
    public partial class PagedStarshipsPage : ContentPage
    {
        private PagedStarshipsViewModel ViewModel { get; set; }

        private bool AlternedRow { get; set; }
        public PagedStarshipsPage(MasterMenuItem item)
        {
            InitializeComponent();

            this.ViewModel = new PagedStarshipsViewModel(item.TargetPage);
            this.BindingContext = this.ViewModel;
        }
        private async void OnItemSelected(object sender, EventArgs e)
        {

            var layout = (BindableObject)sender;
            var starship = (Starship)layout.BindingContext;
            await Navigation.PushAsync(new PagedStarshipsDetailPage(starship));
        }

        private void OnPreviousButtonClicked(object sender, EventArgs e)
        {
            this.BindingContext = this.ViewModel = new PagedStarshipsViewModel(ViewModel.PreviousUrl);
        }
        private void OnNextButtonClicked(object sender, EventArgs e)
        {
            this.BindingContext = this.ViewModel = new PagedStarshipsViewModel(ViewModel.NextUrl);
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