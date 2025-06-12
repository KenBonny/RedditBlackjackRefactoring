// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using BenchmarkExperiments;

public static class Program
{
    public static void Main()
    {
        var summary = BenchmarkRunner.Run<DoubleQuoteVsEmpty>();
    }
}