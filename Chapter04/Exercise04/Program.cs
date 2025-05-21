

namespace Exercise04 {
    internal class Program {
        static void Main(string[] args) {

            #region nullの判定
            string? name = null;

            if (name is null) {
                Console.WriteLine("nameはnull");
                #endregion

                #region null　合体演算子

                //Sale? sale = new Sale {
                //    ShopName = "新宿店",
                //    ProductCategory = "洋菓子",
                //    Amount = 523100
                //};

                Sale? sale = null;

                int? amount = sale?.Amount;

                Console.WriteLine(amount);
            }

            #endregion


            #region 
            int a = 10;
            int b = 20;

            Console.WriteLine("a =" + a + "b = " + b);
            #endregion

            string? inputData = Console.ReadLine();

            if (int.TryParse(inputData, out var number)) {
                Console.WriteLine(number);
            } else {
                Console.WriteLine("エラー");
            }

            //try {
            //    int num = int.Parse(inputData);
            //    Console.WriteLine(num);
            //}
            //catch (FormatException e) {
            //    Console.WriteLine("フォーマットエラー");
            //}
            //catch (OverflowException e) {
            //    Console.WriteLine("入力値が大きすぎます");
            //}
            //finally {
            //    Console.WriteLine("準備完了");

            //}
            //Console.WriteLine("メソッド終了");
        }


        private static object? GetMessage(string code) {
            return code;
        }

        private static object? DefaultMessage() {
            return "DefaultMessage";
        }
    }

    public class Sale
 // 売り上げクラス
 {
        //店舗名
        public string ShopName { get; set; } = String.Empty;

        //商品カテゴリ
        public string ProductCategory { get; set; } = String.Empty;

        //売上高
        public int Amount { get; set; }
    }
}
