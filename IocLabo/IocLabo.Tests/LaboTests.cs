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

        [TestMethod]
        public void RegisterSingleton_IBaseWithBase_Success()
        {
            Labo.RegisterSingleton<IBase>(new Base());
        }

        [TestMethod]
        [ExpectedException(typeof(IOCException))]
        public void RegisterSingleton_NotInterfaceClass_ThrowExeption()
        {
            Labo.RegisterSingleton<Base>(new SubBase());
        }

        [TestMethod]
        [ExpectedException(typeof(IOCException))]
        public void RegisterSingleton_NotImplementClass_ThrowExeption()
        {
            Labo.RegisterSingleton<IBase>(new Sub());
        }

        [TestMethod]
        public void Resolve_IBaseWhenRegisteredIBaseWithBase_ResolveBase()
        {
            // Arrange
            Labo.Register<IBase, Base>();
            // Act
            var result = Labo.Resolve<IBase>();
            // Assert
            Assert.AreEqual(typeof(Base), result.GetType());
        }

        [TestMethod]
        public void Resolve_IBaseWhenRegisteredSingleton_ResolveSingletonBase()
        {
            // Arrange
            var single = new Base();
            Labo.RegisterSingleton<IBase>(single);
            Labo.Resolve<IBase>();
            Labo.Resolve(typeof(IBase));
            // Act
            var result = Labo.Resolve<IBase>();
            // Assert
            Assert.AreEqual(single, result);
        }

        [TestMethod]
        [ExpectedException(typeof(IOCException))]
        public void Resolve_IBaseWhenIsNotRegistered_ThrowException()
        {
            // Act
            var result = Labo.Resolve<IBase>();
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
