using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IocLabo;
using Sample.Repositories;
using Sample.Services;

namespace Sample
{
    class SetUp
    {
        public SetUp()
        {
            SetInterfaceImplement();
        }

        void SetInterfaceImplement()
        {
            Labo.RegisterSingleton<ICounterRepository>(new CounterRepository());
            Labo.Register<ICounterService, CounterService>();
        }
    }
}
