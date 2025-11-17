using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distanceconverter
{
    public class DistanceConverter
    {
        public ConverterBase From { get; init; }
        public ConverterBase To { get; init; }

        public DistanceConverter(ConverterBase from, ConverterBase to) {
            From = from;
            To = to;
        }

        public double Convert(double value) {
            double meter = From.ToMeter(value);     //メーターに変換
            return To.FromMeter(meter);             //メーターからそれぞれの単位に変換
        }
    }
}
