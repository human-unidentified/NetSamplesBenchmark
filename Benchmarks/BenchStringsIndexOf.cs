using BenchmarkDotNet.Attributes;

namespace NetSamplesBenchmark.Benchmarks
{
    public class BenchStringsIndexOf
    {
        [Benchmark]
        public void TestContains()
        {
            var x = "123".Contains("'");
            x = "123df sdf".Contains("'");
            x = "123 sdf dsfasdf '".Contains("'");
        }

        [Benchmark]
        public void TestIndexOf()
        {
            var x = "123".IndexOf("'");
            x = "123df sdf".IndexOf("'");
            x = "123 sdf dsfasdf '".IndexOf("'");
        }
    }
}
