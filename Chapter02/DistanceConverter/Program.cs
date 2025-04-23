
using System.Diagnostics.Metrics;
using System.Threading;

namespace DistanceConverter {
    internal class Program {


        static void Main(string[] args) {

            



            int start = int.Parse(args[1]);
            int end = int.Parse(args[2]);

            if (args.Length >= 0 && args[0] == "-tom") {
                PrintFeetToMeterList(start, end);
            } else {
 //               PrintMeterToFeetList(start, end);

            }
        }

/*        private static void PrintMeterToFeetList(int start, int end) {
            for (int meter = start; meter <= end; meter++) { 
            double feet = FeetConverter.MeterToFeet(meter);
            Console.WriteLine($"{meter}m = {feet:0.0000}ft");
                }
        }*/

        private static void PrintFeetToMeterList(int start, int end) {

            for (int feet = start; feet <= end; feet++) {
                double meter = FeetConverter.FeetToMeter(feet);
                Console.WriteLine($"{feet}ft = {meter:0.0000}m");
            }

        }
    }
}



