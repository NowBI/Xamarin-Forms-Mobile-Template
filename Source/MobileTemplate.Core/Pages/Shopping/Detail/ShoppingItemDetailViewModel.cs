using System;
using MobileTemplate.Core.Model.Shopping;
using MobileTemplate.Core.Services;
using MobileTemplate.Core.Services.Shopping;
using Reactive.Bindings;

namespace MobileTemplate.Core.Pages.Shopping.Detail
{
    public class ShoppingItemDetailViewModel : ShoppingItemViewModel
    {
        public ReactiveCommand AddToCartCommand { get; }
        private readonly IDisposable _addToCartSubscription;

        protected readonly IShoppingCartService ShoppingCartService;

        public ShoppingItemDetailViewModel(ShoppingItemModel source, IShoppingCartService shoppingCartService, INavigationService navigationService) : base(source, navigationService)
        {
            ShoppingCartService = shoppingCartService;

            AddToCartCommand = new ReactiveCommand();
            _addToCartSubscription = AddToCartCommand.Subscribe(AddToCart);
        }

        private void AddToCart(object parameter)
        {
            ShoppingCartService.AddItem(Item);
        }

        public override void Dispose()
        {
            base.Dispose();
            AddToCartCommand?.Dispose();
            _addToCartSubscription?.Dispose();
        }
    }
}
