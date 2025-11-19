using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileProcessorDI {
    //P362 問題15.3
    public class LineCounterService : ITextFileService {
        private int _count;
        public void Execute(string line) {
            if (_count < 20) {
                Console.WriteLine(line);
            }
            _count++;
        }

        public void Initalize(string fname) {

            _count = 0;
        }

        public void Terminate() {
            Console.WriteLine($"{_count}");
        }
    }
}
