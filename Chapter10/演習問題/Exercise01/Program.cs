using System.Text;
using System.IO;
using System.Linq; // LINQを使うために必要

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {

            var filepath = @"C:\Users\infosys\source\repos\OOP2025\Chapter10\演習問題\Exercise01\source.txt";
            if (File.Exists(filepath)) {

                string[] lines = File.ReadAllLines(filepath, Encoding.UTF8);
                int count = lines.Count(s => s.Contains("class"));
                Console.WriteLine($"{count} 行");
            }
        }
    }
}