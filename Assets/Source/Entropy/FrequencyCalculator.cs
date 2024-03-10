using System.Collections.Generic;
using Newtonsoft.Json;

namespace Pysijuice.Ciphers {
    public class FrequencyCalculator {
        public static void Calculate() {
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

            EntropyFileSystem.WriteFile(JsonConvert.SerializeObject(frequencies), EntropyFileType.FrequencyJson);
            EntropyFileSystem.WriteFile(result, EntropyFileType.Frequency);
        }
    }
}