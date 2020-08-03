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
    public partial class MasterPage : MasterDetailPage
    {
        public MasterViewModel ViewModel { get; set; }
        public MasterPage()
        {
            InitializeComponent();
            this.ViewModel = new MasterViewModel();
            this.BindingContext = this.ViewModel;
            Detail = new NavigationPage(new DetailPage());
        }

        private void MenuItems_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var masterMenuItem = (MasterMenuItem)e.SelectedItem;
            Type selectedPage = masterMenuItem.TargetType;
            Detail = new NavigationPage((Page)Activator.CreateInstance(selectedPage, masterMenuItem));
            IsPresented = false;
        }

        private void OnMenuTapped(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new DetailPage());
            IsPresented = false;
        }
    }
}