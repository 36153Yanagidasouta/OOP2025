using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class InchConverter {

        public double InchtToMeter(double meter) {
            return meter * 1.09361;
        }

        public double MeterToInch(double yard) {
            return yard / 1.09361;

        }

    }
}
