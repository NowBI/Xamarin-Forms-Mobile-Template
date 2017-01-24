using System;
using Autofac;
using MobileTemplate.Core.Extensions;
using MobileTemplate.Core.Services;
using Xamarin.Forms;

namespace MobileTemplate.Core.Pages.Menu
{
    public class MainMenuPage : ContentPage, IDisposable
    {
        public MainMenuPage()
        {
            Title = "Main Menu Sample";
            Content = new MainMenuView();

            var menuItemService = IoC.Container.Resolve<IMenuItemService>();
            var navigationService = IoC.Container.Resolve<INavigationService>();
            BindingContext = new MainMenuViewModel("Main Menu", "\u00A9 2017 Now Business Intelligence, Inc.", menuItemService, navigationService);
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
