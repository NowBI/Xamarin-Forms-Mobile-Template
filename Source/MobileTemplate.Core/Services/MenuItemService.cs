using System;
using System.Collections.Generic;
using MobileTemplate.Core.Pages.Landing;
using MobileTemplate.Core.Pages.ReactiveSample;
using MobileTemplate.Core.Pages.ServiceSample;
using Reactive.Bindings;
using Xamarin.Forms;

namespace MobileTemplate.Core.Services
{
    public interface IMenuItemService
    {
        IReadOnlyReactiveProperty<IEnumerable<MenuItemViewModel>> MenuItems { get; }
    }

    public class MenuItemService : IMenuItemService
    {
        private readonly IReactiveProperty<IEnumerable<MenuItemViewModel>> _menuItemsInternal;
        public IReadOnlyReactiveProperty<IEnumerable<MenuItemViewModel>> MenuItems { get; }

        public MenuItemService()
        {
            var items = new[]
            {
                new MenuItemViewModel("Home Sample", "icon.png", () => new LandingPage()),
                new MenuItemViewModel("Content Sample", "icon.png", () => new LandingPage()),
                new MenuItemViewModel("List Sample", "icon.png", () => new LandingPage()),
                new MenuItemViewModel("Shop Sample", "icon.png", () => new LandingPage()),
                new MenuItemViewModel("Service Sample", "icon.png", () => new ServiceSamplePage()),
                new MenuItemViewModel("Reactive Sample", "icon.png", () => new ReactiveSamplePage())
            };
            _menuItemsInternal = new ReactiveProperty<IEnumerable<MenuItemViewModel>>(items);
            MenuItems = _menuItemsInternal.ToReadOnlyReactiveProperty();
        }
    }

    public class MenuItemViewModel : IDisposable
    {
        public IReactiveProperty<string> ImageSource { get; }
        public IReactiveProperty<string> Title { get; }
        public Func<Page> CreatePage { get; }

        public MenuItemViewModel(string title, string imageSource, Func<Page> createPage)
        {
            Title = new ReactiveProperty<string>(title);
            ImageSource = new ReactiveProperty<string>(imageSource);
            CreatePage = createPage;
        }

        public void Dispose()
        {
            ImageSource?.Dispose();
            Title?.Dispose();
        }
    }
}
