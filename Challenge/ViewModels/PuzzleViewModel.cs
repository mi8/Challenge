using System.Net.Http;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Challenge.Models;
using Newtonsoft.Json;
using System;

namespace Challenge.ViewModels
{
    public class PuzzleViewModel : BaseViewModel
    {
        public int NumberOfTry { get; set; }
        public int FoundNumber { get; set; }

        public ICommand FindTheNumberCommand { get; set; }

        //public string ApiBaseAddress { get; set; }
        //public string ApiRoute { get; set; }

        public PuzzleViewModel()
        {
            Title = "Puzzle";
            FindTheNumberCommand = new Command(() => FindTheNumber());

            FindTheNumber();
        }



        //Fake Api :cry:
        private void FindTheNumber()
        {
            string response;

            FakeApiResult tryResult = new FakeApiResult(0, "start");

            int startingMin = 0;
            int startingMax = 50000;

            Dual min = new Dual(0, 0);
            Dual max = new Dual(50000, 50000);
            Dual testNumber = new Dual(25000, 25000);


            while (tryResult.Result != FakeApiTryResult.Winner.ToString())
            {
                response = FakeApi.FakeApiRequest(testNumber.Current);
                tryResult = JsonConvert.DeserializeObject<FakeApiResult>(response);

                

                if (tryResult.Result == FakeApiTryResult.Smaller.ToString())    // min.current do not change, max.current change to testNumber.current  
                {
                    max.Current = testNumber.Current;
                    testNumber.Last = testNumber.Current;
                    testNumber.Current = GetMiddle(min.Current, max.Current);
                    NumberOfTry = tryResult.Try;
                }
                else if (tryResult.Result == FakeApiTryResult.Bigger.ToString())    // min.current change to testNumber.current, max.current do not change
                {
                    min.Current = testNumber.Current;
                    testNumber.Last = testNumber.Current;
                    testNumber.Current = GetMiddle(min.Current, max.Current);
                    NumberOfTry = tryResult.Try;
                }
                else
                {
                    break;
                }
            }

            FoundNumber = testNumber.Current;
            NumberOfTry++;
        }


        private int GetMiddle(int min, int max)
        {
            return min + ((max - min) / 2);
        }

        private class Dual
        {
            public Dual(int current, int last)
            {
                Current = current;
                Last = last;
            }

            public int Current { get; set; }
            public int Last { get; set; }
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
