using System.Text.RegularExpressions;

using BenchmarkDotNet.Attributes;

namespace SnowMarks.Benchmarks;

[BenchmarkCategory("Regex")]
[RPlotExporter]
public partial class RegMarks
{
    private string text = "x=xxxxxxxxxxxxx";
    private string pattern = @".*.*=.*";

    [Benchmark]
    public Match StaticMatch() => Regex.Match(text, pattern);


    // [GeneratedRegex(".*.*=.*")]
    // public static partial Regex GeneratedRregex();
}