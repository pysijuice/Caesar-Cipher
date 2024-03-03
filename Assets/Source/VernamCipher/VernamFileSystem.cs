using System;
using System.IO;

namespace Pysijuice.Ciphers {
    public class VernamFileSystem {
        public static void WriteFile(string text, VernamFileType type) {
            using var writer = new StreamWriter(SelectType(type));

            writer.Write(text);
        }

        public static string ReadFile(VernamFileType type) {
            return File.ReadAllText(SelectType(type));
        }

        private static string SelectType(VernamFileType type) {
            switch (type) {
                case VernamFileType.Key:
                    return VernamCipherPaths.KEY_PATH;

                case VernamFileType.PlainText:
                    return VernamCipherPaths.PLAIN_TEXT_PATH;

                case VernamFileType.Encrypted:
                    return VernamCipherPaths.ENCRYPTED_TEXT_PATH;

                case VernamFileType.Decrypted:
                    return VernamCipherPaths.DECRYPTED_TEXT_PATH;

                default:
                    throw new Exception();
            }
        }
    }
}