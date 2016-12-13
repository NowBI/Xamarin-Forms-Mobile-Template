using System;
using MobileTemplate.Core.Services;
using MobileTemplate.Core.Services.Shopping;

namespace MobileTemplate.Core.Pages.Shopping
{
    public class ShoppingViewModel : IDisposable
    {
        private readonly IShoppingItemService _shoppingItemService;
        private readonly INavigationService _navigationService;

        public ShoppingViewModel(IShoppingItemService shoppingItemService, INavigationService navigationService)
        {
            _shoppingItemService = shoppingItemService;
            _navigationService = navigationService;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
