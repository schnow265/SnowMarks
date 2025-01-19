using SnowMarks.Library.Algorithms.Math;

using Xunit.Abstractions;

namespace SnowMarks.Tests;

// ReSharper disable once IdentifierTypo
public class PiCulations(ITestOutputHelper testOutputHelper)
{
    private readonly string _searchMe = Convert.ToHexString("Hi"u8.ToArray());

    [Fact]
    public void CalculatePosition()
    {
        int startPos = BBP_Pi.FindHexInPi(_searchMe, 1, 10000);
        testOutputHelper.WriteLine(startPos.ToString());
        Assert.Equal(4506, startPos);
    }
}