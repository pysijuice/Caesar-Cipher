using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Pysijuice.Ciphers {
    public class ControlPanel : MonoBehaviour {
        public Sender Sender;
        public PostOffice PostOffice;
        public CaesarAttack CaesarAttack;
        public TMP_InputField RawTextField;
        public TMP_InputField KeyField;

        public TMP_Text RawText;
        public TMP_Text EncodedText;
        public TMP_Text DecodedText;
        public TMP_Text KeyText;
        public TMP_Text AttackText;

        public void Encode() {
            if (string.IsNullOrEmpty(RawTextField.text) || string.IsNullOrEmpty(KeyField.text)) {
                return;
            }

            if (!int.TryParse(KeyField.text, out var key)) {
                return;
            }

            StopAllCoroutines();

            var dataInfo = new DataInfo() {
                Data = RawTextField.text,
                Key = key
            };

            Sender.Receive(dataInfo);
            EncodedText.text = PostOffice.EncodedDataInfo.Data;

            UpdateGUI();
        }

        public void Decode() {
            if (string.IsNullOrEmpty(RawTextField.text) || string.IsNullOrEmpty(KeyField.text)) {
                return;
            }

            StopAllCoroutines();

            DecodedText.text = PostOffice.DecodedDataInfo.Data;

            UpdateGUI();
        }

        public void DetectKey() {
            if (Mathf.Clamp(PostOffice.EncodedDataInfo.Key, 1, Alphabet.CAPACITY - 1) != PostOffice.EncodedDataInfo.Key) {
                AttackText.text = "Wrong key!";
                AttackText.color = Color.red;

                return;
            }

            StopAllCoroutines();

            var value = CaesarAttack.DetectKey(Sender.RawDataInfo, PostOffice.EncodedDataInfo);

            if (value == -1) {
                AttackText.text = "Fail!";
                AttackText.color = Color.red;
            } else {
                AttackText.text = "Success!" + " key: " + value;
                AttackText.color = Color.green;
            }

            UpdateGUI();
        }

        public void BruteForce() {
            if (Mathf.Clamp(PostOffice.EncodedDataInfo.Key, 1, Alphabet.CAPACITY - 1) != PostOffice.EncodedDataInfo.Key) {
                AttackText.text = "Wrong key!";
                AttackText.color = Color.red;

                return;
            }

            StartCoroutine(ShowBruteForceRoutine(CaesarAttack.BruteForce(PostOffice.EncodedDataInfo)));
        }

        private void UpdateGUI() {
            if (Mathf.Clamp(PostOffice.EncodedDataInfo.Key, 1, Alphabet.CAPACITY - 1) == PostOffice.EncodedDataInfo.Key) {
                RawText.text = Sender.RawDataInfo.Data;
                KeyText.text = PostOffice.EncodedDataInfo.Key.ToString();
            } else {
                RawText.text = "???";
                EncodedText.text = "???";
                DecodedText.text = "???";
                KeyText.text = "???";
            }
        }

        private IEnumerator ShowBruteForceRoutine(Dictionary<int, string> attackPackage) {
            for (var key = 0; key < attackPackage.Count; key++) {
                UpdateGUI();
                EncodedText.text = attackPackage[key];
                KeyText.text = key.ToString();
                yield return new WaitForSeconds(2.0f);
            }
        }
    }
}