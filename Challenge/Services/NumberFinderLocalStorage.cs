using Challenge.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Services
{
    class NumberFinderLocalStorage
    {
        private SQLiteAsyncConnection localDbAsync;
        private SQLiteConnection localDb;
        private string localDBPath;

        public NumberFinderLocalStorage()
        {
            localDBPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), App.LOCAL_DB_NAME);
            localDbAsync = new SQLiteAsyncConnection(localDBPath);
            localDb = new SQLiteConnection(localDBPath);
            localDbAsync.CreateTableAsync<NumberFinderMessage>();
        }

        public async void StoreMessagesAsync(IEnumerable<NumberFinderMessage> numberFinderMessages)
        {
            try
            {
                await localDbAsync.InsertAllAsync(numberFinderMessages);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public  IEnumerable<NumberFinderMessage> GetAllMessages()
        {
            try
            {
                return localDb.Table<NumberFinderMessage>().ToList();
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return new Collection<NumberFinderMessage>();
            }
        }

        public async void RemoveAllMessagesAsync()
        {
            try
            {
                await localDbAsync.DeleteAllAsync<NumberFinderMessage>();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


    }
}
