using System;
using Autofac;
using MobileTemplate.Core.Extensions;
using MobileTemplate.Core.Model.Shopping;
using MobileTemplate.Core.Services;
using MobileTemplate.Core.Services.Shopping;
using Xamarin.Forms;

namespace MobileTemplate.Core.Pages.Shopping.Detail
{
    public class ShoppingItemDetailPage : ContentPage, IDisposable
    {
        public ShoppingItemDetailPage(ShoppingItemModel item)
        {
            Title = item.Name;

            var navigationService = IoC.Container.Resolve<INavigationService>();
            var shoppingCartService = IoC.Container.Resolve<IShoppingCartService>();
            BindingContext = new ShoppingItemDetailViewModel(item, shoppingCartService, navigationService);
            Content = new ShoppingItemDetailView();
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
