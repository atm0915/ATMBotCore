using ATMBotCore.Storage;
using ATMBotCore.Storage.Implementations;
using Unity;
using Unity.Resolution;

namespace ATMBotCore
{
    public static class Unity
    {
        private static UnityContainer _container;

        public static UnityContainer Container
        {
            get
            {
                if (_container == null)
                    RegisterTypes();
                return _container;
            }
        }

        public static void RegisterTypes()
        {
            _container = new UnityContainer();
            _container.RegisterType<IDataStorage, InMemoryStorage>();
        }

        public static T Revolve<T>()
        {
            return (T)Container.Resolve(typeof(T), string.Empty, new CompositeResolverOverride());
        }
    }
}