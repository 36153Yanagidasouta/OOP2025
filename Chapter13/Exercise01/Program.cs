
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {



            Exercise1_2();


            Exercise1_3();
            Console.WriteLine();
            Exercise1_4();
            Console.WriteLine();
            Exercise1_5();
            Console.WriteLine();
            Exercise1_6();
            Console.WriteLine();
            Exercise1_7();
            Console.WriteLine();
            Exercise1_8();

            Console.ReadLine();
        }

        private static void Exercise1_2() {

            var book = Library.Books
                        .MaxBy(b => b.Price);
            Console.WriteLine(book);

        }

        private static void Exercise1_3() {

            var groups = Library.Books
            .GroupBy(b => b.PublishedYear)
            .OrderBy(g => g.Key)
            .GroupBy(g => g.Count());
            foreach (var item in groups) {
                foreach (var book in item) {
                    Console.WriteLine($"  {book.Key}年:{book.Count()}");
                }
            }
        }



        private static void Exercise1_4() {
            var groups = Library.Books
            .OrderByDescending(g => g.PublishedYear)
            .ThenBy(b => b.CategoryId)
            .ThenBy(b => b.Price);
            foreach (var group in groups) {
                Console.WriteLine(group);
            }
        }

        private static void Exercise1_5() {
            var categories = Library.Categories;
            var groups = Library.Books
            .Where(b => b.PublishedYear == 2022);
            foreach (var item in categories) {
                Console.WriteLine($"{item} ");
            }
        }

        private static void Exercise1_6() {



        }

        private static void Exercise1_7() {

        }

        private static void Exercise1_8() {

        }
    }
}
