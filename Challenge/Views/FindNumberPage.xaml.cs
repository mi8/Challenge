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
    public partial class FindNumberPage : ContentPage
    {
        public FindNumberViewModel ViewModel { get; set; }
        public FindNumberPage()
        {
            InitializeComponent();
            this.ViewModel = new FindNumberViewModel();
            this.BindingContext = this.ViewModel;
        }

    }
}