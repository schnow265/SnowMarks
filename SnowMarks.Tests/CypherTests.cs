using SnowMarks.Library.Algorithms.Crypto;

using Xunit.Abstractions;

namespace SnowMarks.Tests;

public class CypherTests(ITestOutputHelper testOutputHelper)
{
    private readonly string cypher = "This is a secret message";
    private readonly string VigenereKey = "vigenere";

    [Fact]
    public void Encrypt()
    {
        string encryptedMessage = VigenereCipher.Encrypt(cypher, VigenereKey);
        testOutputHelper.WriteLine(encryptedMessage);
        Assert.Equal("OPOW VW R WZKXIa QVWhIMI".ToLower(), encryptedMessage.ToLower());
    }

    [Fact]
    public void Decrypt()
    {
        string decryptedMessage = VigenereCipher.Decrypt("OPOW VW R WZKXIa QVWhIMI", VigenereKey);
        Assert.Equal(cypher.ToLower(), decryptedMessage.ToLower());
    }
}