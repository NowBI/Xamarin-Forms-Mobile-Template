using System;
using Autofac;
using MobileTemplate.Core.Extensions;
using MobileTemplate.Core.Services;
using MobileTemplate.Core.Services.Shopping;
using Xamarin.Forms;

namespace MobileTemplate.Core.Pages.Shopping.Grid
{
    public partial class ShoppingGridView : StackLayout, IDisposable
    {
        public ShoppingGridView()
        {
            InitializeComponent();

            var shoppingItemService = IoC.Container.Resolve<IShoppingItemService>();
            var navigationService = IoC.Container.Resolve<INavigationService>();

            var viewModel = new ShoppingViewModel(shoppingItemService, navigationService);
            BindingContext = viewModel;
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            (e.Item as ShoppingItemViewModel)?.ViewDetailsCommand.Execute();
        }

        public void Dispose()
        {
            this.DisposeChildren();
            this.DisposeBindingContext();
        }
    }
}
