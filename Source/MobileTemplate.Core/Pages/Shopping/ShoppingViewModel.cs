using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using MobileTemplate.Core.Services;
using MobileTemplate.Core.Services.Shopping;
using Reactive.Bindings;

namespace MobileTemplate.Core.Pages.Shopping
{
    public class ShoppingViewModel : IDisposable
    {
        public IReadOnlyReactiveProperty<IEnumerable<ShoppingItemViewModel>> ShoppingItems { get; }

        public ShoppingViewModel(IShoppingItemService shoppingItemService, INavigationService navigationService)
        {
            ShoppingItems = shoppingItemService.Inventory.Select(x => x.Select(y => new ShoppingItemViewModel(y, navigationService))).ToReadOnlyReactiveProperty(Enumerable.Empty<ShoppingItemViewModel>());
        }

        public void Dispose()
        {
            ShoppingItems?.Dispose();
        }
    }
}
