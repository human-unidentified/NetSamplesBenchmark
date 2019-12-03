using System.Collections.Concurrent;

namespace NetSamplesBenchmark.Dictionaries
{
    public class ConcurrentDictionaryWrapper : ISimpleDictionary
    {
        private ConcurrentDictionary<int, int> _dictionary = new ConcurrentDictionary<int, int>();

        public bool TryGetValue(int key, out int value)
        {
            return _dictionary.TryGetValue(key, out value);
        }

        public bool TrySetValue(int key, int value)
        {
            return _dictionary.TryAdd(key, value);
        }
    }
}
