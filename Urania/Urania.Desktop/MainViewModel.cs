using System;
using System.Collections.Generic;
using System.Linq;
using Urania.Core;
using Urania.Desktop.States;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Urania.Desktop {
    public class MainViewModel : INotifyPropertyChanged {
        private WdState _wdState;
        private IdState _idState;
        private WireParametersValidator _wireParametersValidator;

        public MainViewModel() {
            WireParameters.PropertyChanged += (sender, args) => OnPropertyChanged(nameof(WireParameters));
            _wireParametersValidator = new WireParametersValidator();
        }

        public WireParameters WireParameters { get; set; } = new WireParameters();

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
        
    }
}
