using System;
using MobileTemplate.Core.Services;
using MobileTemplate.Core.Services.Shopping;

namespace MobileTemplate.Core.Pages.Shopping.Cart
{
    public class ShoppingCartViewModel : IDisposable
    {
        private INavigationService _navigationService;
        private IShoppingCartService _shoppingCartService;

        public ShoppingCartViewModel(IShoppingCartService shoppingCartService, INavigationService navigationService)
        {
            _shoppingCartService = shoppingCartService;
            _navigationService = navigationService;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
