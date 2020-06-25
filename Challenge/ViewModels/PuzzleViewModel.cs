using System.Net.Http;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Challenge.Models;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Challenge.ViewModels
{
    public class PuzzleViewModel : BaseViewModel
    {
        public int NumberOfTry { get; set; }
        public int FoundNumber { get; set; }

        public string EndText { get; set; } = "Congratulations !";

        public bool IsRefreshing { get; set; }

        public Command FindTheNumberCommand
        {
            get
            {
                return findTheNumberCommand = new Command(() =>
                {
                    FindTheNumber();
                });
            }
        }

        private Command findTheNumberCommand;

        //public string ApiBaseAddress { get; set; }
        //public string ApiRoute { get; set; }

        public PuzzleViewModel()
        {
            Title = "Mi8 Puzzle Challenge";

            FindTheNumber();
        }



        //Fake Api :cry:
        public void FindTheNumber()
        {
            string response;

            FakeApiResult tryResult; 

            int min = 0;
            int max = 50000;
            int testNumber = 25000;


            while (true)
            {
                response = FakeApi.FakeApiRequest(testNumber);
                tryResult = JsonConvert.DeserializeObject<FakeApiResult>(response);



                if (tryResult.Result == FakeApiTryResult.Smaller.ToString())    // min.current do not change, max.current change to testNumber.current  
                {
                    max = testNumber;
                    testNumber = GetMiddle(min, max);
                    NumberOfTry = tryResult.Try;
                }
                else if (tryResult.Result == FakeApiTryResult.Bigger.ToString())    // min.current change to testNumber.current, max.current do not change
                {
                    min = testNumber;
                    testNumber = GetMiddle(min, max);
                    NumberOfTry = tryResult.Try;
                }
                else if (tryResult.Result == "Try again !")
                {
                    EndText = "the algorithm is lost...";
                    break;
                }
                else
                {
                    EndText = "Congratulations !";
                    break;
                }
            }

            FoundNumber = testNumber;
            NumberOfTry++;

            IsRefreshing = false;
        }


        private int GetMiddle(int min, int max)
        {
            return min + ((max - min) / 2);
        }

        

        //Local Api - TODO : Don't work atm
        //private void ConfigureApiAddress()
        //{
        //    //ApiBaseAddress = Device.RuntimePlatform == Device.Android ? "https://localhost:5001" : "https://localhost:5001";
        //    //ApiBaseAddress = Device.RuntimePlatform == Device.Android ? "https://10.0.2.2:5001" : "https://localhost:5001";
        //    //ApiBaseAddress = Device.RuntimePlatform == Device.Android ? "https://192.168.1.3:8080" : "https://localhost:5001";
        //    //ApiBaseAddress = Device.RuntimePlatform == Device.Android ? "https://172.17.223.161:8080" : "https://localhost:5001";
        //    ApiBaseAddress = Device.RuntimePlatform == Device.Android ? "https://169.254.80.80:8080" : "https://localhost:5001";
        //    ApiRoute = $"{ApiBaseAddress}/api/number/0";
        //}

        //private async void DebugApi()
        //{
        //    HttpClient client = new HttpClient();
        //    var response = await client.GetStringAsync(ApiRoute);
        //}
    }
}
