using TMPro;
using UnityEngine;

namespace Pysijuice.Ciphers {
    public class EntropyControlUI : MonoBehaviour {
        public TMP_InputField RawTextField;

        public TMP_Text RawText;
        public TMP_Text FrequencyText;
        public TMP_Text EntropyText;

        public void FindFrequency() {
            if (string.IsNullOrEmpty(RawTextField.text)) {
                return;
            }

            EntropyFileSystem.WriteFile(RawTextField.text, EntropyFileType.Text);
            FrequencyCalculator.Calculate();

            var frequency = EntropyFileSystem.ReadFile(EntropyFileType.Frequency);

            RawText.text = RawTextField.text;
            FrequencyText.text = frequency;
        }

        public void FindEntropy() {
            if (string.IsNullOrEmpty(RawText.text) || string.IsNullOrEmpty(FrequencyText.text)) {
                return;
            }

            EntropyCalculator.Calculate();

            var entropy = EntropyFileSystem.ReadFile(EntropyFileType.Entropy);

            EntropyText.text = entropy;
        }
    }
}