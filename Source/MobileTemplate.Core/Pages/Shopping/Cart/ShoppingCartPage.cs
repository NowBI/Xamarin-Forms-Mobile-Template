using System;
using Autofac;
using MobileTemplate.Core.Extensions;
using MobileTemplate.Core.Pages.Shopping.List;
using MobileTemplate.Core.Services;
using MobileTemplate.Core.Services.Shopping;
using Xamarin.Forms;

namespace MobileTemplate.Core.Pages.Shopping.Cart
{
    public class ShoppingCartPage : ContentPage, IDisposable
    {
        public ShoppingCartPage()
        {
            Title = "Shopping Cart Sample";
            var shoppingCartService = IoC.Container.Resolve<IShoppingCartService>();
            var navigationService = IoC.Container.Resolve<INavigationService>();
            Content = new ShoppingListView(navigationService);

            BindingContext = new ShoppingCartViewModel(shoppingCartService, navigationService);
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
