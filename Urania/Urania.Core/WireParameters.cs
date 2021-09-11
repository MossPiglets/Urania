using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Urania.Core {
    public class WireParameters : INotifyPropertyChanged {

        private decimal? _wd;
        private decimal? _od;
        private decimal? _id;
        private decimal? _ar;
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
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}