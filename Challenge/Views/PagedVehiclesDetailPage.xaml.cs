using Challenge.Models;
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
    public partial class PagedVehiclesDetailPage : ContentPage
    {
        public PagedVehiclesDetailPage()
        {
            InitializeComponent();
        }

        public PagedVehiclesDetailPage(Vehicle vehicle)
        {
            InitializeComponent();
            this.BindingContext = vehicle;
        }
    }
}