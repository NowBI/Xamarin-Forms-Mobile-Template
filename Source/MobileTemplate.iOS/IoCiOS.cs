using Autofac;

namespace MobileTemplate.iOS
{
    public static class IoCiOS
    {
        public static void RegisteriOSDependencies(this ContainerBuilder builder)
        {
            // -- Add your iOS-specific injected services here.
            // builder.Register<Class>().As<IInterface>();
        }
    }
}
