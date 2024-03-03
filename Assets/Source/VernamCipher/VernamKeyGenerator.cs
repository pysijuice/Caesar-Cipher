using System.Text;
using Random = UnityEngine.Random;

namespace Pysijuice.Ciphers {
    public class VernamKeyGenerator {
        public static void GenerateKey() {
            var plainText = VernamFileSystem.ReadFile(VernamFileType.PlainText);
            var lengthOfKey = plainText.Length;
            var keyInfo = new StringBuilder();

            for (var i = 0; i < lengthOfKey; i++) {
                if (!char.IsLetter(plainText[i])) {
                    keyInfo.Append(plainText[i]);
                    continue;
                }

                var randomChar = (char)Random.Range('a', 'z' + 1);

                keyInfo.Append(randomChar);
            }

            VernamFileSystem.WriteFile(keyInfo.ToString(), VernamFileType.Key);
        }
    }
}