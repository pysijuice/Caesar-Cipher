using System;
using System.IO;
using System.Text;
using UnityEngine;

namespace Pysijuice.Ciphers {
    public class SteganographyHider : MonoBehaviour {
        public static void HideMessage(string inputImagePath, string outputImagePath, string message) {
            var bmpBytes = File.ReadAllBytes(inputImagePath);
            var messageBytes = Encoding.UTF8.GetBytes(message);
            var messageLengthBytes = BitConverter.GetBytes(messageBytes.Length);

            var headerSize = BitConverter.ToInt32(bmpBytes, 10); // Offset to start of pixel data
            var messageIndex = 0;

            for (var i = headerSize; i < bmpBytes.Length; i++) {
                if (messageIndex < messageLengthBytes.Length * 8) {
                    bmpBytes[i] = (byte)((bmpBytes[i] & ~1) | ((messageLengthBytes[messageIndex / 8] >> (messageIndex % 8)) & 1));
                    messageIndex++;
                } else if (messageIndex < (messageLengthBytes.Length * 8 + messageBytes.Length * 8)) {
                    bmpBytes[i] = (byte)((bmpBytes[i] & ~1)
                                         | ((messageBytes[(messageIndex - messageLengthBytes.Length * 8) / 8]
                                             >> ((messageIndex - messageLengthBytes.Length * 8) % 8))
                                            & 1));
                    messageIndex++;
                } else {
                    break;
                }
            }

            File.WriteAllBytes(outputImagePath, bmpBytes);
        }
    }
}