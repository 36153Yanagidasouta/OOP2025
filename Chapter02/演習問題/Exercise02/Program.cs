using System.Diagnostics.Metrics;
using System.Threading;

namespace Exercise02 {
    internal class Program {

        static void Main(string[] args) {


            Console.WriteLine("変換アプリ;");
            int hantei = int.Parse(Console.ReadLine());

            if (hantei == 1) {
                Console.Write("はじめ：");
                int start = int.Parse(Console.ReadLine());
                Console.Write("終わり：");
                int end = int.Parse(Console.ReadLine());
                PrintInchtToMeter(start, end);
            } else {
                Console.Write("はじめ：");
                double start = double.Parse(Console.ReadLine());
                Console.Write("終わり：");
                double end = double.Parse(Console.ReadLine());
                PrintMerterToInch(start, end);
                ;

            }
        }

        public static void PrintInchtToMeter(int start, int end) {

            InchConverter converter = new InchConverter();

            for (int inch = start; inch <= end; inch++) {
                double meter = converter.InchtToMeter(inch);
                Console.WriteLine($"{inch}inch = {meter:0.0000}m");
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
