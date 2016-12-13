using System;
using MobileTemplate.Core.Extensions;
using Xamarin.Forms;

namespace MobileTemplate.Core.Pages.Shopping.Grid
{
    public class ShoppingGridPage : ContentPage, IDisposable
    {
        public ShoppingGridPage()
        {
            Title = "Shopping Grid Sample";
            Content = new ShoppingGridView();
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
