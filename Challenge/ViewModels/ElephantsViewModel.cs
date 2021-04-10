using Challenge.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Challenge.ViewModels
{
    class ElephantsViewModel : BaseViewModel
    {
        public ObservableCollection<Elephant> Elephants { get; set; }
        public Command LoadElephantsCommand { get; set; }

        public ElephantsViewModel()
        {
            Title = "Browse elephants";
            Elephants = new ObservableCollection<Elephant>();
            LoadElephantsCommand = new Command(async () => await ExecuteLoadElephantsCommand());
            ExecuteLoadElephantsCommand();
        }

        async Task ExecuteLoadElephantsCommand()
        {
            IsBusy = true;

            try
            {
                Elephants.Clear();
                var elephants = await Data.GetElephantsAsync(true);
                foreach (var elephant in elephants)
                {
                    if(elephant.Name != null)
                    {
                        elephant.Image = (elephant.Image != null && elephant.Image != "") ? elephant.Image : "elephant_default";
                        Elephants.Add(elephant);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
