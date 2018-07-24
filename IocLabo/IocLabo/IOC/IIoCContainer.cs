using System;
using System.Collections.Generic;
using System.Text;

namespace IocLabo.IOC
{
    /// <summary>
    /// This class support IoC pattern.
    /// </summary>
    public interface IIoCContainer
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
        /// Check TInterface is regisetered in container.
        /// </summary>
        /// <typeparam name="TInterface">Interface class</typeparam>
        /// <returns></returns>
        bool IsRegistered<TInterface>();
        bool IsRegistered(Type interfaceType);

        /// <summary>
        /// Get singleton object which is registered,
        /// if it is regiseterd.
        /// </summary>
        /// <typeparam name="TInterface">Interface class</typeparam>
        /// <returns></returns>
        TInterface GetSingleton<TInterface>();
        object GetSingleton(Type interfaceType);


        /// <summary>
        /// Get type of implement class which is registered,
        /// if it si registered.
        /// </summary>
        /// <typeparam name="TInterface">Interface class</typeparam>
        /// <returns></returns>
        Type GetImplementType<TInterface>();
        Type GetImplementType(Type interfaceType);
    }
}
