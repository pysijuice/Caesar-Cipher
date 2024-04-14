using TMPro;
using UnityEngine;

namespace Pysijuice.Ciphers {
    public class CryptoHashFunctionControlUI : MonoBehaviour {
        public TMP_InputField RawTextField;

        public TMP_Text RawText;
        public TMP_Text HashText;
        public TMP_Text PRNText;

        public void CalculateHash() {
            if (string.IsNullOrEmpty(RawTextField.text)) {
                return;
            }

            CryptoHashFunctionFileSystem.WriteFile(RawTextField.text, CryptoHashFunctionType.Text);

            var hash = CryptoHashFunction.Calculate(CryptoHashFunctionFileSystem.ReadFile(CryptoHashFunctionType.Text));

            CryptoHashFunctionFileSystem.WriteFile(hash, CryptoHashFunctionType.Hash);

            RawText.text = RawTextField.text;
            HashText.text = hash;
        }

        public void GeneratePseudorandomNumbers() {
            var pseudorandomNumbers = CryptoHashFunction.GeneratePseudorandomNumbers();
            var text = "";

            foreach (var number in pseudorandomNumbers) {
                text += $"{number.Key}: {number.Value}\n";
            }

            PRNText.text = text;
        }
    }
}