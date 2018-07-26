using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Models;

namespace Sample.Services
{
    interface ICounterService
    {
        IEnumerable<ICounter> GetAllCounters();
        ICounter Find(string name);
        void Add(ICounter counter);
        void Delete(ICounter counter);
        void Increment(ICounter counter, int num);
        void Decrement(ICounter counter, int num);
    }
}
