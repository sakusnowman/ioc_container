using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Models
{
    interface ICounter
    {
        string Name { get; }
        int Count { get; }
    }
}
