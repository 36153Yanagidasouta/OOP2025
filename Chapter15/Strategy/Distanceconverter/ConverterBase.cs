using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distanceconverter{
    public abstract class ConverterBase{
        protected abstract double Ratio { get; }

        public abstract string UnitName { get; }
    
        public double FromMeter(double meter) => meter / Ratio;

    }
}
