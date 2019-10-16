using System;
using BenchmarkDotNet.Running;
using NetSamplesBenchmark.Benchmarks;

namespace NetSamplesBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchStringsIndexOf>();

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
}
