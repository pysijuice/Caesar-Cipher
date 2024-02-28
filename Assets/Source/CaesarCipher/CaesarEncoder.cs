using UnityEngine;

namespace Pysijuice.Ciphers {
    public class CaesarEncoder : MonoBehaviour {
        public DataInfo Encode(DataInfo dataInfo) {
            var encodedData = new DataInfo {
                Data = null,
                Key = dataInfo.Key
            };

            foreach (var symbol in dataInfo.Data) {
                if (char.IsLetter(symbol)) {
                    var offset = char.IsUpper(symbol) ? 'A' : 'a';
                    var encryptedSymbol = (char)((symbol + dataInfo.Key - offset + Alphabet.CAPACITY) % Alphabet.CAPACITY + offset);

                    encodedData.Data += encryptedSymbol;
                } else {
                    encodedData.Data += symbol;
                }
            }

            return encodedData;
        }
    }
}