using System;
using BenchmarkDotNet.Attributes;

namespace NetSamplesBenchmark.Benchmarks
{
    [MemoryDiagnoser]
    //[ThreadingDiagnoser]
    public class BenchFormatStr
    {
        [Benchmark(OperationsPerInvoke = 100)]
        public void TestFormat()
        {
            const string name = "NameSmpl";

            for (int i = 0; i < 100; i++)
            {
                var s = String.Format("{0}: Name = {1}", i, name);
            }
        }

        [Benchmark(OperationsPerInvoke = 100)]
        public void TestInterpolate()
        {
            const string name = "NameSmpl";

            for (int i = 0; i < 100; i++)
            {
                var s = $"{i}: Name = {name}";
            }
        }
    }
}
