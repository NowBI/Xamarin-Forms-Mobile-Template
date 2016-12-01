using System;
using MobileTemplate.Core.Extensions;
using Xamarin.Forms;

namespace MobileTemplate.Core.Pages.Menu
{
    public partial class MainMenuView : StackLayout, IDisposable
    {
        public MainMenuView()
        {
            InitializeComponent();
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            (e.Item as MainMenuItemViewModel)?.Tapped?.Execute();
        }
        
        public void Dispose()
        {
            this.DisposeChildren();
            this.DisposeBindingContext();
        }
    }
}
