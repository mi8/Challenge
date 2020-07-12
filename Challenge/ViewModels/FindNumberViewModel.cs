using Challenge.Models;
using Challenge.Services;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Challenge.ViewModels
{
    public class FindNumberViewModel : BaseViewModel
    {        
        public Number Number { get; set; }

        public int GoodNumber { get; set; }
        public Command RunFindNumber { get; set; }

        private int min = 1;
        private int max = 50000;        

        public FindNumberViewModel()
        {
            Title = "Find Number";
            RunFindNumber = new Command(() => FindTheNumber());            
        }

        //Find the number generated
        //Each time we call the API, we put a number into min if it is bigger, max if it is smaller
        //Like this we reduce the gap between min and max
        //By dividing by 2, we can find each time the number under 16 tries. It allow us to climb the max number to 2^16 = 65536.
        
        public void FindTheNumber()
        {
            int numberToCheck;
            bool isNumberFind = true;
            do
            {
                numberToCheck = (min + max) / 2;
                Number = ConnectToApi.GetResultFromNumber(numberToCheck).Result;
                if(Number.Result == "Smaller")
                {
                    max = numberToCheck;                    
                }
                else if (Number.Result == "Bigger")
                {
                    min = numberToCheck;
                }
                else
                {
                    isNumberFind = false;
                    GoodNumber = numberToCheck;
                }
            }
            while (isNumberFind);            
        }
    }
}
