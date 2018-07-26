using Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Repositories
{
    interface ICounterRepository
    {
        IEnumerable<ICounter> GetAllCounters();
        void AddOrReplace(ICounter counter);
        void Delete(ICounter counter);
    }
}
