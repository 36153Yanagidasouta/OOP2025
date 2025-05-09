namespace SalesCalculator {
    internal class Program {
        static void Main(string[] args) {

            SalesCounter sales = new SalesCounter(ReadSales(@"data\Sales.csv") );
          Dictionary<string,int> amountsPerStore =  sales.GetPerStoreSales();
            foreach (KeyValuePair<string, int> obj in amountsPerStore) {
                Console.WriteLine($"{obj.Key} {obj.Value}");
            }
        }

        //売り上げデータ読み込み、Saleオブジェクトのリストを返す
        static List<Sale> ReadSales(string filePath) {
         
            //売り上げデーターを入れるリストオブジェクトを生成
            List<Sale> sales = new List<Sale>();

            //ファイルを一気に読み込み
            string[] lines = File.ReadAllLines(filePath);

            //一回ずつ文字列を持ってくる
            foreach (string line in lines) {

                string[] items = line.Split(',');
                
                //Saleオブジェクトを生成
                Sale sale = new Sale() {
                    ShopName = items[0],
                    ProductCategory = items[1],
                    Amount = int.Parse(items[2])
                };

                sales.Add(sale);
            }

            return sales;
        }
    }
}
