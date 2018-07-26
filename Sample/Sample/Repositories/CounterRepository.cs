using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Sample.Models;

namespace Sample.Repositories
{
    class CounterRepository : ICounterRepository
    {
        const string filePath = "countersData.txt";
        public CounterRepository()
        {
            if(File.Exists(filePath) == false)
            {
                File.Create(filePath);
            }
        }

        public void AddOrReplace(ICounter counter)
        {
            var counters = GetAllCounters().ToList();
            if (counters.Contains(counter))
            {
                counters.Remove(counter);
            }
            counters.Add(counter);
            WriteToFile(counters);
        }

        public void Delete(ICounter counter)
        {
            var counters = GetAllCounters().ToList();
            if (counters.Remove(counter))
            {
                WriteToFile(counters);
            }
        }

        public IEnumerable<ICounter> GetAllCounters()
        {
            StreamReader reader = new StreamReader(filePath);
            var lines = reader.ReadToEnd().Split('\n');
            reader.Close();
            var counters = lines.Where(l => l.Length != 0)
                .Select(l =>
            {
                string name = l.Substring(1, l.LastIndexOf("\"") - 1);
                int count = int.Parse(l.Substring(l.LastIndexOf(' ')));
                return new Counter() { Name = name, Count = count };
            });
            return counters;
        }

        void WriteToFile(IEnumerable<ICounter> counters)
        {
            StreamWriter writer = new StreamWriter(filePath);
            foreach(var counter in counters)
            {
                writer.Write("\"" + counter.Name + "\" ");
                writer.WriteLine(counter.Count);
            }
            writer.Close();
        }
    }
}
