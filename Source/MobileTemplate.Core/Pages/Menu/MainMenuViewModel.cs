using System;
using System.Collections.Generic;
using Reactive.Bindings;

namespace MobileTemplate.Core.Pages.Menu
{
    public class MainMenuViewModel : IDisposable
    {
        public IReactiveProperty<string> HeaderText { get; }
        public IReactiveProperty<string> FooterText { get; }
        public IReactiveProperty<IEnumerable<MainMenuItemViewModel>> MenuItems { get; }

        public MainMenuViewModel(string headerText, string footerText, IEnumerable<MainMenuItemViewModel> menuItems)
        {
            HeaderText = new ReactiveProperty<string>(headerText);
            FooterText = new ReactiveProperty<string>(footerText);
            MenuItems = new ReactiveProperty<IEnumerable<MainMenuItemViewModel>>(menuItems);
        }

        public void Dispose()
        {
            HeaderText?.Dispose();
            FooterText?.Dispose();
            MenuItems?.Dispose();
        }
    }
}
