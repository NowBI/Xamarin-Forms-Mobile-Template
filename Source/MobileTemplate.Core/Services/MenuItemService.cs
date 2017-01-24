using System.Collections.Generic;
using MobileTemplate.Core.Model.Menu;
using MobileTemplate.Core.Pages.AssetSample;
using MobileTemplate.Core.Pages.CopySample;
using MobileTemplate.Core.Pages.FormSample;
using MobileTemplate.Core.Pages.Landing;
using MobileTemplate.Core.Pages.ReactiveSample;
using MobileTemplate.Core.Pages.RendererSample;
using MobileTemplate.Core.Pages.ServiceSample;
using MobileTemplate.Core.Pages.Shopping.Cart;
using MobileTemplate.Core.Pages.Shopping.Grid;
using MobileTemplate.Core.Pages.Shopping.List;
using MobileTemplate.Core.Pages.ThemeSample;
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
                new MenuItemModel("Home Sample", "Icon.png", () => new LandingPage()),
                new MenuItemModel("Copy Sample","Icon.png", ()=>new CopySamplePage()),
                new MenuItemModel("Form Sample", "Icon.png", () => new FormSamplePage()),
                new MenuItemModel("Shopping List Sample", "Icon.png", () => new ShoppingListPage()),
                new MenuItemModel("Shopping Grid Sample", "Icon.png", () => new ShoppingGridPage()),
                new MenuItemModel("Shopping Cart Sample", "Icon.png", () => new ShoppingCartPage()),
                new MenuItemModel("Light Theme Sample", "Icon.png", () => new LightThemeSamplePage()),
                new MenuItemModel("Dark Theme Sample", "Icon.png", () => new DarkThemeSamplePage()),
                new MenuItemModel("Custom Theme Sample", "Icon.png", () => new CustomThemeSamplePage()),
                new MenuItemModel("Service Sample", "Icon.png", () => new ServiceSamplePage()),
                new MenuItemModel("Assets Sample", "Icon.png", () => new AssetSamplePage()),
                new MenuItemModel("Custom Renderer Sample", "Icon.png", () => new RendererSamplePage()),
                new MenuItemModel("Reactive Sample", "Icon.png", () => new ReactiveSamplePage())
            };
            _menuItemsInternal = new ReactiveProperty<IEnumerable<MenuItemModel>>(items);
            MenuItems = _menuItemsInternal.ToReadOnlyReactiveProperty();
        }
    }
}
