using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Pysijuice.Ciphers {
    public static class CryptoHashFunction {
        private const string HEXADECIMAL = "x2";

        public static string Calculate(string input) {
            using var sha256Hash = SHA256.Create();

            var bytes = Encoding.UTF8.GetBytes(input);
            var hash = sha256Hash.ComputeHash(bytes);

            var builder = new StringBuilder();

            foreach (var value in hash) {
                builder.Append(value.ToString(HEXADECIMAL));
            }

            return builder.ToString();
        }

        public static Dictionary<string, int> GeneratePseudorandomNumbers() {
            using var sha256Hash = SHA256.Create();

            var dictionary = new Dictionary<string, int>();

            for (var i = 0; i < 10; i++) {
                var hash = Calculate(i.ToString());
                var rndValue = int.Parse(hash.Substring(0, 4), System.Globalization.NumberStyles.HexNumber);

                dictionary.Add(hash.Substring(0, 4), rndValue);
            }

            return dictionary;
        }
    }
}