using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSamplesBenchmark.Dictionaries
{
    public interface ISimpleDictionary
    {
        bool TryGetValue(int key, out int value);
        bool TrySetValue(int key, int value);
    }
}
