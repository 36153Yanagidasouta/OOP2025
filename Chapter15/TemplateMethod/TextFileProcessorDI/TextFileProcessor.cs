using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TextFileProcessorDI {
    class TextFileProcessor {
        private ITextFileService _service;

        public TextFileProcessor(ITextFileService service) {
            _service = service;
        }

        public void  Run(string fname) {
            _service.Initalize(fname);
            
            var lines = File.ReadAllLines(fname);
            foreach (var line in lines) {
                _service.Execute(line);
            }
            _service.Terminate();
        }
    }
}
