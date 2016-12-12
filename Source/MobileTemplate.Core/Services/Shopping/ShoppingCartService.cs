using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using MobileTemplate.Core.Model.Shopping;
using Reactive.Bindings;

namespace MobileTemplate.Core.Services.Shopping
{
    public interface IShoppingCartService
    {
        void AddItem(ShoppingItemModel item, int quantity = 1);
        void RemoveItem(ShoppingItemModel item, int quantity = Int32.MaxValue);
        void ClearCart();

        IReadOnlyReactiveProperty<IDictionary<ShoppingItemModel, int>> Items { get; }
        IReadOnlyReactiveProperty<int> TotalItems { get; }
        IReadOnlyReactiveProperty<double> TotalValue { get; }
    }

    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IDictionary<ShoppingItemModel, int> _cart;
        private readonly ISubject<IDictionary<ShoppingItemModel, int>> _itemsSubject;

        public IReadOnlyReactiveProperty<IDictionary<ShoppingItemModel, int>> Items { get; }
        public IReadOnlyReactiveProperty<int> TotalItems { get; }
        public IReadOnlyReactiveProperty<double> TotalValue { get; }

        public ShoppingCartService()
        {
            _cart = new Dictionary<ShoppingItemModel, int>();
            _itemsSubject = new Subject<IDictionary<ShoppingItemModel, int>>();

            Items = _itemsSubject.ToReadOnlyReactiveProperty(new Dictionary<ShoppingItemModel, int>());
            TotalItems = Items.Select(x => x.Sum(y => y.Value)).ToReadOnlyReactiveProperty();
            TotalValue = Items.Select(x => x.Sum(y => y.Key.Price * y.Value)).ToReadOnlyReactiveProperty();
        }

        public void AddItem(ShoppingItemModel item, int quantity = 1)
        {
            AdjustItem(item, quantity);
        }

        public void RemoveItem(ShoppingItemModel item, int quantity = Int32.MaxValue)
        {
            AdjustItem(item, quantity * -1);
        }

        private void AdjustItem(ShoppingItemModel item, int quantity)
        {
            var count = 0;
            _cart.TryGetValue(item, out count);
            count += quantity;
            if (count > 0)
            {
                _cart[item] = count;
            }
            else
            {
                _cart.Remove(item);
            }
            _itemsSubject.OnNext(_cart);
        }

        public void ClearCart()
        {
            _cart.Clear();
            _itemsSubject.OnNext(_cart);
        }
    }
}
