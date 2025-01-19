using BenchmarkDotNet.Attributes;

using SnowMarks.Library.Algorithms.Crypto;

namespace SnowMarks.Benchmarks.Algorithms;

[ThreadingDiagnoser]
[RPlotExporter]
public class Cyphers
{
    private readonly string cypher = "This is a secret message";
    private readonly string VigenereKey = "vigenere";
    
    [Benchmark]
    public string VigenereEncrypt() => VigenereCipher.Encrypt(cypher, VigenereKey);
}