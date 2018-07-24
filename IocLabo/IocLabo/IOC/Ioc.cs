using System;
using System.Collections.Generic;
using System.Text;

namespace IocLabo.IOC
{
    class Ioc : IIoc
    {
        public TClass Construct<TClass>(params Type[] argTypes)
        {
            throw new NotImplementedException();
        }

        public object Construct(Type classType, params Type[] argTypes)
        {
            throw new NotImplementedException();
        }

        public TClass ConstructByLongestArgs<TClass>()
        {
            throw new NotImplementedException();
        }

        public object ConstructByLongestArgs(Type classType)
        {
            throw new NotImplementedException();
        }

        public void Register<TInterface, TImplement>()
        {
            throw new NotImplementedException();
        }

        public void RegisterSingleton<TInterface>(object value)
        {
            throw new NotImplementedException();
        }

        public TInterface Resolve<TInterface>()
        {
            throw new NotImplementedException();
        }

        public object Resolve(Type interfaceType)
        {
            throw new NotImplementedException();
        }
    }
}
