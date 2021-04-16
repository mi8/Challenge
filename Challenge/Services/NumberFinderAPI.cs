using Challenge.Models;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Challenge.Services
{
    class NumberFinderAPI
    {

        HttpClient client;
        NumberFinderResultBindingModel NumberFinderResultBindingModel;
        NumberFinderLocalStorage NumberFinderLocalStorage;
        NumberFinderMessage numberFinderMessage;

        public NumberFinderAPI()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.NumberFinderAPIURL}/");
            NumberFinderLocalStorage = new NumberFinderLocalStorage();
        }
        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;

        public async Task<NumberFinderMessage> AttemptFindingNumberAsync(int number)
        {

            numberFinderMessage = new NumberFinderMessage();

            if (IsConnected)
            {
                var response = await client.GetAsync(number.ToString());
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        var result = await response.Content.ReadAsStringAsync();
                        NumberFinderResultBindingModel = await Task.Run(() => JsonConvert.DeserializeObject<NumberFinderResultBindingModel>(result));
                        numberFinderMessage.Text = NumberFinderResultBindingModel.Result;
                        numberFinderMessage.ViewType = NumberFinderMessage.ViewTypeEnum.NumberFinderBiggerOrSmaller;
                        NumberFinderLocalStorage.StoreMessagesAsync(new Collection<NumberFinderMessage> { new NumberFinderMessage { Text = number.ToString(), ViewType = NumberFinderMessage.ViewTypeEnum.NumberFinderAttempt }, numberFinderMessage });
                        break;
                    case HttpStatusCode.Accepted:
                        numberFinderMessage.Text = "Congratulation! You have found the number.";
                        numberFinderMessage.ViewType = NumberFinderMessage.ViewTypeEnum.NumberFinderSuccess;
                        NumberFinderLocalStorage.RemoveAllMessagesAsync();
                        break;
                    case HttpStatusCode.ResetContent:
                        numberFinderMessage.Text = "Sorry, it is too late: the number has been reset.";
                        numberFinderMessage.ViewType = NumberFinderMessage.ViewTypeEnum.NumberFinderReset;
                        NumberFinderLocalStorage.RemoveAllMessagesAsync();
                        break;
                    case HttpStatusCode.InternalServerError:
                        numberFinderMessage.Text = "Please try again later!";
                        numberFinderMessage.ViewType = NumberFinderMessage.ViewTypeEnum.NumberFinderError;
                        break;
                    default:
                        numberFinderMessage.Text = "Please try again later!";
                        numberFinderMessage.ViewType = NumberFinderMessage.ViewTypeEnum.NumberFinderError;
                        break;
                }
            }
            else
            {
                numberFinderMessage.Text = "Please check your connection before trying again!";
                numberFinderMessage.ViewType = NumberFinderMessage.ViewTypeEnum.NumberFinderError;
            }

            return numberFinderMessage;
        }
    }
}
