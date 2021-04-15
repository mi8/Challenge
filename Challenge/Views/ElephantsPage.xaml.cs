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
    public partial class ElephantsPage : ContentPage
    {

        ElephantsViewModel viewModel;

        public ElephantsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ElephantsViewModel();
        }

        async void OnElephantSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var elephant = (Elephant)layout.BindingContext;
            await Navigation.PushAsync(new ElephantDetailPage(new ElephantDetailViewModel(elephant)));
        }


    }
}