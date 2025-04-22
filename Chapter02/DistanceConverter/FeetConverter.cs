using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    public static class FeetConverter {


        private const double ratio = 0.3084;
        
        public static double FeetToMeter(double meter) {
            return meter / ratio;
        }

        public static double MeterToFeet(double feet) {
            return feet * ratio;
        }

    }
}




