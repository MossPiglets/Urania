using Urania.Core;

namespace Urania.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow {
        public WireParameters WireParameters { get; set; } = new WireParameters();
        public MainWindow() {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}
