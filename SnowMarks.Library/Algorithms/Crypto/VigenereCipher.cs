namespace SnowMarks.Library.Algorithms.Crypto;

public static class VigenereCipher
{
    /// <summary>
    /// Encrypts the given plaintext using the Vigenère cipher with the provided key.
    /// </summary>
    /// <param name="plaintext">The text to be encrypted.</param>
    /// <param name="key">The encryption key. Only alphabetic characters are considered.</param>
    /// <returns>The encrypted ciphertext.</returns>
    public static string Encrypt(string plaintext, string key)
    {
        key = GenerateKey(plaintext, key);
        string ciphertext = string.Empty;

        for (int i = 0; i < plaintext.Length; i++)
        {
            if (char.IsLetter(plaintext[i]))
            {
                char offset = char.IsUpper(plaintext[i]) ? 'A' : 'a';
                char encryptedChar = (char)(((plaintext[i] + key[i] - 2 * offset) % 26) + offset);
                ciphertext += encryptedChar;
            }
            else
            {
                ciphertext += plaintext[i]; // Keep non-letter characters unchanged
            }
        }

        return ciphertext;
    }

    /// <summary>
    /// Decrypts the given ciphertext using the Vigenère cipher with the provided key.
    /// </summary>
    /// <param name="ciphertext">The text to be decrypted.</param>
    /// <param name="key">The decryption key. Only alphabetic characters are considered.</param>
    /// <returns>The decrypted plaintext.</returns>
    public static string Decrypt(string ciphertext, string key)
    {
        key = GenerateKey(ciphertext, key);
        string plaintext = string.Empty;

        for (int i = 0; i < ciphertext.Length; i++)
        {
            if (char.IsLetter(ciphertext[i]))
            {
                char offset = char.IsUpper(ciphertext[i]) ? 'A' : 'a';
                char decryptedChar = (char)(((ciphertext[i] - key[i] + 26) % 26) + offset);
                plaintext += decryptedChar;
            }
            else
            {
                plaintext += ciphertext[i]; // Keep non-letter characters unchanged
            }
        }

        return plaintext;
    }

    /// <summary>
    /// Generates a key that matches the length of the text by repeating or truncating the original key.
    /// Non-alphabetic characters in the text are ignored for key generation.
    /// </summary>
    /// <param name="text">The text to match the key length against.</param>
    /// <param name="key">The original key. Only alphabetic characters are considered.</param>
    /// <returns>A generated key matching the length of the text.</returns>
    private static string GenerateKey(string text, string key)
    {
        key = key.ToUpper(); // Ensuring uniformity
        string generatedKey = string.Empty;
        int keyIndex = 0;

        foreach (char c in text)
        {
            if (char.IsLetter(c))
            {
                generatedKey += key[keyIndex];
                keyIndex = (keyIndex + 1) % key.Length;
            }
            else
            {
                generatedKey += c; // Non-letter characters don't affect the key
            }
        }

        return generatedKey;
    }
}
