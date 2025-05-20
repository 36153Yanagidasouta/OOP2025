
using System.Diagnostics.Metrics;

namespace Exercise02 {
    internal class Program {


        static void Main(string[] args) {
            var names = new List<string> {

                "Tokyo", "New Delhi", "Bangkok", "London",
                "Paris", "Berlin", "Canberra", "Hong Kong",
            };

            Console.WriteLine("***** 3.2.1 *****");
            Exercise2_1(names);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.2 *****");
            Exercise2_2(names);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.3 *****");
            Exercise2_3(names);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.4 *****");
            Exercise2_4(names);
            Console.WriteLine();

        }

        private static void Exercise2_1(List<string> names) {


            Console.WriteLine("都市名を入力 :");
            

            while (true) {
                var name = Console.ReadLine();
                if (string.IsNullOrEmpty(name)) {
                    break;
                } else {
                    var index = names.FindIndex(a => a == name);
                    Console.WriteLine(index);
                }
            }
        }

        private static void Exercise2_2(List<string> names) {

            var count =  names.Count(s => s.Contains('o')) ;
                Console.WriteLine(count);  

        }

        private static void Exercise2_3(List<string> names) {

        }

        private static void Exercise2_4(List<string> names) {

        }
    }
}
