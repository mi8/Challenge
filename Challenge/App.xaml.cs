using Challenge.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Challenge
{
    public partial class App : Application
    {
        //TODO: Replace with *.azurewebsites.net url after deploying backend to Azure
        //To debug on Android emulators run the web backend against .NET Core not IIS
        //If using other emulators besides stock Google images you may need to adjust the IP address
        
        public static string ElephantAPIURL = "https://elephant-api.herokuapp.com";
        public static string NumberFinderAPIURL = "https://numberfinderapi.azurewebsites.net/api/TheNumber";
        public const string LOCAL_DB_NAME = "ChallengeMI8.db";


        public App()
        {
            InitializeComponent();

            DependencyService.Register<ElephantAPI>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
