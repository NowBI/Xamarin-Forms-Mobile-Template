using Autofac;
using MobileTemplate.Core.Pages.Landing;
using MobileTemplate.Core.Services;
using Xamarin.Forms;

namespace MobileTemplate.Core.Pages.Menu
{
    public class MasterDetailWrapper : MasterDetailPage
    {
        public MasterDetailWrapper()
        {
            var navigationService = IoC.Container.Resolve<INavigationService>();
            Title = "NBI Mobile Template";
            var mainMenu = new MainMenuPage()
            {
                BindingContext = new MainMenuViewModel("Main Menu", "Copyright 2016 NBI", new[]
                {
                    new MainMenuItemViewModel("Home Sample","Icon.png",(o)=> { navigationService.ResetStack(new LandingPage()); }),
                    new MainMenuItemViewModel("Content Sample","Icon.png",(o)=> { navigationService.ResetStack(new LandingPage()); }),
                    new MainMenuItemViewModel("List Sample","Icon.png",(o)=> { navigationService.ResetStack(new LandingPage()); }),
                    new MainMenuItemViewModel("Shop Sample","Icon.png",(o)=> { navigationService.ResetStack(new LandingPage()); }),
                    new MainMenuItemViewModel("Service Sample","Icon.png",(o)=> { navigationService.ResetStack(new LandingPage()); }),
                    new MainMenuItemViewModel("Reactive Sample","Icon.png",(o)=> { navigationService.ResetStack(new LandingPage()); })
                })
            };
            Master = mainMenu;

            var detail = new NavigationPage(new LandingPage()); // Make sure you wrap the detail page in a Navigation Page so you can manipulate the navigation stack.
            Detail = detail;
        }
    }
}
