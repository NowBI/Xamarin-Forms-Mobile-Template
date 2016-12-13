using System;
using Autofac;
using MobileTemplate.Core.Extensions;
using MobileTemplate.Core.Services;
using MobileTemplate.Core.Services.Shopping;
using Xamarin.Forms;

namespace MobileTemplate.Core.Pages.Shopping
{
    public class ShoppingCartPage : ContentPage, IDisposable
    {
        public ShoppingCartPage()
        {
            Title = "Shopping Cart Sample";
            Content = new ShoppingListView();

            var shoppingCartService = IoC.Container.Resolve<IShoppingCartService>();
            var navigationService = IoC.Container.Resolve<INavigationService>();
            BindingContext = new ShoppingCartViewModel(shoppingCartService, navigationService);
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
