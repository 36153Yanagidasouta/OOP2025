using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distanceconverter {
    public class ConverterFactory {
        //あらかじめインスタンスを生成し、配列に入れておく
        private readonly static ConverterBase[] _converters = {
            new MeterConverter(),
            new FeetConverter(),
            new InchConverter(),
            new YardConverter()
        };

        public static ConverterBase? GetConverter(string name) =>
            _converters.FirstOrDefault(x => x.IsMyunit(name));
    
    }
}
