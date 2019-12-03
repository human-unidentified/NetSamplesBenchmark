using System.Collections.Generic;
using System.Threading;

namespace NetSamplesBenchmark.Dictionaries
{
    public class StandardDictionaryWrapper : ISimpleDictionary
    {
        private readonly Dictionary<int, int> _dictionary = new Dictionary<int, int>();
        private readonly ReaderWriterLockSlim _cacheLock = new ReaderWriterLockSlim();

        public bool TryGetValue(int key, out int value)
        {
            _cacheLock.EnterReadLock();
            try
            {
                return _dictionary.TryGetValue(key, out value);
            }
            finally
            {
                _cacheLock.ExitReadLock();
            }
        }

        public bool TrySetValue(int key, int value)
        {
            _cacheLock.EnterWriteLock();
            try
            {
                _dictionary[key] = value;
                return true;
            }
            finally
            {
                _cacheLock.ExitWriteLock();
            }
        }
    }
}
