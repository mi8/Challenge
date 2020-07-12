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
    public partial class DetailPage : ContentPage
    {
        private DetailViewModel ViewModel { get; set; }
        public DetailPage()
        {
            InitializeComponent();
            this.BindingContext = this.ViewModel = new DetailViewModel();
        }
    }
}