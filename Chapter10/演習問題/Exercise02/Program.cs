namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            var filePath = "source.txt";
            var lines = File.ReadLines(filePath)
                        .Select((s, ix) => $"{ix + 1,4}:{s}");

            var filPath2 = "newsource.txt";
            using (var writer = new StreamWriter(filPath2)) {
                foreach (var line in lines) {
                    writer.WriteLine(line);
                }
            }
        }
    }
}