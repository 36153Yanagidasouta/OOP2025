using static System.Net.Mime.MediaTypeNames;

namespace Exercise04 {
    internal class Program {
        static void Main(string[] args) {
            var line = "Novelist=柴塚健斗;BestWork=伊藤伝記;Born=2005";

            foreach (var pair in line.Split(';')) {
                var word = pair.Split('=');
                Console.WriteLine($" {ToJapanese(word[0])}:{word[1]}");

            }

            /// </summary>
            /// <param name="key">"Novelist","BestWork","Born"</param>
            /// <returns>"「作家」,「代表作」,「誕生年」</returns>
            static string ToJapanese(string key) {

                return key switch {
                    "Novelist" => "作家",
                    "BestWork" => "代表作",
                    "Born" => "誕生年",
                    _ => "引数keyは、正しい値ではありません"
                };


                return ""; //エラーをなくすためのダミー
            }
        }
    }
}

