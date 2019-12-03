using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Running;
using NetSamplesBenchmark.Benchmarks;

namespace NetSamplesBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            //var bd = new BenchmarkDictionaries();
            //bd.TestStandard();

            BenchmarkRunner.Run<BenchmarkDictionaries>();

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }

}
