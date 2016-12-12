using System;
using System.Collections.Generic;
using System.Linq;
using MobileTemplate.Core.Services;
using Reactive.Bindings;

namespace MobileTemplate.Core.Pages.Menu
{
    public class MainMenuViewModel : IDisposable
    {
        public IReactiveProperty<string> HeaderText { get; }
        public IReactiveProperty<string> FooterText { get; }
        public IReadOnlyReactiveProperty<IEnumerable<MainMenuItemViewModel>> MenuItems { get; }

        public MainMenuViewModel(string headerText, string footerText, IMenuItemService menuItemService)
        {
            HeaderText = new ReactiveProperty<string>(headerText);
            FooterText = new ReactiveProperty<string>(footerText);
            MenuItems = menuItemService.MenuItems.ToReadOnlyReactiveProperty(Enumerable.Empty<MainMenuItemViewModel>());
        }

        public void Dispose()
        {
            HeaderText?.Dispose();
            FooterText?.Dispose();
            MenuItems?.Dispose();
        }
    }
}
