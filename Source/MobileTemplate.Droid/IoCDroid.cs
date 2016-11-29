using Autofac;

namespace MobileTemplate.Droid
{
    public static class IoCDroid
    {
        public static void RegisterDroidDependencies(this ContainerBuilder builder)
        {
            // -- Add your Android-specific injected services here.
            // builder.RegisterType<Class>().As<IInterface>();
        }
    }
}
