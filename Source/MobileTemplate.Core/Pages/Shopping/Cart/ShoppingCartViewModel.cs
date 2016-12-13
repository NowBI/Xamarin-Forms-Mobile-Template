using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using MobileTemplate.Core.Services;
using MobileTemplate.Core.Services.Shopping;
using Reactive.Bindings;

namespace MobileTemplate.Core.Pages.Shopping.Cart
{
    public class ShoppingCartViewModel : IDisposable
    {
        private readonly INavigationService _navigationService;

        public IReadOnlyReactiveProperty<string> TotalItemsLabel { get; }
        public IReadOnlyReactiveProperty<string> TotalValueLabel { get; }
        public IReadOnlyReactiveProperty<IEnumerable<ShoppingCartItemViewModel>> CartItems { get; }
        public ReactiveCommand CheckoutCommand { get; }
        private readonly IDisposable _checkoutSubscription;

        public ShoppingCartViewModel(IShoppingCartService shoppingCartService, INavigationService navigationService)
        {
            _navigationService = navigationService;

            TotalItemsLabel = shoppingCartService.TotalItems.Select(x => $"Total Items: {x}").ToReadOnlyReactiveProperty();
            TotalValueLabel = shoppingCartService.TotalValue.Select(x => $"Total Cost: {x:C}").ToReadOnlyReactiveProperty();
            CartItems = shoppingCartService.Items.Select(x => x.Select(y => new ShoppingCartItemViewModel(y.Key, y.Value, _navigationService))).ToReadOnlyReactiveProperty(Enumerable.Empty<ShoppingCartItemViewModel>());

            CheckoutCommand = new ReactiveCommand();
            _checkoutSubscription = CheckoutCommand.Subscribe(Checkout);
        }

        private void Checkout(object param)
        {
            _navigationService.Push(new ShoppingCartPage());
        }

        public void Dispose()
        {
            CartItems?.Dispose();
            CheckoutCommand?.Dispose();
            TotalValueLabel?.Dispose();
            TotalItemsLabel?.Dispose();
            _checkoutSubscription?.Dispose();
        }
    }
}
