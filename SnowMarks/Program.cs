using BenchmarkDotNet.Running;

namespace SnowMarks;

class Program
{
    static void Main(string[] args) => BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
}