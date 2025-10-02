using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld {
    class ViewModel : INotifyPropertyChanged {

        public ViewModel() {
            ChangeMessageCommand = new DelegateCommand(() =>
            GreetingMesseage = "日本");
        }

        private string _greetingMessage = "HelloWorld";
        public string GreetingMesseage {
            get => _greetingMessage;
            set {
                if (_greetingMessage != value) {
                    _greetingMessage = value;
                    PropertyChanged?.Invoke(
                        this, new PropertyChangedEventArgs(nameof(GreetingMesseage)));
                }
            }
        }


        public DelegateCommand ChangeMessageCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
