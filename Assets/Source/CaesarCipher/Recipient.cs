using UnityEngine;

namespace Pysijuice.Ciphers {
    public class Recipient : MonoBehaviour {
        public DataInfo DecodedDataInfo;

        public void Receive(DataInfo dataInfo) {
            DecodedDataInfo = dataInfo;
        }
    }
}