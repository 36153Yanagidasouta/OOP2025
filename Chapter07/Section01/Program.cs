namespace Section01 {
    internal class Program {
        static void Main(string[] args) {


            var books = Books.GetBooks();

            //1.本の平均金額を表示
            Console.WriteLine("平均価格" + books.Average(b => b.Price));

            //2.本のページ合計を表示
            Console.WriteLine("ページ合計" + books.Sum(b => b.Pages));

            //3.金額の安い書籍名と金額を表示
            var minprice = books.Where(x => x.Price == books.Min(b => b.Price)).First();
            Console.WriteLine("一番安い書籍とその値段:" + minprice.Title + minprice.Price +"円");

           

            //4.ページの多い書籍名とページ数を表示
            var maxpages = books.Where(x => x.Pages == books.Max(b => b.Pages)).First();
            Console.WriteLine("一番ページの多い書籍名とページ数:" + maxpages.Title + maxpages.Pages + "ページ");

            //books.Where(x => x.Pages == books.Max(b => b.Pages)).ToList()
            //    .ForEach(x => Console.WriteLine($"{x.Title} : {x.Pages}ページ"));

            //5.タイトルに「物語」が含まれている書籍名をすべて表示

            foreach (var result in books.Where(b => b.Title.Contains("物語"))) {

                Console.WriteLine(result.Title);
            }
        }
    }
}
