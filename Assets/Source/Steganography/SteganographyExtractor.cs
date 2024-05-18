using System;
using System.IO;
using System.Text;

namespace Pysijuice.Ciphers {
    public static class SteganographyExtractor {
        public static string ExtractMessage(string inputImagePath) {
            var bmpBytes = File.ReadAllBytes(inputImagePath);
            var messageLengthBytes = new byte[4];
            var headerSize = BitConverter.ToInt32(bmpBytes, 10); // Offset to start of pixel data
            var messageIndex = 0;

            for (var i = headerSize; i < bmpBytes.Length; i++) {
                if (messageIndex < messageLengthBytes.Length * 8) {
                    messageLengthBytes[messageIndex / 8] =
                        (byte)((messageLengthBytes[messageIndex / 8] & ~(1 << (messageIndex % 8))) | ((bmpBytes[i] & 1) << (messageIndex % 8)));
                    messageIndex++;
                } else {
                    break;
                }
            }

            var messageLength = BitConverter.ToInt32(messageLengthBytes, 0);
            var messageBytes = new byte[messageLength];
            messageIndex = 0;

            for (var i = headerSize + 32; i < bmpBytes.Length; i++) // Skip the length bytes
            {
                if (messageIndex < messageBytes.Length * 8) {
                    messageBytes[messageIndex / 8] =
                        (byte)((messageBytes[messageIndex / 8] & ~(1 << (messageIndex % 8))) | ((bmpBytes[i] & 1) << (messageIndex % 8)));
                    messageIndex++;
                } else {
                    break;
                }
            }

            return Encoding.UTF8.GetString(messageBytes);
        }
    }
}