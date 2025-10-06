using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld {

    class ViewModel : BindableBase {

        public ViewModel() {
            ChangeMessageCommand = new DelegateCommand<string>(
                 (par) => GreetingMesseage = par,
                 (par) => GreetingMesseage != par)
                .ObservesProperty(() => GreetingMesseage);
        }


        private string _greetingMessage = "HelloWorld";
        public string GreetingMesseage {
            get => _greetingMessage;
            set => SetProperty(ref _greetingMessage, value);
        }

        public string NewMessage1 { get; } = "日本最高";
        public string NewMessage2 { get; } = "日本最高最高";
        public DelegateCommand<string> ChangeMessageCommand { get; }
    }
}
