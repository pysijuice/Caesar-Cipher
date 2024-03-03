using TMPro;
using UnityEngine;

namespace Pysijuice.Ciphers {
    public class VernamControlUI : MonoBehaviour {
        public TMP_InputField RawTextField;

        public TMP_Text RawText;
        public TMP_Text KeyText;
        public TMP_Text EncryptedText;
        public TMP_Text DecryptedText;

        public void Encrypt() {
            if (string.IsNullOrEmpty(RawTextField.text)) {
                return;
            }

            VernamPlainTextCreator.CreateText(RawTextField.text);
            VernamKeyGenerator.GenerateKey();
            VernamCipher.Encrypt();

            RawText.text = RawTextField.text;
            KeyText.text = VernamFileSystem.ReadFile(VernamFileType.Key);
            EncryptedText.text = VernamFileSystem.ReadFile(VernamFileType.Encrypted);
        }

        public void Decrypt() {
            if (string.IsNullOrEmpty(RawText.text)) {
                return;
            }

            VernamCipher.Decrypt();

            DecryptedText.text = VernamFileSystem.ReadFile(VernamFileType.Decrypted);
        }
    }
}