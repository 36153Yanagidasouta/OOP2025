
using System.Diagnostics.Metrics;

namespace DistanceConverter {
    internal class Program {
        static void Main(string[] args) {

            int start = int.Parse(args[1]);
            int end = int.Parse(args[2]);

            if (args.Length >= 1 && args[0] == "-tom") {
                FeetToMeter(1, 10);
            } else {
                MeterToFeet(1, 10);

            }
        }

        

        static void FeetToMeter(int start,int stop) {
            for (int feet = start; feet <= stop; feet++) {
                double meter = FeetToMeter(feet);
                Console.WriteLine($"{feet}ft = {meter:0.0000}m");
            }
        }

        static void MeterToFeet(int start,int stop){
            for (int meter = start; meter <= stop meter++) ;
            double feet = MeterToFeet(meter);
            Console.WriteLine($"{meter}m = {feet:0.0000}ft");

            
            }
        
        }

    }           

