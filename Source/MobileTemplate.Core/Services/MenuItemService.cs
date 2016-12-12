using System.Collections.Generic;
using MobileTemplate.Core.Model.Menu;
using MobileTemplate.Core.Pages.Landing;
using MobileTemplate.Core.Pages.ReactiveSample;
using MobileTemplate.Core.Pages.ServiceSample;
using Reactive.Bindings;

namespace MobileTemplate.Core.Services
{
    public interface IMenuItemService
    {
        IReadOnlyReactiveProperty<IEnumerable<MenuItemModel>> MenuItems { get; }
    }

    public class MenuItemService : IMenuItemService
    {
        private readonly IReactiveProperty<IEnumerable<MenuItemModel>> _menuItemsInternal;
        public IReadOnlyReactiveProperty<IEnumerable<MenuItemModel>> MenuItems { get; }

        public MenuItemService()
        {
            var items = new[]
            {
                new MenuItemModel("Home Sample", "icon.png", () => new LandingPage()),
                new MenuItemModel("Content Sample", "icon.png", () => new LandingPage()),
                new MenuItemModel("List Sample", "icon.png", () => new LandingPage()),
                new MenuItemModel("Shop Sample", "icon.png", () => new LandingPage()),
                new MenuItemModel("Service Sample", "icon.png", () => new ServiceSamplePage()),
                new MenuItemModel("Reactive Sample", "icon.png", () => new ReactiveSamplePage())
            };
            _menuItemsInternal = new ReactiveProperty<IEnumerable<MenuItemModel>>(items);
            MenuItems = _menuItemsInternal.ToReadOnlyReactiveProperty();
        }
    }
}
