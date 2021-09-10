using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Urania.Core {
    public class WireParameters : INotifyPropertyChanged {
        public decimal? Wd {
            set { OnPropertyChanged(); }
        }
        public decimal? Id {
            set { OnPropertyChanged(); }
        }
        public decimal? Od {
            set { OnPropertyChanged(); }
        }
        public decimal? Ar {
            set { OnPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}