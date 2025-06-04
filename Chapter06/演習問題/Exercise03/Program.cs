
using System.Runtime.InteropServices;
using System.Text;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";
            #region            Console.WriteLine("6.3.1");
            Exercise1(text);

            Console.WriteLine("6.3.2");
            Exercise2(text);

            Console.WriteLine("6.3.3");
            Exercise3(text);

            Console.WriteLine("6.3.4");
            Exercise4(text);

            Console.WriteLine("6.3.5");
            Exercise5(text);

            Console.WriteLine("6.3.99");
            Exercise6(text);
            #endregion
        }

        private static void Exercise6(string text) {

            /*List<char> WordsList = new List<char>();
              List<int> AnserList = new List<int>();

              foreach (var c in text.Order().ToLower()) {
                  WordsList.Add(c);
                  if (WordsList[c] == WordsList[c - 1]) {
                      AnserList[c] = 1;
                  } else {
                      AnserList[c - 1] += 1;
                  }
                  Console.WriteLine(AnserList);
              }*/

            var str = text.ToLower().Replace(" ","");
            var alphaDicCount = Enumerable.Range('a', 26)
                                .ToDictionary(num => ((char)num).ToString(), num => 0);
             foreach(var alpha in str) {
                alphaDicCount[alpha.ToString()]++;
            }                                    
            
             foreach(var item in alphaDicCount) {
                Console.WriteLine($"{item.Key}:{item.Value}");

            }

            /*   ----------------     */
            var array = Enumerable.Repeat(0, 26).ToArray();

            foreach (var alph in str) {
                array[alph - 'a']++;
            }

            for(char ch = 'a';ch <= 'z';ch++ ) {
                Console.WriteLine($"{ch}:{array[ch -'a']}");
            }


        }

        private static void Exercise1(string text) {
            var spaces = text.Count(c => c == ' ');
            //var spaces = text.Count(char.IsWhiteSpace);//別解
            Console.WriteLine("空白数:{0}", spaces);
        }

        private static void Exercise2(string text) {
            var replaced = text.Replace("big", "small");
            Console.WriteLine(replaced);
        }

        private static void Exercise3(string text) {

            var array = text.Split(' ');
            var sb = new StringBuilder();
            foreach (var word in array) {
                sb.Append(word + " ");
            }

            var anser = sb.ToString().TrimEnd();
            Console.WriteLine(anser + ".");
        }

        private static void Exercise4(string text) {
            var count = text.Split(' ').Length;
            Console.WriteLine("単語数:{0}", count);
        }

        private static void Exercise5(string text) {
            var words = text.Split(' ').Where(s => s.Length <= 4);

            foreach (var word in words)
                Console.WriteLine(word);
        }
    }
}
