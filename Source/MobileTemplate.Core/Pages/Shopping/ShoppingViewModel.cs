using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using MobileTemplate.Core.Pages.Shopping.Cart;
using MobileTemplate.Core.Pages.Shopping.List;
using MobileTemplate.Core.Services;
using MobileTemplate.Core.Services.Shopping;
using Reactive.Bindings;

namespace MobileTemplate.Core.Pages.Shopping
{
    public class ShoppingViewModel : IDisposable
    {
        private readonly INavigationService _navigationService;

        public IReadOnlyReactiveProperty<string> TotalItemsLabel { get; }
        public IReadOnlyReactiveProperty<string> TotalValueLabel { get; }
        public ReactiveCommand ViewCommand { get; }
        private readonly IDisposable _viewSubscription;

        public IReadOnlyReactiveProperty<IEnumerable<ShoppingItemListViewModel>> ShoppingItems { get; }

        public ShoppingViewModel(IShoppingItemService shoppingItemService, IShoppingCartService shoppingCartService, INavigationService navigationService)
        {
            _navigationService = navigationService;

            TotalItemsLabel = shoppingCartService.TotalItems.Select(x => $"Total Items: {x}").ToReadOnlyReactiveProperty();
            TotalValueLabel = shoppingCartService.TotalValue.Select(x => $"${x:C}").ToReadOnlyReactiveProperty();
            ShoppingItems = shoppingItemService.Inventory.Select(x => x.Select(y => new ShoppingItemListViewModel(y, navigationService))).ToReadOnlyReactiveProperty(Enumerable.Empty<ShoppingItemListViewModel>());

            ViewCommand = new ReactiveCommand();
            _viewSubscription = ViewCommand.Subscribe(ViewCart);
        }

        private void ViewCart(object param)
        {
            _navigationService.Push(new ShoppingCartPage());
        }

        public void Dispose()
        {
            ShoppingItems?.Dispose();
            ViewCommand?.Dispose();
            TotalValueLabel?.Dispose();
            TotalItemsLabel?.Dispose();
            _viewSubscription?.Dispose();
        }
    }
}
