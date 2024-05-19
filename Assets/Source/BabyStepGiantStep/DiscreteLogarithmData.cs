namespace Pysijuice.Ciphers {
    // y = a^x mod(p), so x is unknown value
    public class DiscreteLogarithmData {
        public int p { get; } = 263;

        public int a { get; } = 79;

        public int y { get; } = 122;
    }
}