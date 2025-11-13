using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFileProcessor;

namespace LineCounter {
    internal class LineCounterProcessor : TextProcessor {
        public int _totalCount = 0;
        public string _targetString = "int";

        protected override void Initialize(string fname) {
            _totalCount = 0;
            Console.WriteLine("検索したい文字列 ");
            _targetString = Console.ReadLine() ;
        }

        protected override void Execute(string line) {
            if (string.IsNullOrEmpty(_targetString)) return;

            int countInLine = 0;
            int index = -1;
            while ((index = line.IndexOf(_targetString, index + 1)) != -1) {
                countInLine++;
            }
            _totalCount += countInLine;
        }

        protected override void Terminate() {
            Console.WriteLine("合計{0}個", _totalCount);
        }
    }
}