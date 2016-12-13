using System;
using MobileTemplate.Core.Extensions;
using MobileTemplate.Core.Model.Shopping;
using Xamarin.Forms;

namespace MobileTemplate.Core.Pages.Shopping.Detail
{
    public class ShoppingItemDetailPage : ContentPage, IDisposable
    {
        public ShoppingItemDetailPage(ShoppingItemModel item)
        {
            Title = "Landing Page Sample";
            Content = new ShoppingItemDetailView();
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
