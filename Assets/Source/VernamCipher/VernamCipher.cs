using System.Text;

namespace Pysijuice.Ciphers {
    public class VernamCipher {
        // dirty implementation 
        public static void Encrypt() {
            var plainText = Encoding.UTF8.GetBytes(VernamFileSystem.ReadFile(VernamFileType.PlainText).ToLower());
            var keyText = Encoding.UTF8.GetBytes(VernamFileSystem.ReadFile(VernamFileType.Key));
            var encryptedText = new byte[plainText.Length];

            for (var i = 0; i < encryptedText.Length; i++) {
                if (!char.IsLetter((char)plainText[i])) {
                    encryptedText[i] = plainText[i];
                    continue;
                }

                encryptedText[i] = (byte)(plainText[i] ^ keyText[i]);

                if (encryptedText[i] > 25) {
                    encryptedText[i] -= 26;
                }

                encryptedText[i] += (byte)'a';
            }

            VernamFileSystem.WriteFile(Encoding.UTF8.GetString(encryptedText), VernamFileType.Encrypted);
        }

        public static void Decrypt() {
            var encryptedText = Encoding.UTF8.GetBytes(VernamFileSystem.ReadFile(VernamFileType.Encrypted));
            var keyText = Encoding.UTF8.GetBytes(VernamFileSystem.ReadFile(VernamFileType.Key));
            var decryptedText = new byte[encryptedText.Length];

            for (var i = 0; i < decryptedText.Length; i++) {
                if (!char.IsLetter((char)encryptedText[i])) {
                    decryptedText[i] = encryptedText[i];
                    continue;
                }

                decryptedText[i] = (byte)(encryptedText[i] ^ keyText[i]);
            }

            VernamFileSystem.WriteFile(Encoding.UTF8.GetString(decryptedText), VernamFileType.Decrypted);
        }
    }
}