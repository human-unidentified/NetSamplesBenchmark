using System.Collections.Generic;

namespace NetSamplesBenchmark.Dictionaries
{
    public class StandardLockDictionaryWrapper : ISimpleDictionary
    {
        private Dictionary<int, int> _dictionary = new Dictionary<int, int>();
        private readonly object _lock = new object();

        public bool TryGetValue(int key, out int value)
        {
            lock (_lock)
            {
                return _dictionary.TryGetValue(key, out value);
            }
        }

        public bool TrySetValue(int key, int value)
        {
            lock (_lock)
            {
                _dictionary[key] = value;
                return true;
            }
        }
    }
}
