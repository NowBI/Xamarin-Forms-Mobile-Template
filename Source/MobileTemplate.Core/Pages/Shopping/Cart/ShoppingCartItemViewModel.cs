using System.Reactive.Linq;
using MobileTemplate.Core.Model.Shopping;
using MobileTemplate.Core.Services;
using Reactive.Bindings;

namespace MobileTemplate.Core.Pages.Shopping.Cart
{
    public class ShoppingCartItemViewModel : ShoppingItemViewModel
    {
        public IReadOnlyReactiveProperty<int> Count { get; }
        public IReadOnlyReactiveProperty<string> CountAndPriceLabel { get; }

        public ShoppingCartItemViewModel(ShoppingItemModel source, int count, INavigationService navigationService) : base(source, navigationService)
        {
            Count = new ReactiveProperty<int>(count);
            CountAndPriceLabel = Count.CombineLatest(PriceLabel, (cnt, pce) => $"{cnt}x @ {pce} ea.").ToReadOnlyReactiveProperty();
        }
    }
}
