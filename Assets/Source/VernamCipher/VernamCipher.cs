namespace Pysijuice.Ciphers {
    public class VernamCipher {
        // dirty implementation 
        public static void Encrypt() {
            var plainText = VernamFileSystem.ReadFile(VernamFileType.PlainText);
            var keyText = VernamFileSystem.ReadFile(VernamFileType.Key);
            var encryptedText = new char[plainText.Length];

            for (var i = 0; i < encryptedText.Length; i++) {
                encryptedText[i] = (char)(plainText[i] ^ keyText[i]);

                encryptedText[i] += 'a';
            }

            VernamFileSystem.WriteFile(new string(encryptedText), VernamFileType.Encrypted);
        }

        public static void Decrypt() {
            var encryptedText = VernamFileSystem.ReadFile(VernamFileType.Encrypted);
            var keyText = VernamFileSystem.ReadFile(VernamFileType.Key);
            var decryptedText = new char[encryptedText.Length];

            for (var i = 0; i < decryptedText.Length; i++) {
                decryptedText[i] = (char)(encryptedText[i] - 'a' ^ keyText[i]);
            }

            VernamFileSystem.WriteFile(new string(decryptedText), VernamFileType.Decrypted);
        }
    }
}