using System;
using Autofac;
using MobileTemplate.Core.Extensions;
using MobileTemplate.Core.Services;
using MobileTemplate.Core.Services.Shopping;
using Xamarin.Forms;

namespace MobileTemplate.Core.Pages.Shopping.List
{
    public class ShoppingListPage : ContentPage, IDisposable
    {
        public ShoppingListPage()
        {
            Title = "Shopping List Sample";

            var shoppingItemService = IoC.Container.Resolve<IShoppingItemService>();
            var navigationService = IoC.Container.Resolve<INavigationService>();

            Content = new ShoppingListView(navigationService);

            BindingContext = new ShoppingViewModel(shoppingItemService, navigationService);
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
