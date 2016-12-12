using Autofac;
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

            var menuItemService = IoC.Container.Resolve<IMenuItemService>();
            BindingContext = new MainMenuViewModel("Main Menu", "Copyright 2016 NBI", menuItemService);
        }
    }
}
