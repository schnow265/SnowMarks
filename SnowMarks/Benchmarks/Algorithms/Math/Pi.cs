using BenchmarkDotNet.Attributes;

using SnowMarks.Library.Algorithms.Math;

namespace SnowMarks.Benchmarks.Algorithms.Math;

[ThreadingDiagnoser]
[RPlotExporter]
[BenchmarkCategory("Pi")]
[SimpleJob(iterationCount: 10)]
public class Pi
{
    private readonly string _searchMe = Convert.ToHexString("Hi"u8.ToArray());

    [Benchmark]
    public int PiSearch() => BBP_Pi.FindHexInPi(_searchMe, 1, 10000);
}