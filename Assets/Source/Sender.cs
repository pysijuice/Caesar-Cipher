using UnityEngine;

public class Sender : MonoBehaviour {
    public DataInfo RawDataInfo;
    public PostOffice PostOffice;
    public CaesarEncoder CaesarEncoder;

    public void Receive(DataInfo dataInfo) {
        RawDataInfo = dataInfo;
        Send(CaesarEncoder.Encode(RawDataInfo));
    }

    private void Send(DataInfo dataInfo) {
        PostOffice.Receive(dataInfo);
    }
}