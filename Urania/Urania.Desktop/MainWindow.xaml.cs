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

        private void CleanButton_Click(object sender, System.Windows.RoutedEventArgs e) {
            WireParameters.Wd = null;
            WireParameters.Id = null;
            WireParameters.Od = null;
            WireParameters.Ar = null;
            IdCalComboBox.SelectedIndex = -1;
            WdSWGComboBox.SelectedIndex = -1;
            WdAWGComboBox.SelectedIndex = -1;
            IdMmRadiobutton.IsChecked = true;
            WdMmRadiobutton.IsChecked = true;
        }
    }
}