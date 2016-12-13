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
        private readonly ShoppingItemModel _item;

        public ReactiveCommand ViewDetailsCommand { get; }
        private readonly INavigationService _navigationService;
        private readonly IDisposable _viewSubscription;

        public ShoppingItemViewModel(ShoppingItemModel source, INavigationService navigationService)
        {
            _navigationService = navigationService;
            Name = new ReactiveProperty<string>(source.Name);
            Icon = new ReactiveProperty<string>(source.Icon);
            Description = new ReactiveProperty<string>(source.Description);
            PriceLabel = new ReactiveProperty<string>($"{source.Price:C}");
            _item = source;

            ViewDetailsCommand = new ReactiveCommand();
            _viewSubscription = ViewDetailsCommand.Subscribe(ViewDetails);
        }

        private void ViewDetails(object param)
        {
            _navigationService.Push(new ShoppingItemDetailPage(_item));
        }

        public void Dispose()
        {
            Name?.Dispose();
            Icon?.Dispose();
            Description?.Dispose();
            PriceLabel?.Dispose();
            ViewDetailsCommand?.Dispose();
            _viewSubscription?.Dispose();
        }
    }
}
