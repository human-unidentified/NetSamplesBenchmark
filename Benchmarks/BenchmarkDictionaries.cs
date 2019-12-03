using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using BenchmarkDotNet.Attributes;
using NetSamplesBenchmark.Dictionaries;

namespace NetSamplesBenchmark.Benchmarks
{
    public class BenchmarkDictionaries
    {
        [Benchmark]
        public void TestStandard()
        {
            var simpleDictionary = new StandardDictionaryWrapper();
            BenchProc(simpleDictionary);
        }

        [Benchmark]
        public void TestStandardLock()
        {
            var simpleDictionary = new StandardLockDictionaryWrapper();
            BenchProc(simpleDictionary);
        }

        [Benchmark]
        public void TestConcurrentDictionary()
        {
            var simpleDictionary = new ConcurrentDictionaryWrapper();
            BenchProc(simpleDictionary);
        }

        private static void BenchProc(ISimpleDictionary simpleDictionary)
        {
            CreateReadThreads(simpleDictionary, out var readThreads, out var readThreadParameters);
            CreateWriteThreads(simpleDictionary, out var writeThreads, out var writeThreadParameters);

            for (int i = 0; i < readThreads.Length; i++)
                readThreads[i].Start(readThreadParameters[i]);

            for (int i = 0; i < writeThreads.Length; i++)
                writeThreads[i].Start(writeThreadParameters[i]);

            for (int i = 0; i < readThreads.Length; i++)
                readThreads[i].Join();

            for (int i = 0; i < writeThreads.Length; i++)
                writeThreads[i].Join();

        }

        private static void CreateReadThreads(ISimpleDictionary simpleDictionary, out Thread[] readThreads, out BenchThreadParams[] readThreadParameters)
        {
            const int readThreadsCount = 12;
            const int readValuesCount = 1_000_000;
            readThreads = new Thread[readThreadsCount];
            readThreadParameters = new BenchThreadParams[readThreadsCount];

            for (int i = 0; i < readThreadsCount; i++)
            {
                var readThread = new Thread(BenchmarkThread)
                {
                    Name = $"Read thread #{i + 1}"
                };

                var readThreadParameter = new BenchThreadParams(simpleDictionary, 0, Enumerable.Range(i * readValuesCount, readValuesCount).ToList(), false);
                readThreads[i] = readThread;
                readThreadParameters[i] = readThreadParameter;
            }
        }

        private static void CreateWriteThreads(ISimpleDictionary simpleDictionary, out Thread[] writeThreads, out BenchThreadParams[] writeThreadParameters)
        {
            const int writeThreadsCount = 2;
            const int writeValuesCount = 10_000;
            writeThreads = new Thread[writeThreadsCount];
            writeThreadParameters = new BenchThreadParams[writeThreadsCount];

            for (int i = 0; i < writeThreadsCount; i++)
            {
                var readThread = new Thread(BenchmarkThread)
                {
                    Name = $"Write thread #{i + 1}"
                };

                var writeList = Enumerable
                    .Range(i * writeValuesCount, writeValuesCount)
                    .Select(value => value * 100)
                    .ToList();

                var readThreadParameter = new BenchThreadParams(simpleDictionary, 0, writeList, true);
                writeThreads[i] = readThread;
                writeThreadParameters[i] = readThreadParameter;
            }
        }

        private static void BenchmarkThread(object param)
        {
            var benchThreadParams = (BenchThreadParams)param;

            foreach (int item in benchThreadParams.Values)
            {
                if (benchThreadParams.StepDelay != 0)
                    Thread.Sleep(benchThreadParams.StepDelay);

                if (benchThreadParams.WorkloadWrite)
                    benchThreadParams.SimpleDictionary.TrySetValue(item, item);
                else
                    benchThreadParams.SimpleDictionary.TryGetValue(item, out var _);
            }
        }

        private class BenchThreadParams
        {
            public BenchThreadParams(ISimpleDictionary simpleDictionary, int stepDelay, List<int> values, bool workloadWrite)
            {
                SimpleDictionary = simpleDictionary;
                StepDelay = stepDelay;
                Values.AddRange(values);
                WorkloadWrite = workloadWrite;
            }

            public ISimpleDictionary SimpleDictionary { get; }
            public int StepDelay { get; }
            public List<int> Values { get; } = new List<int>();
            public bool WorkloadWrite { get; }
        }
    }
}
