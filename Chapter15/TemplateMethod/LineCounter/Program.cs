using TextFileProcessor;

namespace LineCounter {
    internal class Program {
        static void Main(string[] args) {

            TextFileProcessor.TextProcessor.Run<LineCounterProcessor>(args[0]);


        }
    }
}
