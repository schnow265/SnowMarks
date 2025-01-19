namespace SnowMarks.Library.Algorithms.Math;

/// <summary>
/// An implementation of the <see href="https://en.wikipedia.org/wiki/Bailey%E2%80%93Borwein%E2%80%93Plouffe_formula">Bailey–Borwein–Plouffe</see> formula in C#
/// </summary>
public static class BBP_Pi
{
    /// <summary>
    /// Computes the n-th digit of Pi in hexadecimal using the BBP formula.
    /// </summary>
    /// <param name="n">The 1-based position of the digit to compute.</param>
    /// <returns>The hexadecimal digit of Pi at position n.</returns>
    private static char GetPiHexDigit(int n)
    {
        n -= 1; // Adjust for zero-based indexing

        double x = (4 * Series(1, n)) - (2 * Series(4, n)) - Series(5, n) - Series(6, n);
        x = x - System.Math.Floor(x); // Get fractional part
        int hexDigit = (int)(x * 16);

        return hexDigit.ToString("X")[0];
    }

    /// <summary>
    /// Computes the BBP series for a specific parameter m and digit position n.
    /// </summary>
    /// <param name="m">The specific parameter in the series (1, 4, 5, or 6).</param>
    /// <param name="n">The 0-based position of the digit to compute.</param>
    /// <returns>The computed value of the BBP series for the given parameters.</returns>
    private static double Series(int m, int n)
    {
        double sum = 0.0;

        // Left sum (k = 0 to n)
        for (int k = 0; k <= n; k++)
        {
            double term = (double)ModPow(16, n - k, 8 * k + m) / (8 * k + m);
            sum += term - System.Math.Floor(term);
        }

        // Right sum (k = n+1 to infinity, approximated)
        for (int k = n + 1; k <= n + 100; k++) // Limit to 100 terms for approximation
        {
            sum += System.Math.Pow(16, n - k) / (8 * k + m);
        }

        return sum - System.Math.Floor(sum);
    }

    /// <summary>
    /// Computes modular exponentiation.
    /// </summary>
    /// <param name="baseValue">The base value.</param>
    /// <param name="exponent">The exponent value.</param>
    /// <param name="modulus">The modulus value.</param>
    /// <returns>The result of (baseValue^exponent) % modulus.</returns>
    private static long ModPow(long baseValue, int exponent, int modulus)
    {
        long result = 1;
        long baseMod = baseValue % modulus;

        while (exponent > 0)
        {
            if ((exponent & 1) == 1)
            {
                result = (result * baseMod) % modulus;
            }

            baseMod = (baseMod * baseMod) % modulus;
            exponent >>= 1;
        }

        return result;
    }

    // Searches for a hex string in Pi
    /// <summary>
    /// Find the position of a hex string inside of Pi.
    /// </summary>
    /// <param name="hexString">The string to search for</param>
    /// <param name="startPosition">From what position to start searching</param>
    /// <param name="digitsToSearch">How many digits to search through</param>
    /// <returns>The start position of the string inside of Pi</returns>
    /// <remarks>The parameter <c>digitsToSearch</c> can have a maximum value of <c>int.MaxValue</c>.</remarks>
    public static int FindHexInPi(string hexString, int startPosition, int digitsToSearch)
    {
        string target = hexString.ToUpper();

        // Build the sequence of Pi's hex digits
        var piHexDigits = Enumerable.Range(startPosition, digitsToSearch)
                                     .Select(GetPiHexDigit)
                                     .ToArray();

        string piHexString = new string(piHexDigits);

        return piHexString.IndexOf(target, StringComparison.Ordinal);
    }

    /// <summary>
    /// Find the position of a hex string inside of Pi.
    /// <br/>
    /// Digits to search is set to <c>int.MaxValue</c>
    /// </summary>
    /// <param name="hexString">The string to search for</param>
    /// <param name="startPosition">From what position to start searching</param>
    /// <returns>The start position of the string inside of Pi</returns>
    public static int FindHexInPi(string hexString, int startPosition) => FindHexInPi(hexString, startPosition, int.MaxValue);
    
    // Searches for a hex string in Pi
    /// <summary>
    /// Find the position of a hex string inside of Pi.
    /// <br/>
    /// Starts at position 1 and searches the maximum amount(<c>int.MaxValue</c>) of Numbers.
    /// </summary>
    /// <param name="hexString">The string to search for</param>
    /// <returns>The start position of the string inside of Pi</returns>
    public static int FindHexInPi(string hexString) => FindHexInPi(hexString, 1);
}
