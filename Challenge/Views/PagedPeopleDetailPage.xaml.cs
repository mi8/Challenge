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
    public partial class PagedPeopleDetailPage : ContentPage
    {
        public PagedPeopleDetailPage()
        {
            InitializeComponent();
        }

        public PagedPeopleDetailPage(People people)
        {
            InitializeComponent();
            this.BindingContext = people;
        }
    }
}