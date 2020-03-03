using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSamplesBenchmark.Benchmarks
{
    [MemoryDiagnoser]
    public class BenchHashsetVsList
    {
        private enum SampleEnum
        {
            Ber,
            Ike,
            Us,
            Durt,
            Bish,
            Alti
        }

        private static readonly HashSet<SampleEnum> _hs = new HashSet<SampleEnum>()
        {
            SampleEnum.Ber,
            SampleEnum.Ike,
            SampleEnum.Us,
            SampleEnum.Alti
        };

        private static readonly List<SampleEnum> _ls = new List<SampleEnum>()
        {
            SampleEnum.Ber,
            SampleEnum.Ike,
            SampleEnum.Us,
            SampleEnum.Alti
        };


        [Benchmark(OperationsPerInvoke = 2)]
        public void TestHashSet()
        {
            _hs.Contains(SampleEnum.Ike);
            _hs.Contains(SampleEnum.Bish);
        }


        [Benchmark(OperationsPerInvoke = 2)]
        public void TestList()
        {
            _ls.Contains(SampleEnum.Ike);
            _ls.Contains(SampleEnum.Bish);
        }
    }
}
