using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Repositories;
using Sample.Views;
using Sample.Services;
using IocLabo;

namespace Sample
{
    class Program
    {
        static CounterViewer viewer;
        static void Main(string[] args)
        {
            new SetUp();
            viewer = Labo.ConstructByLongestArgs<CounterViewer>();
            Sequence();
        }

        static void Sequence()
        {
            while (true)
            {
                viewer.ShowAllCounters();
                viewer.AcceptCommand();
            }
        }
    }
}
