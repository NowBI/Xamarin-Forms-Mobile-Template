using System;
using System.Reactive.Linq;
using MobileTemplate.Core.Pages.Shopping.Cart;
using MobileTemplate.Core.Services;
using MobileTemplate.Core.Services.Shopping;
using Reactive.Bindings;

namespace MobileTemplate.Core.Pages.Shopping
{
    public class ShoppingBarViewModel : IDisposable
    {
        private readonly INavigationService _navigationService;

        public IReadOnlyReactiveProperty<string> TotalItemsLabel { get; }
        public IReadOnlyReactiveProperty<string> TotalValueLabel { get; }
        public ReactiveCommand ViewCommand { get; }
        private readonly IDisposable _viewSubscription;

        public ShoppingBarViewModel(IShoppingCartService shoppingCartService, INavigationService navigationService)
        {
            _navigationService = navigationService;

            TotalItemsLabel = shoppingCartService.TotalItems.Select(x => $"Total Items: {x}").ToReadOnlyReactiveProperty();
            TotalValueLabel = shoppingCartService.TotalValue.Select(x => $"{x:C}").ToReadOnlyReactiveProperty();

            ViewCommand = new ReactiveCommand();
            _viewSubscription = ViewCommand.Subscribe(ViewCart);
        }

        private void ViewCart(object param)
        {
            _navigationService.Push(new ShoppingCartPage());
        }

        public void Dispose()
        {
            ViewCommand?.Dispose();
            TotalValueLabel?.Dispose();
            TotalItemsLabel?.Dispose();
            _viewSubscription?.Dispose();
        }
    }
}
