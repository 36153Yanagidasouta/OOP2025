using System.Text;
using System.Text.RegularExpressions;

namespace Exercise05 {
    internal class Program {
        static void Main(string[] args) {

            var lines = File.ReadLines("sample.html");
            var sb = new StringBuilder();

            foreach (var item in lines) {

                var s = Regex.Replace(lines, 
                  @"<(/?)[A-Z]([A-Z0-9]*)(.*)>",
                  m => {
                      string.Format(m.Groups[1].Value,
                          m.Groups[2].Value.ToLower())


                  }





                    );
                sb.AppendLine(s);
            }
            File.WriteAllText("sampleOut.html", sb.ToString());


            var text = File.ReadAllText("sampleOut.html");
            Console.WriteLine(text);
        }
    }
}
