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
            AdjustItemCount(item, quantity);
        }

        public void RemoveItem(ShoppingItemModel item, int quantity = Int32.MaxValue)
        {
            AdjustItemCount(item, quantity * -1);
        }

        private void AdjustItemCount(ShoppingItemModel item, int quantity)
        {
            var count = 0;
            _cart.TryGetValue(item, out count);
            count += quantity;
            SetItemCount(item, count);
        }

        private void SetItemCount(ShoppingItemModel item, int quantity)
        {
            if (quantity > 0)
            {
                _cart[item] = quantity;
            }
            else
            {
                _cart.Remove(item);
            }
            TriggerUpdate();
        }
        
        public void ClearCart()
        {
            _cart.Clear();
            TriggerUpdate();
        }

        private void TriggerUpdate()
        {
            var cartClone = _cart.ToDictionary(x => x.Key, y => y.Value);
            _itemsSubject.OnNext(cartClone);
        }
    }
}
