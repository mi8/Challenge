using Challenge.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Challenge.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ElephantDetailPage : ContentPage
    {
        ElephantDetailViewModel viewModel;
        public ElephantDetailPage(ElephantDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;

            if (!(viewModel.Elephant.Image is null) && viewModel.Elephant.Image != "")
            {
                elephant_image.Source = viewModel.Elephant.Image; 
            }
            if (!(viewModel.Elephant.Name is null) && viewModel.Elephant.Name != "")
            {
                elephant_name_label.Text = $"Name : {viewModel.Elephant.Name}";
            }
            if (!(viewModel.Elephant.Species is null) && viewModel.Elephant.Species != "")
            {
                elephant_species_label.Text = $"Species : {viewModel.Elephant.Species}";
            }
            if (!(viewModel.Elephant.Dob is null) && viewModel.Elephant.Dob != "")
            {
                elephant_birth_label.Text = $"Birth : {viewModel.Elephant.Dob}";
            }
            if (!(viewModel.Elephant.Dod is null) && viewModel.Elephant.Dod != "")
            {
                elephant_death_label.Text = $"Death : {viewModel.Elephant.Dod}";
            }
            if (!(viewModel.Elephant.Affiliation is null) && viewModel.Elephant.Affiliation != "")
            {
                elephant_affiliation_label.Text = $"Affiliation : {viewModel.Elephant.Affiliation}";
            }
            if (!(viewModel.Elephant.Note is null) && viewModel.Elephant.Note != "")
            {
                elephant_comment_label.Text = $"Comment : {viewModel.Elephant.Note}";
            }
            if (!(viewModel.Elephant.WikiLink is null) && viewModel.Elephant.WikiLink != "")
            {
                elephant_link_label.Text = "More information";
            }
        }

       public async void OnButtonClicked(object sender, EventArgs args)
        {
            Console.WriteLine("supertest click");
            await Browser.OpenAsync(viewModel.Elephant.WikiLink, BrowserLaunchMode.SystemPreferred);
        }

    }
}