using UnityEngine;

namespace Pysijuice.Ciphers {
    public class CaesarDecoder : MonoBehaviour {
        public CaesarEncoder CaesarEncoder;

        public DataInfo Decode(DataInfo dataInfo) {
            dataInfo.Key = -dataInfo.Key;
            return CaesarEncoder.Encode(dataInfo);
        }
    }
}