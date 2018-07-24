using System;
using System.Collections.Generic;
using System.Text;

namespace IocLabo.IOC
{
    class Ioc : IIoc
    {
        private Dictionary<Type, Type> interfaceTable;
        private Dictionary<Type, object> singletonTable;

        public Ioc()
        {
            interfaceTable = new Dictionary<Type, Type>();
            singletonTable = new Dictionary<Type, object>();
        }

        public void Register<TInterface, TImplement>()
        {
            IOCException.CheckImplementedInterface<TInterface, TImplement>();
            if (interfaceTable.ContainsKey(typeof(TInterface)))
            {
                interfaceTable[typeof(TInterface)] = typeof(TImplement);
                return;
            }
            interfaceTable.Add(typeof(TInterface), typeof(TImplement));
        }

        public void RegisterSingleton<TInterface>(object value)
        {
            IOCException.CheckImplementedInterface<TInterface>(value.GetType());
            if (singletonTable.ContainsKey(typeof(TInterface)))
            {
                singletonTable[typeof(TInterface)] = value;
                return;
            }
            singletonTable.Add(typeof(TInterface), value);
        }

        public TInterface Resolve<TInterface>()
        {
            throw new NotImplementedException();
        }

        public object Resolve(Type interfaceType)
        {
            throw new NotImplementedException();
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
