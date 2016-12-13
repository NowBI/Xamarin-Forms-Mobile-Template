using System;
using MobileTemplate.Core.Model.Shopping;
using MobileTemplate.Core.Pages.Shopping.Detail;
using MobileTemplate.Core.Services;
using Reactive.Bindings;

namespace MobileTemplate.Core.Pages.Shopping
{
    public class ShoppingItemViewModel : IDisposable
    {
        public IReadOnlyReactiveProperty<string> Name { get; }
        public IReadOnlyReactiveProperty<string> Description { get; }
        public IReadOnlyReactiveProperty<string> Icon { get; }
        public IReadOnlyReactiveProperty<string> PriceLabel { get; }
        public ShoppingItemModel Item { get; }

        public ShoppingItemViewModel(ShoppingItemModel source)
        {
            Name = new ReactiveProperty<string>(source.Name);
            Icon = new ReactiveProperty<string>(source.Icon);
            Description = new ReactiveProperty<string>(source.Description);
            PriceLabel = new ReactiveProperty<string>($"{source.Price:C}");
        }
        
        public void Dispose()
        {
            Name?.Dispose();
            Icon?.Dispose();
            Description?.Dispose();
            PriceLabel?.Dispose();
        }
    }
}
