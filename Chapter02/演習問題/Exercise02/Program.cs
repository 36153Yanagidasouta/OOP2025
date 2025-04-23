using System.Diagnostics.Metrics;
using System.Threading;

namespace Exercise02 {
    internal class Program {

        static void Main(string[] args) {

            int start = 1;
            int end = 10;

            PrintInchtToMeter(start, end);

        }
        
        public static void PrintInchtToMeter(int start, int end) {
            
            InchConverter converter = new InchConverter();

            for (int inch = start; inch <= end; inch++) {
                double meter = converter.InchtToMeter(inch);
                Console.WriteLine($"{inch}inch = {meter:0.0000}m");
                    }
                }
            }
        }
    

