using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Urania.Desktop.States;
using Urania.Core;
using Urania.Core.Data;

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

        private void WdSWGComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e) =>
            WireParameters.Wd = GetValueFromDictionary<SwgName>(e.AddedItems);

        private decimal GetValueFromDictionary<T>(IList list) {
            if (list.Count != 0) {
                return Swg.Values.Where(a => a.Key == (SwgName) list[0])
                    .Select(a => a.Value).ToList()[0];
            }

            return 0M;
        }
    }
}