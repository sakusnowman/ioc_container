using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IocLabo.IOC;

namespace IocLabo.Activators
{
    class LaboActivator : ILaboActivator
    {
        private readonly IIoCContainer ioc;

        public LaboActivator(IIoCContainer ioc)
        {
            this.ioc = ioc;
        }

        public TClass Construct<TClass>(params Type[] argTypes) => (TClass)Construct(typeof(TClass), argTypes);

        public object Construct(Type classType, params Type[] argTypes)
        {
            return Activator.CreateInstance(classType, argTypes);
        }

        public TClass ConstructByLongestArgs<TClass>() => (TClass)ConstructByLongestArgs(typeof(TClass));

        public object ConstructByLongestArgs(Type classType)
        {
            var constructors = classType.GetConstructors();
            if (constructors.Count() == 0) return Activator.CreateInstance(classType);
            var longestConstructor = constructors.
                OrderByDescending(c => c.GetParameters().Count()).First();
            var parameterTypes = longestConstructor.GetParameters().Select(p => p.ParameterType);
            return Construct(classType, parameterTypes.ToArray());
        }
    }
}
