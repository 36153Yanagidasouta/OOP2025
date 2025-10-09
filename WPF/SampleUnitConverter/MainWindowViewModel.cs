using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SampleUnitConverter {
    internal class MainWindowViewModel : ViewModel {


        //フィールド
        private double metricValue;
        private double imperialValue;

        //▲で呼び出すコマンド
        public ICommand ImperialUnitToMetric { get; private set; }


        //▼で呼び出すコマンド
        public ICommand MetricUnitToImperial { get; private set; }


        //上のコンボボックスで選択されている値
        public MetricUnit CurrentMetricUnit { get; set; }

        //下のコンボボックスで選択されている値
        public ImperialUnit CurrentImperialUnit { get; set; }

        //プロパティ
        public double MetricValue {
            get => metricValue;
            set {
                this.metricValue = value;
                this.OnPropertyChanged();
            }
        }

        public double ImperialValue {
            get => imperialValue;
            set {
                this.imperialValue = value;
                this.OnPropertyChanged();
            }

        }
        public MainWindowViewModel() {

            CurrentMetricUnit = MetricUnit.Units.First();
            CurrentImperialUnit = ImperialUnit.Units.First();

            ImperialUnitToMetric = new DelegateCommand(
               () => MetricValue = CurrentMetricUnit.FromImperialUnit(
                  CurrentImperialUnit, ImperialValue));


            MetricUnitToImperial = new DelegateCommand(
            () => ImperialValue = CurrentImperialUnit.FromMetricUnit(
            CurrentMetricUnit, MetricValue));


        }
    }
}
