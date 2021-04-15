using Challenge.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Challenge.ViewModels
{
    public class ElephantDetailViewModel : BaseViewModel
    {
        public Elephant Elephant { get; }
        public ElephantDetailViewModel(Elephant elephant)
        {
            this.Elephant = elephant;
        }
    }
}
