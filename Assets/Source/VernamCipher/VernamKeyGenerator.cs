using System.IO;
using UnityEngine;

namespace Pysijuice.Ciphers {
    public class VernamKeyGenerator : MonoBehaviour {
        private const string FILE_PATH = "Assets/Data/VernamKey.txt";
        private const int FILE_SIZE = 1000;

        private void Awake() {
            GenerateKeyFile();
        }

        private void GenerateKeyFile() {
            using var writer = new StreamWriter(FILE_PATH);

            for (var i = 0; i <= FILE_SIZE; i++) {
                var randomChar = (char)Random.Range('A', 'Z' + 1);
                writer.Write(randomChar);
            }
        }
    }
}
