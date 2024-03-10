using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;

namespace Pysijuice.Ciphers {
    public class EntropyCalculator {
        public static void Calculate() {
            var frequency = JsonConvert.DeserializeObject<Dictionary<char, int>>(EntropyFileSystem.ReadFile(EntropyFileType.FrequencyJson));
            var entropy = 0.0;
            var textLength = 0;

            foreach (var pair in frequency) {
                textLength += pair.Value;
            }

            foreach (var pair in frequency) {
                var probability = (double)pair.Value / textLength;

                entropy += probability * -Math.Log(probability, 2.0);
            }

            EntropyFileSystem.WriteFile(entropy.ToString(CultureInfo.CurrentCulture), EntropyFileType.Entropy);
        }
    }
}