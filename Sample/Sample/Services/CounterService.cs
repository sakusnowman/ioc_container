using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Models;
using Sample.Repositories;

namespace Sample.Services
{
    class CounterService : ICounterService
    {
        private readonly ICounterRepository repository;

        public CounterService(ICounterRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<ICounter> GetAllCounters() => repository.GetAllCounters();

        public void Add(ICounter counter) => repository.AddOrReplace(counter);

        public void Delete(ICounter counter) => repository.Delete(counter);

        public void Increment(ICounter counter, int num)
        {
            Counter editableCounter = new Counter(counter);
            editableCounter.Count += num;
            repository.AddOrReplace(editableCounter);
        }

        public void Decrement(ICounter counter, int num)
        {
            Counter editableCounter = new Counter(counter);
            editableCounter.Count -= num;
            repository.AddOrReplace(editableCounter);
        }

        public ICounter Find(string name)
        {
            var counters = GetAllCounters();
            if(counters.Any(c => c.Name.Equals(name)))
            {
                return counters.First(c => c.Name.Equals(name));
            }
            return new Counter() { Name = name, Count = 0 };
        }

    }
}
