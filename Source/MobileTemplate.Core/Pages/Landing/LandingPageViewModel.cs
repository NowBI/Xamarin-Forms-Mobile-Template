using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using MobileTemplate.Core.Services;
using Reactive.Bindings;

namespace MobileTemplate.Core.Pages.Landing
{
    public class LandingPageViewModel
    {
        public IReadOnlyReactiveProperty<string> Image { get; }
        public IReadOnlyReactiveProperty<string> Text { get; }
        public IReadOnlyReactiveProperty<IEnumerable<LandingMenuItemViewModel>> MenuItems { get; }

        public LandingPageViewModel(string text, string image, IMenuItemService menuItemService, INavigationService navigationService)
        {
            Text = new ReactiveProperty<string>(text);
            Image = new ReactiveProperty<string>(image);
            MenuItems = menuItemService.MenuItems.Select(x => 
                x.Select(y => new LandingMenuItemViewModel(y, navigationService))
            ).ToReadOnlyReactiveProperty(Enumerable.Empty<LandingMenuItemViewModel>());
        }
    }
}
