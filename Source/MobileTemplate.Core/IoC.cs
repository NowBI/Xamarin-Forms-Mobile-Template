using Autofac;
using MobileTemplate.Core.Services;
using MobileTemplate.Core.Services.Shopping;

namespace MobileTemplate.Core
{
    public static class IoC
    {
        public static IContainer Container;

        public static void Publish(this ContainerBuilder builder)
        {
            Container = builder.Build();
        }

        public static void RegisterCoreDependencies(this ContainerBuilder builder)
        {
            // -- Add your shared injected services here.
            // builder.RegisterType<Class>().As<IInterface>().SingleInstance();
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            builder.RegisterType<MenuItemService>().As<IMenuItemService>().SingleInstance();

            builder.RegisterType<ShoppingItemService>().As<IShoppingItemService>().SingleInstance();
            builder.RegisterType<ShoppingCartService>().As<IShoppingCartService>().SingleInstance();
        }
    }
}
