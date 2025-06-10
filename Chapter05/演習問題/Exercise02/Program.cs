using Exercise01;
using Microsoft.VisualBasic;

namespace Exercise02 {
    public class Program {
        static void Main(string[] args) {
            // 5.2.1
            var ymCollection = new YearMonth[] {
                new YearMonth(1980, 1),
                new YearMonth(1990, 4),
                new YearMonth(2000, 7),
                new YearMonth(2010, 9),
                new YearMonth(2024, 12),
            };

            Console.WriteLine("5.2.2");
            Exercise2(ymCollection);

            Console.WriteLine("5.2.3");
            FindFirst21C(ymCollection);

            Console.WriteLine("5.2.4");
            Exercise4(ymCollection);


            Console.WriteLine("5.2.5");
            Exercise5(ymCollection);
        }

        // 5.2.2
        private static void Exercise2(YearMonth[] ymCollection) {

            foreach (var n in ymCollection) {
                Console.WriteLine(n);
            }
        }

        // 5.2.3
        //ここにメソッドを作成【メソッド名：FindFirst21C】

        private static YearMonth? FindFirst21C(YearMonth[] ymCollection) {
            foreach (var n in ymCollection) {
                if (n.Is21Century) {
                    return n;
                }
            }
            return null;
        }

        // 5.2.4
        private static void Exercise4(YearMonth[] ymCollection) {
            // var ym = FindFirst21C(ymCollection);

            // if(ym == null) {
            //        Console.WriteLine("21世紀のデータは見つかりません");
            //    } else {
            //        Console.WriteLine( ym );
            //    }
            //}
            var yearMonth = FindFirst21C(ymCollection);
            var str = yearMonth?.ToString() ?? "21世紀のデータはありません";
            Console.WriteLine(str);

            Console.WriteLine(FindFirst21C(ymCollection)?.ToString() ?? "21世紀のデータはありません");
        }


        // 5.2.5
        private static void Exercise5(YearMonth[] ymCollection) {
            var array = ymCollection.Select(s => s.AddOneMonth()).ToArray();
            Console.WriteLine(array);
        }
    }
}
