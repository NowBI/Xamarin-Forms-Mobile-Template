using System;
using MobileTemplate.Core.Extensions;
using Xamarin.Forms;

namespace MobileTemplate.Core.Pages.Shopping.List
{
    public partial class ShoppingItemListView : StackLayout, IDisposable
    {
        public ShoppingItemListView()
        {
            InitializeComponent();
        }

        public void Dispose()
        {
            this.DisposeChildren();
            this.DisposeBindingContext();
        }
    }
}
