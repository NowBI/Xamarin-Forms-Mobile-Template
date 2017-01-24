using MobileTemplate.Core.Services;
using Xamarin.Forms;

namespace MobileTemplate.Core.Pages.Shopping.List
{
    public partial class ShoppingListView : StackLayout
    {
        public ShoppingListView()
        {
            InitializeComponent();
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            (e.Item as ShoppingItemViewModel)?.ViewDetailsCommand.Execute();
        }
    }
}
