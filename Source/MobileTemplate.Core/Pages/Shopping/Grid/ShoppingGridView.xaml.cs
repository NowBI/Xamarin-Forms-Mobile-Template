using System;
using System.Collections.Generic;
using Autofac;
using MobileTemplate.Core.Pages.Landing;
using MobileTemplate.Core.Pages.Shopping.List;
using MobileTemplate.Core.Services;
using MobileTemplate.Core.Services.Shopping;
using Xamarin.Forms;

namespace MobileTemplate.Core.Pages.Shopping.Grid
{
    public partial class ShoppingGridView : StackLayout, IDisposable
    {
        private readonly IDisposable _subviewSubscription;

        public ShoppingGridView()
        {
            InitializeComponent();

            var shoppingItemService = IoC.Container.Resolve<IShoppingItemService>();
            var navigationService = IoC.Container.Resolve<INavigationService>();

            var viewModel = new ShoppingViewModel(shoppingItemService, navigationService);
            BindingContext = viewModel;
            _subviewSubscription = viewModel.ShoppingItems.Subscribe(UpdateSubviews);
        }

        private void UpdateSubviews(IEnumerable<ShoppingItemViewModel> viewModels)
        {
            ItemStack.Children.Clear();
            foreach (var viewModel in viewModels)
            {
                var view = new ShoppingGridItemView { BindingContext = viewModel };
                ItemStack.Children.Add(view);
            }
        }

        public void Dispose()
        {
            _subviewSubscription?.Dispose();
        }
    }
}
