using System;
using System.Security.Cryptography;
using System.Text;

namespace Pysijuice.Ciphers {
    public class AesCipher {
        private static Aes _aes;

        public static void GenerateKey() {
            var key = GenerateRandomKey(32);

            AesFileSystem.WriteFile(key, AesFileType.Key);
        }

        public static void Encrypt() {
            _aes = Aes.Create();
            _aes.Key = Convert.FromBase64String(AesFileSystem.ReadFile(AesFileType.Key));
            _aes.GenerateIV();

            var encryptor = _aes.CreateEncryptor(_aes.Key, _aes.IV);
            var text = Encoding.UTF8.GetBytes(AesFileSystem.ReadFile(AesFileType.Text));
            byte[] encryptedText;

            using (var msEncrypt = new System.IO.MemoryStream()) {
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)) {
                    csEncrypt.Write(text, 0, text.Length);
                    csEncrypt.FlushFinalBlock();
                    encryptedText = msEncrypt.ToArray();
                }
            }

            AesFileSystem.WriteFile(Convert.ToBase64String(encryptedText), AesFileType.Encrypted);
        }

        public static void Decrypt() {
            var decryptor = _aes.CreateDecryptor(_aes.Key, _aes.IV);
            var encryptedText = Convert.FromBase64String(AesFileSystem.ReadFile(AesFileType.Encrypted));
            var result = "";

            using (var msDecrypt = new System.IO.MemoryStream(encryptedText)) {
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)) {
                    using (var srDecrypt = new System.IO.StreamReader(csDecrypt)) {
                        result = srDecrypt.ReadToEnd();
                    }
                }
            }

            AesFileSystem.WriteFile(result, AesFileType.Decrypted);
        }

        private static string GenerateRandomKey(int length) {
            var key = new byte[length];
            using (var rngCsp = new RNGCryptoServiceProvider()) {
                rngCsp.GetBytes(key);
            }

            return Convert.ToBase64String(key);
        }
    }
}