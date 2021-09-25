using System;
using System.Collections.Generic;
using System.Linq;
using Urania.Core;
using Urania.Desktop.States;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Urania.Desktop {
    public class MainViewModel : INotifyPropertyChanged, IDataErrorInfo {
        private WdState _wdState;
        private IdState _idState;
        private MainViewModelValidator _wireParametersValidator;

        public MainViewModel() {
            WireParameters.PropertyChanged += (sender, args) => OnPropertyChanged(nameof(WireParameters));
            _wireParametersValidator = new MainViewModelValidator();
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

        public string Error {
            get {
                if (_wireParametersValidator != null) {
                    var results = _wireParametersValidator.Validate(this);
                    if (results != null && results.Errors.Any()) {
                        var errors = string.Join(Environment.NewLine,
                            results.Errors.Select(x => x.ErrorMessage).ToArray());
                        return errors;
                    }
                }

                return string.Empty;
            }
        }

        public string this[string columnName] {
            get {
                var firstOrDefault = _wireParametersValidator.Validate(this).Errors
                    .FirstOrDefault(a => a.PropertyName == columnName);
                if (firstOrDefault != null) {
                    return _wireParametersValidator != null ? firstOrDefault.ErrorMessage : null;
                }

                return null;
            }
        }
    }
}
