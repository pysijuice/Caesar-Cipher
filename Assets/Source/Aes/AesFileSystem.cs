using System;
using System.IO;

namespace Pysijuice.Ciphers {
    public class AesFileSystem {
        public static void WriteFile(string text, AesFileType type) {
            using var writer = new StreamWriter(SelectType(type));

            writer.Write(text);
        }

        public static string ReadFile(AesFileType type) {
            return File.ReadAllText(SelectType(type));
        }

        private static string SelectType(AesFileType type) {
            switch (type) {
                case AesFileType.Text:
                    return AesFilePaths.TEXT;

                case AesFileType.Key:
                    return AesFilePaths.KEY;

                case AesFileType.Encrypted:
                    return AesFilePaths.ENCRYPTED_TEXT;

                case AesFileType.Decrypted:
                    return AesFilePaths.DECRYPTED_TEXT;

                default:
                    throw new Exception();
            }
        }
    }
}