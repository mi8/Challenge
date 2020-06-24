using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Challenge.Models
{
    public static class FakeApi     // source : Challenge.localAPI/Controllers/NumberController.cs
    {
        static int theNumber;
        static int tryCount;
        

        public static string FakeApiRequest(int number)
        {
            if (theNumber == 0)
                theNumber = new Random().Next(1, 50_000);

            if (tryCount == 20)
            {
                ResetNumbers();
                //return ConvertResultToJson(new FakeApiResult { Result = "Try again !", Try = ++tryCount });
                return ConvertResultToJson(new FakeApiResult (++tryCount, "Try again !"));
            }

            if (theNumber < number)
            {
                return ConvertResultToJson(new FakeApiResult (++tryCount, FakeApiTryResult.Smaller.ToString()));
            }
            else if (theNumber > number)
            {
                return ConvertResultToJson(new FakeApiResult (++tryCount, FakeApiTryResult.Bigger.ToString()));
            }
            else
            {
                ResetNumbers();
                return ConvertResultToJson(new FakeApiResult (++tryCount, FakeApiTryResult.Winner.ToString()));
            }
        }

        private static void ResetNumbers()
        {
            theNumber = tryCount = 0;
        }

        private static string ConvertResultToJson(FakeApiResult result)
        {
            return JsonConvert.SerializeObject(result);
        }
    }
}
