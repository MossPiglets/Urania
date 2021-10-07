using System.ComponentModel;
using System.Runtime.CompilerServices;
using Urania.Desktop.States;

namespace Urania.Desktop {
    public class MainViewModel : INotifyPropertyChanged {
        private WdState _wdState;
        private IdState _idState;
        private bool _canCalculate;

        public MainViewModel() {
            WireParameters.PropertyChanged += (sender, args) => OnPropertyChanged(nameof(WireParameters));
            WireParameters.PropertyChanged += (sender, args) => CheckCalculatePossibility(); //dalej nie rozumiem po co to (sender,args)
        }

        public WireParameters WireParameters { get; set; } = new WireParameters();

        private bool _isParametersCountAboveTwo;

        public bool IsParametersCountAboveTwo {
            get => _isParametersCountAboveTwo;
            set { 
                _isParametersCountAboveTwo = value;
                OnPropertyChanged(nameof(IsParametersCountAboveTwo));
            }
        }

        public bool CanCalculate {
            get => _canCalculate;
            set { 
                _canCalculate = value; 
                OnPropertyChanged(nameof(CanCalculate));
            }
        }

        public WdState WdState {
            get => _wdState;
            set {
                _wdState = value;
                OnPropertyChanged(nameof(WdState));
            }
        }
        public IdState IdState {
            get => _idState;
            set {
                _idState = value;
                OnPropertyChanged(nameof(IdState));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private void CheckCalculatePossibility() {
            CanCalculate = false;
            IsParametersCountAboveTwo = false;

            if (WireParameters.IsValid == true) {
                int notNullCount = 0;
                if (WireParameters.Id != null) notNullCount++;
                if (WireParameters.Od != null) notNullCount++;
                if (WireParameters.Wd != null) notNullCount++;
                if (WireParameters.Ar != null) notNullCount++;

                if (notNullCount == 2) { 
                    CanCalculate = true;
                } 
                
                else if (notNullCount > 2) {
                    IsParametersCountAboveTwo = true;
                }
            } 
        }
    }
}
