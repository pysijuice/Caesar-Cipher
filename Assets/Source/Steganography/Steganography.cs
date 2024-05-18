using UnityEngine;

namespace Pysijuice.Ciphers {
    public class Steganography : MonoBehaviour {
        private const string MESSAGE = "Hello, world!";

        private void Awake() {
            SteganographyHider.HideMessage(SteganographyFilePaths.RAW_IMAGE, SteganographyFilePaths.ENCODED_IMAGE, MESSAGE);

            var extractedMessage = SteganographyExtractor.ExtractMessage(SteganographyFilePaths.ENCODED_IMAGE);
            Debug.Log("Extracted Message: " + extractedMessage);
        }
    }
}