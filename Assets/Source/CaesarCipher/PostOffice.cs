using UnityEngine;

namespace Pysijuice.Ciphers {
    public class PostOffice : MonoBehaviour {
        public Recipient Recipient;
        public DataInfo EncodedDataInfo;
        public DataInfo DecodedDataInfo;
        public CaesarDecoder CaesarDecoder;

        public void Receive(DataInfo dataInfo) {
            EncodedDataInfo = new DataInfo {
                Data = dataInfo.Data,
                Key = dataInfo.Key
            };

            Decode();
            Send();
        }

        private void Decode() {
            DecodedDataInfo = CaesarDecoder.Decode(EncodedDataInfo);
        }

        private void Send() {
            Recipient.Receive(DecodedDataInfo);
        }
    }
}