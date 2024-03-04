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

            var frequency = FrequencyCalculator.Calculate();

            EntropyFileSystem.WriteFile(frequency, EntropyFileType.Frequency);

            RawText.text = RawTextField.text;
            FrequencyText.text = frequency;
        }

        public void FindEntropy() {
        }
    }
}