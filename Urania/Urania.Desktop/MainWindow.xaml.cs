using Urania.Desktop.States;
using Urania.Core;

namespace Urania.Desktop {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow {
        public WireParameters WireParameters { get; set; } = new WireParameters();
        public WdState WdState { get; set; } = WdState.Millimeter;
        public IdState IdState { get; set; } = IdState.Millimeter;


        public MainWindow() {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}