using MobileTemplate.Core.Pages.Menu;
using Xamarin.Forms;

namespace MobileTemplate.Core
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            MainPage = new MasterDetailWrapper();

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
