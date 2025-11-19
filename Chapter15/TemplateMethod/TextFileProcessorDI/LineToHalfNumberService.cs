using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TextFileProcessorDI {
    //P362 問題15.1
    public class LineToHalfNumberService : ITextFileService {
        private string str;
        public void Initalize(string fname) {
        }

        
        public void Execute(string line) {
            //str = Strings.StrConv(line, VbStrConv.Narrow);
            //Console.WriteLine($"{str}");

           string result = new string(
                line.Select(c => ('０' <= c && c <= '９'?(char)(c - '0'+'０' ):c)).ToArray()
                );
            Console.WriteLine(result);
        }

        public void Terminate() {
            

        }
    }
}
