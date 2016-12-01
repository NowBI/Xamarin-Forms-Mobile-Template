using Autofac;
using MobileTemplate.Core.Pages.Landing;
using MobileTemplate.Core.Services;
using Xamarin.Forms;

namespace MobileTemplate.Core.Pages.Menu
{
    public class MainMenuPage : ContentPage
    {
        public MainMenuPage()
        {
            Title = "Main Menu Sample";
            Content = new MainMenuView();

            var navigationService = IoC.Container.Resolve<INavigationService>();
            BindingContext = new MainMenuViewModel("Main Menu", "Copyright 2016 NBI", new[]
            {
                new MainMenuItemViewModel("Home Sample", "Icon.png", (o) => { navigationService.ResetStack(new LandingPage()); }),
                new MainMenuItemViewModel("Content Sample", "Icon.png", (o) => { navigationService.ResetStack(new LandingPage()); }),
                new MainMenuItemViewModel("List Sample", "Icon.png", (o) => { navigationService.ResetStack(new LandingPage()); }),
                new MainMenuItemViewModel("Shop Sample", "Icon.png", (o) => { navigationService.ResetStack(new LandingPage()); }),
                new MainMenuItemViewModel("Service Sample", "Icon.png", (o) => { navigationService.ResetStack(new LandingPage()); }),
                new MainMenuItemViewModel("Reactive Sample", "Icon.png", (o) => { navigationService.ResetStack(new LandingPage()); })
            });
        }
    }
}
