using System;
using Autofac;
using MobileTemplate.Core.Extensions;
using MobileTemplate.Core.Services;
using MobileTemplate.Core.Services.Shopping;
using Xamarin.Forms;

namespace MobileTemplate.Core.Pages.Shopping
{
    public class ShoppingGridPage : ContentPage, IDisposable
    {
        public ShoppingGridPage()
        {
            Title = "Shopping Grid Sample";
            Content = new ShoppingGridView();

            var shoppingItemService = IoC.Container.Resolve<IShoppingItemService>();
            var navigationService = IoC.Container.Resolve<INavigationService>();
            BindingContext = new ShoppingViewModel(shoppingItemService, navigationService);
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
