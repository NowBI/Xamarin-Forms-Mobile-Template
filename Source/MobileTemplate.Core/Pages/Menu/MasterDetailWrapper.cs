using MobileTemplate.Core.Pages.Landing;
using Xamarin.Forms;

namespace MobileTemplate.Core.Pages.Menu
{
    public class MasterDetailWrapper : MasterDetailPage
    {
        public MasterDetailWrapper()
        {
            Title = "NBI Mobile Template";
            var mainMenu = new MainMenuPage();
            Master = mainMenu;
            Device.OnPlatform(() =>
            {
                mainMenu.Padding = new Thickness(0, 20, 0, 0); // Need extra top padding on iOS to make room for the status bar.
            });

            var detail = new NavigationPage(new LandingPage()); // Make sure you wrap the detail page in a Navigation Page so you can manipulate the navigation stack.
            Detail = detail;
        }
    }
}
