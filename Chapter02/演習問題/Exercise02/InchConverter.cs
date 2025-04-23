using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class InchConverter {

        public double InchtToMeter(double meter) {
            return meter * 0.0254;
        }

        public double MeterToInch(double inch) {
            return inch / 0.0254;

        }

    }
}
