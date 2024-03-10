using System;
using System.IO;

namespace Pysijuice.Ciphers {
    public class EntropyFileSystem {
        public static void WriteFile(string text, EntropyFileType type) {
            using var writer = new StreamWriter(SelectType(type));

            writer.Write(text);
        }

        public static string ReadFile(EntropyFileType type) {
            return File.ReadAllText(SelectType(type));
        }

        private static string SelectType(EntropyFileType type) {
            switch (type) {
                case EntropyFileType.Text:
                    return EntropyFilePaths.TEXT_PATH;

                case EntropyFileType.Frequency:
                    return EntropyFilePaths.FREQUENCY_PATH;

                case EntropyFileType.FrequencyJson:
                    return EntropyFilePaths.FREQUENCY_JSON_PATH;

                case EntropyFileType.Entropy:
                    return EntropyFilePaths.ENTROPY;

                default:
                    throw new Exception();
            }
        }
    }
}