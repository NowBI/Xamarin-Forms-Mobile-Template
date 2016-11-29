using Autofac;

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
            // builder.Register<Class>().As<IInterface>();
        }
    }
}
