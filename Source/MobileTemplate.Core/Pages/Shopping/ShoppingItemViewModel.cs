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

        protected readonly ShoppingItemModel Item;
        protected INavigationService NavigationService;

        public ReactiveCommand ViewDetailsCommand { get; }
        private readonly IDisposable _viewSubscription;

        public ShoppingItemViewModel(ShoppingItemModel source, INavigationService navigationService)
        {
            NavigationService = navigationService;
            Name = new ReactiveProperty<string>(source.Name);
            Icon = new ReactiveProperty<string>(source.Icon);
            Description = new ReactiveProperty<string>(source.Description);
            PriceLabel = new ReactiveProperty<string>($"{source.Price:C}");
            Item = source;

            ViewDetailsCommand = new ReactiveCommand();
            _viewSubscription = ViewDetailsCommand.Subscribe(ViewDetails);
        }

        private void ViewDetails(object param)
        {
            NavigationService.Push(new ShoppingItemDetailPage(Item));
        }

        public virtual void Dispose()
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
