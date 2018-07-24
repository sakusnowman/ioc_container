using System;
using System.Collections.Generic;
using System.Text;

namespace IocLabo.IOC
{
    interface IIoc
    {
        void Register<TInterface, TImplement>();
        void RegisterSingleton<TInterface>(object value);
        TInterface Resolve<TInterface>();
        object Resolve(Type interfaceType);
        TClass Construct<TClass>(params Type[] argTypes);
        object Construct(Type classType, params Type[] argTypes);
        TClass ConstructByLongestArgs<TClass>();
        object ConstructByLongestArgs(Type classType);

    }
}
