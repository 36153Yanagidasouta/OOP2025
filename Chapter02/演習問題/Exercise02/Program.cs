using System.Diagnostics.Metrics;
using System.Threading;

namespace Exercise02 {
    internal class Program {

        static void Main(string[] args) {


            Console.WriteLine("ヤード&メートル変換アプリ;");
            int h = int.Parse(Console.ReadLine());

            if (h == 1) {
                Console.Write("はじめ：");
                int start = int.Parse(Console.ReadLine());
                Console.Write("終わり：");
                int end = int.Parse(Console.ReadLine());
                PrintYardToMeter(start, end);
            } else {
                Console.Write("はじめ：");
                double start = double.Parse(Console.ReadLine());
                Console.Write("終わり：");
                double end = double.Parse(Console.ReadLine());
                PrintMerterToInch(start, end);
                ;

            }
        }

        public static void PrintYardToMeter(int start, int end) {

            InchConverter converter = new InchConverter();

            for (double yard = start; yard <= end; yard++) {
                double meter = converter.InchtToMeter(yard);
                Console.WriteLine($"{yard}inch = {meter:0.0000}m");
            }
        }
        public static void PrintMerterToInch(double start, double end) {

            InchConverter converter = new InchConverter();

            for(double merter = start; merter <= end; merter++) {
                double inch = converter.MeterToInch(merter);
                Console.WriteLine($"{merter}m = {inch:0.0000}" );


            }
        }
    }
}
