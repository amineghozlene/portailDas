using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;

/// <summary>
/// http://www.superstarcoders.com/blogs/posts/symmetric-encryption-in-c-sharp.aspx
/// Published Saturday 03 March 2012, 07:59 PM by Keith 
/// 
/// 
/// Symmetric Encryption in C#
/// 
/// Whenever I find myself needing to use a symmetric encryption algorithm, I always seem to write more or less the same code substituting whichever built in .NET cryptography class I need to use. So I decided to write a generic encrypt/decrypt cipher utility that allows you to specify whichever symmetric encryption algorithm you wish to use.
/// .NET Symmetric Encryption Algorithms
/// 
/// Before I launch into the code, here's a quick summary of some of the symmetric encryption algorithms provided by .NET. 
/// AES (Advanced Encryption Standard)
/// 
/// Created in 2001, it is a variant of Rijndael. It offers all round good performance and a good level of security. A fully managed implementation is provided by the AesManaged class. The AesCryptoServiceProvider class provides a faster implementation calling into native code.
/// Rijndael
/// 
/// Rijndael is pretty much the same algorithm as AES in that AES was born from the Rijndael algorithm with some tweaks to the allowed block and key sizes. You should use AES over Rijndael, but you've got to love the name Rijndael! A fully managed implementation is provided by the class RijndaelManaged.
/// Triple DES (Data Encryption Standard)
/// 
/// Basically, this is the DES algorithm applied three times to remove some known flaws in the DES cipher. The TripleDESCryptoServiceProvider class provides a native implementation.
/// Which Symmetric Encryption Algorithm Should You Use?
/// 
/// I would personally use AesManaged as it doesn't rely on native code and offers good performance and security. It is worth noting that symmetric encryption isn't the best means of encryption so you should be careful if your data is extra sensitive. For much better security you should look at asymmetric encryption, also called public-private key encryption.
/// Why is it Called Symmetric Encryption?
/// 
/// It's called symmetric encryption because such algorithms use the same key to encrypt data as they do to decrypt data.
/// 
/// 
/// 
/// AES Example
/// The cipher utility accepts a generic parameter. Use AesManaged for AES encryption:
/// 
/// string plain = "Something you want to keep private with AES";
/// string encrypted = CipherUtility.Encrypt<AesManaged>(plain, "motDePasse", "salt");
/// string decrypted = CipherUtility.Decrypt<AesManaged>(encrypted, "motDePasse", "salt");
/// 
/// 
/// 
/// Triple DES Example
/// At the moment, there's no managed version of Triple DES built into the .NET library, so you'll have to use the TripleDESCryptoServiceProvider with the cipher utility:
/// 
/// string plain = "Something you want to keep private with Triple DES";
/// string encrypted = CipherUtility.Encrypt<TripleDESCryptoServiceProvider>(plain, "motDePasse", "salt");
/// string decrypted = CipherUtility.Decrypt<TripleDESCryptoServiceProvider>(encrypted, "motDePasse", "salt");
/// 
/// 
/// 
/// Rijndael Example
/// Definitely the symmetric encryption algorithm with the best name, use RijndaelManaged to leverage it:
/// 
/// string plain = "Something you want to keep private with Rijndael";
/// string encrypted = CipherUtility.Encrypt<RijndaelManaged>(plain, "motDePasse", "salt");
/// string decrypted = CipherUtility.Decrypt<RijndaelManaged>(encrypted, "motDePasse", "salt");
/// </summary>
public static class Cryptage
{
    private const string MOT_DE_PASSE_CRYPTAGE = "d8g947b7e9";
    private const string SALT_CRYPTAGE = "4fds8g89es";

    /// <summary>
    /// Salt : Chaîne aléatoire concaténée aux mots de passe (ou aux nombres aléatoires) avant de les passer à travers une fonction de cryptage. 
    /// Cette concaténation allonge et obscurcit le mot de passe, rendant le texte chiffré moins sensible aux attaques par dictionnaire.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="valeur"></param>
    /// <param name="motDePasse"></param>
    /// <param name="salt"></param>
    /// <returns></returns>
    public static string crypter<T>(string valeur)
        where T : SymmetricAlgorithm, new()
    {
        string motDePasse = MOT_DE_PASSE_CRYPTAGE;
        string salt = SALT_CRYPTAGE;

        DeriveBytes rgb = new Rfc2898DeriveBytes(motDePasse, Encoding.Unicode.GetBytes(salt));

        SymmetricAlgorithm algorithm = new T();

        byte[] rgbKey = rgb.GetBytes(algorithm.KeySize >> 3);
        byte[] rgbIV = rgb.GetBytes(algorithm.BlockSize >> 3);

        ICryptoTransform transform = algorithm.CreateEncryptor(rgbKey, rgbIV);

        using (MemoryStream buffer = new MemoryStream())
        {
            using (CryptoStream stream = new CryptoStream(buffer, transform, CryptoStreamMode.Write))
            {
                using (StreamWriter writer = new StreamWriter(stream, Encoding.Unicode))
                {
                    writer.Write(valeur);
                }
            }

            return Convert.ToBase64String(buffer.ToArray());
        }
    }

    /// <summary>
    /// Salt : Chaîne aléatoire concaténée aux mots de passe (ou aux nombres aléatoires) avant de les passer à travers une fonction de hachage à sens unique. 
    /// Cette concaténation allonge et obscurcit le mot de passe, rendant le texte chiffré moins sensible aux attaques par dictionnaire.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="valeur"></param>
    /// <param name="motDePasse"></param>
    /// <param name="salt"></param>
    /// <returns></returns>
    public static string decrypter<T>(string text)
        where T : SymmetricAlgorithm, new()
    {
        string motDePasse = MOT_DE_PASSE_CRYPTAGE;
        string salt = SALT_CRYPTAGE;

        DeriveBytes rgb = new Rfc2898DeriveBytes(motDePasse, Encoding.Unicode.GetBytes(salt));

        SymmetricAlgorithm algorithm = new T();

        byte[] rgbKey = rgb.GetBytes(algorithm.KeySize >> 3);
        byte[] rgbIV = rgb.GetBytes(algorithm.BlockSize >> 3);

        ICryptoTransform transform = algorithm.CreateDecryptor(rgbKey, rgbIV);

        using (MemoryStream buffer = new MemoryStream(Convert.FromBase64String(text)))
        {
            using (CryptoStream stream = new CryptoStream(buffer, transform, CryptoStreamMode.Read))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.Unicode))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}