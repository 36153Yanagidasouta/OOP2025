namespace Test01 {
    public class ScoreCounter {
        private IEnumerable<Student> _score;

        // コンストラクタ
        public ScoreCounter(string filePath) {
            _score = ReadScore(filePath);

        }


        //まだ手をつけられてません


        //メソッドの概要： 
        public static IEnumerable<Student> ReadScore(string filePath) {
            var dict = new SortedDictionary<string, int>();
            foreach (var sale in _sales) {
                if (dict.ContainsKey(sale.ShopName)) {
                    dict[sale.ShopName] += sale.Amount;
                } else {
                    dict[sale.ShopName] = sale.Amount;
                }
            }
            return dict;

        }

        //メソッドの概要： 
        public IDictionary<string, int> GetPerStudentScore() {
            




        }
    }
}
