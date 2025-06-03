using System.Collections.ObjectModel;
using System.Text;

namespace Section03 {
    internal class Program {
        static void Main(string[] args) {
            var languages = new[] { "C#", "Java", "Python", "Ruby", };



            var sb = new StringBuilder();
            foreach (var word in GetWord()) {
                sb.Append(word);
            }
            var text = sb.ToString();
            Console.WriteLine(text);

            string str = "";
            foreach(var word in GetWord()) {
                str += word;
            }
            Console.WriteLine(str);
        }

        private static IEnumerable<object> GetWord() {
            return ["Orange", "Lemon", "Straberry"];


        }
    }
}
