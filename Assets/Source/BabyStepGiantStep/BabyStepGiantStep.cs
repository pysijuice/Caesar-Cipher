using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Pysijuice.Ciphers {
    public class BabyStepGiantStep : MonoBehaviour {
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
            Calculate();
        }

        private void Calculate() {
            var m = (int)Math.Ceiling(Math.Sqrt(_data.p - 1));

            var babysteps = BabyStep(m);
            var giantIndex = GiantStep(babysteps, m);
            var babyIndex = babysteps.FirstOrDefault(x => x.Value == _matchedNumber).Key;

            var result = giantIndex * m - babyIndex;

            Debug.Log($"[BabyStepGiantStep] x = {result}, it's a solution to the y = a^x mod(p)");
            Debug.Log("[BabyStepGiantStep] Count of multiplications: " + _countOfMultiplications);
        }

        // y, ay, a^2 * y, ... , a^(m-1) * y (mod(p))
        private Dictionary<uint, int> BabyStep(int m) {
            var babySteps = new Dictionary<uint, int>();

            for (uint i = 0; i <= m - 1; i++) {
                var value = SmartPow(_data.a, i) * _data.y % _data.p;
                _countOfMultiplications++;
                babySteps.Add(i, value);

                Debug.Log($"Baby step: (a^{i} * y) mod p = {value} (index = {i})");
            }

            return babySteps;
        }

        // a^m, a^(2*m), ... , a^(m*m) (mod(p))
        private uint GiantStep(Dictionary<uint, int> babySteps, int m) {
            for (uint i = 1; i <= m; i++) {
                var value = SmartPow(_data.a, (uint)m * i);
                _countOfMultiplications++;

                if (babySteps.ContainsValue(value)) {
                    _matchedNumber = value;
                    Debug.Log($"Giant step: a^({i} * m) mod p = {value} (index = {i})");
                    return i;
                }

                Debug.Log($"Giant step: a^({i} * m) mod p = {value} (index = {i})");
            }
            throw new ArgumentNullException("[BabyStepGiantStep] There's no matching in the Baby step and the Giant step");
        }

        private int SmartPow(int x, uint y) {
            var result = 1;

            while (y != 0) {
                if ((y & 1) == 1) {
                    result = result * x % _data.p;
                    _countOfMultiplications++;
                }

                x = x * x % _data.p;
                _countOfMultiplications++;
                y >>= 1;
            }

            return result % _data.p;
        }
    }
}
