using TextFileProcessor;

namespace LineCounter {
    internal class Program {
        static void Main(string[] args) {

            Console.WriteLine("URL");
            string path = Console.ReadLine();
            TextProcessor.Run<LineCounterProcessor>(path);
        }
    }
}
