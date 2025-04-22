
using System.Diagnostics.Metrics;

namespace DistanceConverter {
    internal class Program {
        static void Main(string[] args) {

            int start = int.Parse(args[1]);
            int end = int.Parse(args[2]);

            if (args.Length >= 1 && args[0] == "-tom") {
                FeetToMeter(start, end);
            } else {
                MeterToFeet(start, end);

            }
        }

        static void FeetToMeter(int start,int end) {
            for (int feet = start; feet <= end; feet++) {
                double meter = FeetToMeter(feet);
                Console.WriteLine($"{feet}ft = {meter:0.0000}m");
            }
        }

        private static double FeetToMeter(int feet) {
            return feet * 0.3084;
        }

        static void MeterToFeet(int start,int end){
            for (int meter = start; meter <= end meter++) ;
            double feet = MeterToFeet(meter);
            Console.WriteLine($"{meter}m = {feet:0.0000}ft");

            
            }

       static double  MeterToFeet(object meter) {
            return meter / 0.3048;
        }
    }

    


    }           

