using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleUnitConverter{
    class MetricUnit : DistanceUnit{
        private static List<MetricUnit> units = new List<MetricUnit> {
            new MetricUnit{Name = "mm", Coefficient = 1,},
            new MetricUnit{Name = "cm", Coefficient = 10,},
            new MetricUnit{Name = "m", Coefficient = 10 * 100,},
            new MetricUnit{Name = "km", Coefficient = 10 * 100 * 1000,},
        };

        public static ICollection<MetricUnit>Units { get => units; }

        /// <summary>
        ///ヤード単位からメートル単位に変換
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="value"></param>
        /// <returns></returns>

        public double FromImperialUnit(ImperialUnit unit, double value) {
            return (value * unit.Coefficient) * 25.4 / Coefficient;

        }
    }
}
