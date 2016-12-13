using System;
using MobileTemplate.Core.Extensions;
using Xamarin.Forms;

namespace MobileTemplate.Core.Pages.Shopping.Detail
{
    public partial class ShoppingItemDetailView : ScrollView, IDisposable
    {
        public ShoppingItemDetailView()
        {
            InitializeComponent();
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
