using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distanceconverter{
    public abstract class ConverterBase {

        //nameで与えられた単位名が自分のものか判断
        public abstract bool IsMyunit(string name);

        //メートルとの比率()
        protected abstract double Ratio { get; }

        //距離の単位名(たとえば、メートル、センチなど)
        public abstract string UnitName { get; }

        //メートルから変換
        public double FromMeter(double meter) => meter / Ratio;

        //変換からメートル
        public double ToMeter(double feet) => feet * Ratio;

    }
}
