using TMPro;
using UnityEngine;

namespace Pysijuice.Ciphers {
    public class AesControlUI : MonoBehaviour {
        public TMP_InputField RawTextField;

        public TMP_Text RawText;
        public TMP_Text KeyText;
        public TMP_Text EncryptedText;
        public TMP_Text DecryptedText;

        public void Encrypt() {
            if (string.IsNullOrEmpty(RawTextField.text)) {
                return;
            }

            AesFileSystem.WriteFile(RawTextField.text, AesFileType.Text);

            AesCipher.GenerateKey();
            AesCipher.Encrypt();

            RawText.text = RawTextField.text;
            KeyText.text = AesFileSystem.ReadFile(AesFileType.Key);
            EncryptedText.text = AesFileSystem.ReadFile(AesFileType.Encrypted);
        }

        public void Decrypt() {
            if (string.IsNullOrEmpty(RawText.text) || string.IsNullOrEmpty(EncryptedText.text)) {
                return;
            }

            AesCipher.Decrypt();

            DecryptedText.text = AesFileSystem.ReadFile(AesFileType.Decrypted);
        }
    }
}