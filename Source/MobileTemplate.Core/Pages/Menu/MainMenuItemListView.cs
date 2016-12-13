using System;
using MobileTemplate.Core.Extensions;
using Xamarin.Forms;

namespace MobileTemplate.Core.Pages.Menu
{
    public partial class MainMenuItemListView : StackLayout, IDisposable
    {
        public MainMenuItemListView()
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
