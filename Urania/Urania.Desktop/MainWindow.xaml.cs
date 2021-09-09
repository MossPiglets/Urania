using Urania.Desktop.States;
using Urania.Core;

namespace Urania.Desktop {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow {
        public WireParameters WireParameters { get; set; } = new WireParameters();
        public WdState WdState { get; set; } = WdState.Inch;
        public IdState IdState { get; set; } = IdState.Millimeter;


        public MainWindow() {
            InitializeComponent();
            this.DataContext = this;
        }

        private void CleanButton_Click(object sender, System.Windows.RoutedEventArgs e) {
            WdTextBox.Text = null;
            IdTextBox.Text = null;
            OdTextBox.Text = null;
            ArTextBox.Text = null;
            IdCalComboBox.Text = null;
            WdSWGComboBox.Text = null;
            WdAWGComboBox.Text = null;
            IdMmRadiobutton.IsChecked = true;
            WdMmRadiobutton.IsChecked = true;
        }
    }
}