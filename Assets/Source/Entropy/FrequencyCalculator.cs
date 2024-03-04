using System.Collections.Generic;

namespace Pysijuice.Ciphers {
    public class FrequencyCalculator {
        public static string Calculate() {
            var frequencies = new Dictionary<char, int>();
            var text = EntropyFileSystem.ReadFile(EntropyFileType.Text);

            foreach (var character in text) {
                if (!frequencies.TryAdd(character, 1)) {
                    frequencies[character]++;
                }
            }

            var result = "";

            foreach (var pair in frequencies) {
                result += $"{pair.Key}: {pair.Value}, ";
            }

            return result;
        }
    }
}