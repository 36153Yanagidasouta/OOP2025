
using System.Collections;
using System.Collections.Generic;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {

            var text = "Cozy lummox gives smart squid who asks for job pen";



            Exercise1(text);
            Console.WriteLine();

            Exercise2(text);
            Console.WriteLine();
        }

        private static void Exercise1(string text) {

            var textDict = new Dictionary<char, int>();

            foreach (var n in text.ToUpper().OrderBy(n => n)) {
                if ('A' <= n && n <= 'Z') {
                    if (textDict.ContainsKey(n)) {
                        textDict[n]++;
                    } else {
                        textDict[n] = 1;
                    }
                }
                foreach (var (key, value) in textDict) {
                    Console.WriteLine($"'{key}':'{value}'");
                }
            }
        }

        private static void Exercise2(string text) {
            var textDict = new Dictionary<char, int>();

            foreach (var n in text.ToUpper()) {
                if ('A' <= n && n <= 'Z') {
                    if (textDict.ContainsKey(n)) {
                        textDict[n]++;
                    } else {
                        textDict[n] = 1;
                    }
                }
                foreach (var (key, value) in textDict) {
                    Console.WriteLine($"'{key}':'{value}'");

                }
            }
        }
    }
}
