namespace Pysijuice.Ciphers {
    public class VernamPlainTextCreator {
        public static void CreateText(string text) {
            VernamFileSystem.WriteFile(text, VernamFileType.PlainText);
        }
    }
}