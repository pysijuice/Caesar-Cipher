using System;
using System.Text;
using RC4Cryptography;
using UnityEngine;

public class RC4Test : MonoBehaviour {
    private const string PHRASE = "Now i'm testing RC4 algorithm";
    private const string KEY_PHRASE = "Very secret code";

    private void Start() {
        var data = Encoding.UTF8.GetBytes(PHRASE);
        var key = Encoding.UTF8.GetBytes(KEY_PHRASE);

        var encrypted_data = RC4.Apply(data, key);
        var decrypted_data = RC4.Apply(encrypted_data, key);

        var decrypted_phrase = Encoding.UTF8.GetString(decrypted_data);

        Debug.Log("RC4 phrase: " + PHRASE);
        Debug.Log("Key phrase: " + KEY_PHRASE);
        Debug.Log("Encryption result: " + BitConverter.ToString(encrypted_data));
        Debug.Log("Decrypted Phrase: " + decrypted_phrase);
    }
}