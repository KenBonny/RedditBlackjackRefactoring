using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace BenchmarkExperiments
{
    [SimpleJob(RuntimeMoniker.Net462)]
    [SimpleJob(RuntimeMoniker.Net90)]
    [RPlotExporter]
    public class DoubleQuoteVsEmpty
    {
        private List<string> strings;

        [Params(10_000_000, 1_000_000, 10_000)]
        public int Iterations;

        [GlobalSetup]
        public void Setup() => strings = new List<string>(Iterations);

        [IterationCleanup]
        public void Cleanup() => strings.Clear();

        [Benchmark]
        public List<string> DoubleQuoteStrings()
        {
            for (int index = 0; index < Iterations; index++)
            {
                strings.Add("");
            }
            return strings;
        }

        [Benchmark]
        public List<string> EmptyStrings()
        {
            for (int index = 0; index < Iterations; index++)
            {
                strings.Add(string.Empty);
            }

            return strings;
        }
    }
}