using System.Collections.Generic;
using MobileTemplate.Core.Pages.Landing;
using MobileTemplate.Core.Pages.Menu;
using MobileTemplate.Core.Pages.ReactiveSample;
using MobileTemplate.Core.Pages.ServiceSample;
using Reactive.Bindings;

namespace MobileTemplate.Core.Services
{
    public interface IMenuItemService
    {
        IReadOnlyReactiveProperty<IEnumerable<MainMenuItemViewModel>> MenuItems { get; }
    }

    public class MenuItemService : IMenuItemService
    {
        private readonly IReactiveProperty<IEnumerable<MainMenuItemViewModel>> _menuItemsInternal;
        public IReadOnlyReactiveProperty<IEnumerable<MainMenuItemViewModel>> MenuItems { get; }

        public MenuItemService(INavigationService navigationService)
        {
            var items = new[]
            {
                new MainMenuItemViewModel("Home Sample", "icon.png", (o) => { navigationService.ResetStack(new LandingPage()); }),
                new MainMenuItemViewModel("Content Sample", "icon.png", (o) => { navigationService.ResetStack(new LandingPage()); }),
                new MainMenuItemViewModel("List Sample", "icon.png", (o) => { navigationService.ResetStack(new LandingPage()); }),
                new MainMenuItemViewModel("Shop Sample", "icon.png", (o) => { navigationService.ResetStack(new LandingPage()); }),
                new MainMenuItemViewModel("Service Sample", "icon.png", (o) => { navigationService.ResetStack(new ServiceSamplePage()); }),
                new MainMenuItemViewModel("Reactive Sample", "icon.png", (o) => { navigationService.ResetStack(new ReactiveSamplePage()); })
            };
            _menuItemsInternal = new ReactiveProperty<IEnumerable<MainMenuItemViewModel>>(items);
             MenuItems = _menuItemsInternal.ToReadOnlyReactiveProperty();
        }
    }
}
