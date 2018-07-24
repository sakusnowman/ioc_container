using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IocLabo;
using IocLabo.IOC;
namespace IocLabo.Tests
{
    /// <summary>
    /// LaboTests の概要の説明
    /// </summary>
    [TestClass]
    public class LaboTests
    {
        [TestInitialize]
        public void Initialize()
        {
            Labo.Reset();
        }

        [TestMethod]
        public void Register_IBaseWithBase_Success()
        {
            Labo.Register<IBase, Base>();
        }

        [TestMethod]
        [ExpectedException(typeof(IOCException))]
        public void Register_NotInterfaceClass_ThrowExeption()
        {
            Labo.Register<Base, SubBase>();
        }

        [TestMethod]
        [ExpectedException(typeof(IOCException))]
        public void Register_NotImplementClass_ThrowExeption()
        {
            Labo.Register<IBase, Sub>();
        }


        private interface IBase
        {
            void Method();
        }

        private class Base : IBase
        {
            public void Method()
            {
            }
        }
        private class SubBase : Base { }
        private class Sub { }
    }

    
}
