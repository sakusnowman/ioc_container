using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Models
{
    class Counter : ICounter
    {
        public Counter()
        {
            Name = "";
            Count = 0;
        }

        public Counter(ICounter counter)
        {
            this.Name = counter.Name;
            this.Count = counter.Count;
        }
        public string Name { get; set; }
        public int Count { get; set; }

        public override bool Equals(object obj)
        {
            try
            {
                return this.Name.Equals(((Counter)obj).Name);
            }
            catch
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}