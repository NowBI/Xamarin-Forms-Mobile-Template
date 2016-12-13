using MobileTemplate.Core.Pages.Shopping.Detail;
using MobileTemplate.Core.Services;
using Xamarin.Forms;

namespace MobileTemplate.Core.Pages.Shopping.List
{
    public partial class ShoppingListView : StackLayout
    {
        private readonly INavigationService _navigationService;

        public ShoppingListView(INavigationService navigationService)
        {
            _navigationService = navigationService;
            InitializeComponent();
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = (e.Item as ShoppingItemViewModel);
            if (item != null)
            {
                _navigationService.Push(new ShoppingItemDetailPage(item.Item));
            }
        }
    }
}
