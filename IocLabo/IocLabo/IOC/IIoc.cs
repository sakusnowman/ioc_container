using System;
using System.Collections.Generic;
using System.Text;

namespace IocLabo.IOC
{
    /// <summary>
    /// This class support IoC pattern.
    /// </summary>
    public interface IIoc
    {
        /// <summary>
        /// Register interface use which implement class.
        /// </summary>
        /// <typeparam name="TInterface">This must be interface class.</typeparam>
        /// <typeparam name="TImplement">Tihs must be implemented TInterface.</typeparam>
        void Register<TInterface, TImplement>();

        /// <summary>
        /// Register singletonObject to TInterface.
        /// </summary>
        /// <typeparam name="TInterface">This must be interface class.</typeparam>
        /// <param name="value">This must be object which is implemented TInterface</param>
        void RegisterSingleton<TInterface>(object value);

        /// <summary>
        /// Resolve object which is implemented TInterface.
        /// </summary>
        /// <typeparam name="TInterface">This is must be registered before you use.</typeparam>
        /// <returns> Singleton object is resolved, if you registered both implement and singleton.</returns>
        TInterface Resolve<TInterface>();
        object Resolve(Type interfaceType);

        
    }
}
