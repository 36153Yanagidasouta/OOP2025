using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProductSample {
    internal class Program {
        static void Main(string[] args) {

            Product karinto = new Product(123, "かりんとう", 180);

            Product daihuku = new Product(323, "大福",380);


            Console.WriteLine( daihuku.Name+ "の平均価格はだいたい" +daihuku.Code + "円らしい");
            



            //税抜き価格の表示

            Console.WriteLine("税抜き価格:"+ karinto.Code);


            //消費税額の表示
            Console.WriteLine("消費税額:"+ karinto.GetTax());



            //税込み価格
            Console.WriteLine("税込み:"+ karinto.Price);

            
        }
    }
}
