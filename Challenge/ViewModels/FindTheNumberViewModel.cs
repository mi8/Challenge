using Challenge.Models;
using Challenge.Services;
using Challenge.TemplateSelector;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.ViewModels
{
    class FindTheNumberViewModel : BaseViewModel
    {
        public ObservableCollection<NumberFinderMessage> Messages { get; set; }
        private  NumberFinderAPI numberFinderAPI;
        private NumberFinderLocalStorage numberFinderLocalStorage;

        public FindTheNumberViewModel()
        {
            Title = "Find the number";
            numberFinderAPI = new NumberFinderAPI();
            numberFinderLocalStorage = new NumberFinderLocalStorage();
            var allStoredMessages = numberFinderLocalStorage.GetAllMessages();
            Messages = new ObservableCollection<NumberFinderMessage>(allStoredMessages);
        }

        public async Task SubmitNumber(int number)
        {
            NumberFinderMessage numberFinderAttempt = new NumberFinderMessage { Text = number.ToString() , ViewType = NumberFinderMessage.ViewTypeEnum.NumberFinderAttempt };
            Messages.Add(numberFinderAttempt);
            NumberFinderMessage numberFinderResponse = await numberFinderAPI.AttemptFindingNumberAsync(number);
            Messages.Add(numberFinderResponse);
            Console.WriteLine("supertest submit number");
        }


    }
}
