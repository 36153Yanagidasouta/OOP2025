using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld {
    class ViewModel : BindableBase {

        public ViewModel() {
            ChangeMessageCommand = new DelegateCommand(() =>
            GreetingMesseage = "日本");
        }

        private string _greetingMessage = "HelloWorld";
        public string GreetingMesseage {
            get => _greetingMessage;
            set => SetProperty(ref _greetingMessage, value);

        }
        public DelegateCommand ChangeMessageCommand { get; }
    }
}
