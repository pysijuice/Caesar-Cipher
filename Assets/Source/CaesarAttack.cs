using System.Collections.Generic;
using UnityEngine;

public class CaesarAttack : MonoBehaviour {
    public CaesarDecoder CaesarDecoder;

    public int DetectKey(DataInfo rawData, DataInfo encodedData) {
        for (var key = 1; key < Alphabet.CAPACITY; key++) {
            var data = new DataInfo {
                Data = encodedData.Data,
                Key = key
            };

            var decryptedText = CaesarDecoder.Decode(data).Data;

            if (decryptedText.Equals(rawData.Data)) {
                return key;
            }
        }

        return -1;
    }

    public Dictionary<int, string> BruteForce(DataInfo encodedData) {
        var decodedVariants = new Dictionary<int, string>();

        for (var key = 0; key < Alphabet.CAPACITY; key++) {
            var data = new DataInfo {
                Data = encodedData.Data,
                Key = key
            };

            var decodedData = CaesarDecoder.Decode(data).Data;

            decodedVariants.Add(key, decodedData);
        }

        return decodedVariants;
    }
}