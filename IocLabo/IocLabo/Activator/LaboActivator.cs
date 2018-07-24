using System;
using System.Collections.Generic;
using System.Text;
using IocLabo.IOC;

namespace IocLabo.Activator
{
    class LaboActivator : ILaboActivator
    {
        private readonly IIoc ioc;

        public LaboActivator(IIoc ioc)
        {
            this.ioc = ioc;
        }

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
    }
}
