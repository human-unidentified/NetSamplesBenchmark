using System;
using BenchmarkDotNet.Running;
using NetSamplesBenchmark.Benchmarks;

namespace NetSamplesBenchmark
{
    public static class Program
    {
        static void Main()
        {
            BenchmarkRunner.Run<BenchFormatStr>();

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }

}
