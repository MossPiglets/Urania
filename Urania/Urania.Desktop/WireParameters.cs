using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Documents;

namespace Urania.Desktop {
    public class WireParameters : INotifyPropertyChanged, IDataErrorInfo {
        private decimal? _wd;
        private decimal? _od;
        private decimal? _id;
        private decimal? _ar;
        private WireParametersValidator _wireParametersValidator;

        public decimal? Wd {
            get => _wd;
            set {
                _wd = value;
                OnPropertyChanged(nameof(Wd));
            }
        }

        public decimal? Id {
            get => _id;
            set {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public decimal? Od {
            get => _od;
            set {
                _od = value;
                OnPropertyChanged(nameof(Od));
            }
        }

        public decimal? Ar {
            get => _ar;
            set {
                _ar = value;
                OnPropertyChanged(nameof(Ar));
            }
        }

        public bool IsValid => _wireParametersValidator.Validate(this).IsValid;

        public WireParameters() {
            _wireParametersValidator = new WireParametersValidator();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string Error {
            get {
                var results = _wireParametersValidator.Validate(this);
                if (results != null && results.Errors.Any()) {
                    var errors = string.Join(Environment.NewLine,
                        results.Errors.Select(x => x.ErrorMessage).ToArray());
                    return errors;
                }

                return string.Empty;
            }
        }

        public string this[string columnName] {
            get {
                var firstOrDefault = _wireParametersValidator.Validate(this).Errors
                    .FirstOrDefault(a => a.PropertyName == columnName);
                if (firstOrDefault != null) {
                    return firstOrDefault.ErrorMessage;
                }

                return null;
            }
        }
    }
}