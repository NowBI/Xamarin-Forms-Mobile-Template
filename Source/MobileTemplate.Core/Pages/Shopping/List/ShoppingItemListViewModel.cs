using System;
using MobileTemplate.Core.Model.Shopping;
using MobileTemplate.Core.Pages.Shopping.Detail;
using MobileTemplate.Core.Services;
using Reactive.Bindings;

namespace MobileTemplate.Core.Pages.Shopping.List
{
    public class ShoppingItemListViewModel : IDisposable
    {
        public IReadOnlyReactiveProperty<string> Name { get; }
        public IReadOnlyReactiveProperty<string> Icon { get; }
        public IReadOnlyReactiveProperty<string> PriceLabel { get; }
        public ReactiveCommand ViewDetails { get; }
        private readonly IDisposable _viewDetailsSubscription;

        private readonly INavigationService _navigationService;
        private readonly ShoppingItemModel _item;

        public ShoppingItemListViewModel(ShoppingItemModel source, INavigationService navigationService)
        {
            Name = new ReactiveProperty<string>(source.Name);
            Icon = new ReactiveProperty<string>(source.Icon);
            PriceLabel = new ReactiveProperty<string>($"${source.Price:C}");
            ViewDetails = new ReactiveCommand();
            _viewDetailsSubscription = ViewDetails.Subscribe(OpenDetailPage);
            _navigationService = navigationService;
        }

        private void OpenDetailPage(object parameter)
        {
            _navigationService.Push(new ShoppingItemDetailPage(_item));
        }

        public void Dispose()
        {
            Name?.Dispose();
            Icon?.Dispose();
            PriceLabel?.Dispose();
            ViewDetails?.Dispose();
            _viewDetailsSubscription?.Dispose();
        }
    }
}
