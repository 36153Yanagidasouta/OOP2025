namespace Section01 {
    internal class Program {
        static void Main(string[] args) {

            Console.WriteLine("カウントしたい数値 :");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine(Count(num));

        }

        public static int Count(int num) {
            var numbers = new[] { 5, 3, 9, 6, 7, 5, 8, 1, 0, 5, 10, 4, };
            var count = num;
            foreach (var n in numbers) {
                if (n == num) {
                    count++;
                }
            }
            return count;
        }
    }
}
