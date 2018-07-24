using System;
using System.Collections.Generic;
using System.Text;
using IocLabo.IOC;

namespace IocLabo
{
    /// <summary>
    /// This class support IoC pattern.
    /// You can easyily to use IoC Container.
    /// </summary>
    public class Labo
    {
        static private IIoc ioc = new Ioc();

        /// <summary>
        /// Reset registerd classes.
        /// </summary>
        public static void Reset()
        {
            ioc = new Ioc();
        }

        /// <summary>
        /// Register interface use which implement class.
        /// </summary>
        /// <typeparam name="TInterface">This must be interface class.</typeparam>
        /// <typeparam name="TImplement">Tihs must be implemented TInterface.</typeparam>
        public static void Register<TInterface, TImplement>() => ioc.Register<TInterface, TImplement>();

        /// <summary>
        /// Register singletonObject to TInterface.
        /// </summary>
        /// <typeparam name="TInterface">This must be interface class.</typeparam>
        /// <param name="value">This must be object which is implemented TInterface</param>
        public static void RegisterSingleton<TInterface>(object value) => ioc.RegisterSingleton<TInterface>(value);

        /// <summary>
        /// Resolve object which is implemented TInterface.
        /// </summary>
        /// <typeparam name="TInterface">This is must be registered before you use.</typeparam>
        /// <returns> Singleton object is resolved, if you registered both implement and singleton.</returns>
        public static TInterface Resolve<TInterface>() => ioc.Resolve<TInterface>();
        public static object Resolve(Type interfaceType) => ioc.Resolve(interfaceType);

        /// <summary>
        /// Construct TClass by argTypes parameter constructor.
        /// Resolve from container if you regiseterd interfaceType, when argType is Interface.
        /// Use default value, if you've never registered argType.
        /// </summary>
        /// <typeparam name="TClass"></typeparam>
        /// <param name="argTypes">TClass must have constructor which has these argTypes parameter.</param>
        /// <returns></returns>
        public static TClass Construct<TClass>(params Type[] argTypes) => ioc.Construct<TClass>(argTypes);
        public static object Construct(Type classType, params Type[] argTypes) => ioc.Construct(classType, argTypes);

        /// <summary>
        /// Construct TClass by longest args constructor.
        /// </summary>
        /// <typeparam name="TClass"></typeparam>
        /// <returns></returns>
        public static TClass ConstructByLongestArgs<TClass>() => ioc.ConstructByLongestArgs<TClass>();
        public static object ConstructByLongestArgs(Type classType) => ioc.ConstructByLongestArgs(classType);
    }
}
