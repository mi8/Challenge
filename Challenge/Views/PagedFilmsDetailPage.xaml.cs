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
    public partial class PagedFilmsDetailPage : ContentPage
    {        
        public PagedFilmsDetailPage()
        {
            InitializeComponent();
        }

        public PagedFilmsDetailPage(Film film)
        {
            InitializeComponent();
            this.BindingContext = film;
        }
    }
}