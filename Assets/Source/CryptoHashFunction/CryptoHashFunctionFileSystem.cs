using System;
using System.IO;
using UnityEngine;

namespace Pysijuice.Ciphers {
    public class CryptoHashFunctionFileSystem : MonoBehaviour {
        public static void WriteFile(string text, CryptoHashFunctionType type) {
            using var writer = new StreamWriter(SelectType(type));

            writer.Write(text);
        }

        public static string ReadFile(CryptoHashFunctionType type) {
            return File.ReadAllText(SelectType(type));
        }

        private static string SelectType(CryptoHashFunctionType type) {
            switch (type) {
                case CryptoHashFunctionType.Text:
                    return CryptoHashFunctionPaths.TEXT;

                case CryptoHashFunctionType.Hash:
                    return CryptoHashFunctionPaths.HASH;

                default:
                    throw new Exception();
            }
        }
    }
}