using BenchmarkDotNet.Attributes;

namespace NetSamplesBenchmark.Benchmarks
{
    public class BenchResources
    {
        private static string _str;

        [GlobalSetup]
        public void Init()
        {
            _str = Properties.Resource.TestString;
        }

        [Benchmark]
        public void TestStd()
        {
            string s = Properties.Resource.TestString;
        }

        [Benchmark]
        public void TestCached()
        {
            string s = _str;
        }
    }
}
