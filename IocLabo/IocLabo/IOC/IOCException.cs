using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace IocLabo.IOC
{
    public class IOCException : Exception
    {
        public IOCException(){}
        public IOCException(string message) : base(message) { }
        public IOCException(string message, Exception innerException) : base(message, innerException){}
        protected IOCException(SerializationInfo info, StreamingContext context) : base(info, context){}

        public static IOCException NotInterfaceException(Type notInterfaceType)
        {
            StringBuilder message = new StringBuilder();
            message.AppendLine(notInterfaceType.ToString() + " is not interface.");
            return new IOCException(message.ToString());
        }

        public static void CheckImplementedInterface<TInterface, TImplement>()
        {
            if (typeof(TInterface).IsInterface == false) throw NotInterfaceException(typeof(TInterface));
            try
            {
                typeof(TImplement).GetInterfaceMap(typeof(TInterface));
            }catch(Exception e)
            {
                StringBuilder message = new StringBuilder();
                message.Append(typeof(TImplement).ToString());
                message.Append(" is not implemented " + typeof(TInterface).ToString() + ".");
                throw new IOCException(message.ToString(), e);
            }
        }
    }
}
