
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

        //private static void Exercise1_5() {
        //    var categories = Library.Categories;
        //    var groups = Library.Books
        //    .Where(b => b.PublishedYear == 2022);
        //    foreach (var item in categories) {
        //        Console.WriteLine($"{groups} ");
        //    }
        //}


        //正解答例
        private static void Exercise1_5() {
            var books = Library.Books
                .Join(Library.Categories
                        , book => book.CategoryId
                        , Category => Category.Id,
                        (book, category) => new {
                            book.Title,
                            Category = category.Name,
                            book.PublishedYear
                        })
                .Where(b => b.PublishedYear == 2022)
                .OrderBy(b => b.PublishedYear)
                .ThenBy(b => b.Category)
                .DistinctBy(b => b.Category);
            foreach (var book in books) {
                Console.WriteLine($"{book.Category}");
            }
        }

        private static void Exercise1_6() {
            var groups = Library.Books
                .Join(Library.Categories
                        , b => b.CategoryId
                        , c => c.Id,
                        (b, c) => new {
                            CategoryName = c.Name,
                            b.Title
                        })
                  .GroupBy(x => x.CategoryName)
                  .OrderBy(x => x.Key);
            foreach (var group in groups) {
                Console.WriteLine($"#{group.Key}");
                foreach (var item in group) {
                    Console.WriteLine("   " + $"{item.Title}");
                }
            }
        }

        private static void Exercise1_7() {
            var groups = Library.Categories
                .GroupJoin(Library.Books,
                c => c.Id,
                b => b.CategoryId,
                (c, books) => new {
                    CategoryName = c.Name,
                    Books = books
                });
            foreach (var group in groups) {
                Console.WriteLine(group.CategoryName);
                foreach (var book in group.Books) {
                    Console.WriteLine($"{book.Title} ({book.PublishedYear})年");
                }
            }
        }

        private static void Exercise1_8() {
            var CategoryNames = Library.Categories
                .GroupJoin(Library.Books,
                c => c.Id,
                b => b.CategoryId,
                (c, books) => new {
                    CategoryName = c.Name,
                    Count = books.Count()
                })
                .Where(c => c.Count == 4)
                .Select(x => x.CategoryName);   
            foreach (var name in CategoryNames ) {
                Console.WriteLine(name);    
            }
        }
    }
}
