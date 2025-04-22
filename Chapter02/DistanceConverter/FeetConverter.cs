using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    public class FeetConverter {

        public double FeetToMeter(double meter) {
            return meter / 0.3048;

        }
        public double MeterToFeet(double feet) {
            return feet * 0.3048;
        }
    }
}




