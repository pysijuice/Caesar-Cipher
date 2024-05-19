using UnityEngine;

namespace Pysijuice.Ciphers {
    public class Overhaul : MonoBehaviour {
        private DiscreteLogarithmData _data;

        private int _matchedNumber;
        private int _countOfMultiplications;

        private void Awake() {
            Init();
        }

        private void Init() {
            _data = new DiscreteLogarithmData();
        }

        private void Start() {
            CalculateOverhaul();
        }

        private void CalculateOverhaul() {
            for (uint i = 0; i < _data.p; i++) {
                var result = SmartPow(_data.a, i);

                if (_data.y == result) {
                    Debug.Log($"[Overhaul] x = {i}, it's a solution to the y = a^x mod(p)");
                    break;
                }
            }

            Debug.Log("[Overhaul] Count of multiplications: " + _countOfMultiplications);
        }

        private int SmartPow(int x, uint pow) {
            var result = 1;

            while (pow != 0) {
                if ((pow & 1) == 1) {
                    result = result * x % _data.p;
                    _countOfMultiplications++;
                }

                x = x * x % _data.p;
                _countOfMultiplications++;
                pow >>= 1;
            }

            return result % _data.p;
        }
    }
}