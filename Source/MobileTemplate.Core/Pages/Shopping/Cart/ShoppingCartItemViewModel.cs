using System;
using System.Reactive.Linq;
using MobileTemplate.Core.Model.Shopping;
using MobileTemplate.Core.Services;
using MobileTemplate.Core.Services.Shopping;
using Reactive.Bindings;

namespace MobileTemplate.Core.Pages.Shopping.Cart
{
    public class ShoppingCartItemViewModel : ShoppingItemViewModel
    {
        public IReadOnlyReactiveProperty<int> Count { get; }
        public IReadOnlyReactiveProperty<string> CountAndPriceLabel { get; }

        private readonly IShoppingCartService _shoppingCartService;
        public ReactiveCommand RemoveCommand { get; }
        private readonly IDisposable _removeSubscription;

        public ShoppingCartItemViewModel(ShoppingItemModel source, int count, IShoppingCartService shoppingCartService, INavigationService navigationService) : base(source, navigationService)
        {
            _shoppingCartService = shoppingCartService;
            Count = new ReactiveProperty<int>(count);
            CountAndPriceLabel = Count.CombineLatest(PriceLabel, (cnt, pce) => $"{cnt}x @ {pce} ea.").ToReadOnlyReactiveProperty();

            RemoveCommand = new ReactiveCommand();
            _removeSubscription = RemoveCommand.Subscribe(RemoveItem);
        }

        private void RemoveItem(object parameter)
        {
            _shoppingCartService.RemoveItem(Item);
        }

        public override void Dispose()
        {
            base.Dispose();
            Count?.Dispose();
            CountAndPriceLabel?.Dispose();
            RemoveCommand?.Dispose();
            _removeSubscription?.Dispose();
        }
    }
}
