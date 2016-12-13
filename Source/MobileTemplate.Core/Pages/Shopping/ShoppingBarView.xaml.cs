using Autofac;
using MobileTemplate.Core.Services;
using MobileTemplate.Core.Services.Shopping;
using Xamarin.Forms;

namespace MobileTemplate.Core.Pages.Shopping
{
    public partial class ShoppingBarView : StackLayout
    {
        public ShoppingBarView()
        {
            InitializeComponent();

            var shoppingCartService = IoC.Container.Resolve<IShoppingCartService>();
            var navigationService = IoC.Container.Resolve<INavigationService>();
            BindingContext = new ShoppingBarViewModel(shoppingCartService,navigationService);
        }
    }
}
