using System;
using System.Collections.Generic;
using System.Text;

namespace IocLabo.IOC
{
    public class Labo
    {
        static private IIoc ioc = new Ioc();

        public static TClass Construct<TClass>(params Type[] argTypes)
        {
            return ioc.Construct<TClass>(argTypes);
        }

        public static object Construct(Type classType, params Type[] argTypes)
        {
            return ioc.Construct(classType, argTypes);
        }

        public static TClass ConstructByLongestArgs<TClass>()
        {
            return ioc.ConstructByLongestArgs<TClass>();
        }

        public static object ConstructByLongestArgs(Type classType)
        {
            return ioc.ConstructByLongestArgs(classType);
        }

        public static void Register<TInterface, TImplement>()
        {
            ioc.Register<TInterface, TImplement>();
        }

        public static void RegisterSingleton<TInterface>(object value)
        {
            ioc.RegisterSingleton<TInterface>(value);
        }

        public static TInterface Resolve<TInterface>()
        {
            return ioc.Resolve<TInterface>();
        }

        public static object Resolve(Type interfaceType)
        {
            return ioc.Resolve(interfaceType);
        }
    }
}
