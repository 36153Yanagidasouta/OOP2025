using System.Globalization;

namespace ConsoleApp1 {
    internal class Program {
        static void Main(string[] args) {


            var numbers = new List<int> { 12, 87, 94, 14, 53, 20, 40, 35, 76, 91, 31, 17, 48 };


            // 3.1.1
            Exercise1(numbers);
            Console.WriteLine("-----");

            // 3.1.2
            Exercise2(numbers);
            Console.WriteLine("-----");

            // 3.1.3
            Exercise3(numbers);
            Console.WriteLine("-----");

            // 3.1.4
            Exercise4(numbers);

        }
        
        //３－１
        private static void Exercise1(List<int> numbers) {

            var exist = numbers.Exists(s => s % 9 == 0 || s % 8 == 0);
            if (exist) {
                Console.WriteLine("存在している");
            } else {
                Console.WriteLine("存在しない");
            }
        }
        
        //３－２
        private static void Exercise2(List<int> numbers) {

            numbers.ForEach(s => Console.WriteLine(s / 2.0));
        }
        
        //３－３
        private static void Exercise3(List<int> numbers) {

            var quary = numbers.Where(s => s >= 50);

            foreach (var number in quary) {
                Console.WriteLine(number);
            }
        }
        
        //３－４
        private static void Exercise4(List<int> numbers) {

            List<int> selected = numbers.Select(s => s * 2).ToList();

            foreach (var number in selected) {
                Console.WriteLine(number);

            }
            ;
        }
    }
}
