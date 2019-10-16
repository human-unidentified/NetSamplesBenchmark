using BenchmarkDotNet.Attributes;

namespace NetSamplesBenchmark.Benchmarks
{
    public class BenchStringsReplace
    {
        [Benchmark]
        public void TestReplaceChar()
        {
            var x = "123".Replace('_', '1');
            x = "123df sdf".Replace('_', '1');
            x = "123 sdf dsfasdf '".Replace('_', '1');
        }

        [Benchmark]
        public void TestReplaceString()
        {
            var x = "123".Replace("_", "1");
            x = "123df sdf".Replace("_", "1");
            x = "123 sdf dsfasdf '".Replace("_", "1");
        }
    }
}
