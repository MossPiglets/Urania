using System;
using System.Windows;
using System.Windows.Controls;
using Urania.Desktop.States;
using Urania.Core;
using Urania.Core.Data;
using System.Windows.Input;
using System.Windows;
using System.Linq;
using System.Text.RegularExpressions;
using System.Globalization;

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
            WdSwgComboBox.SelectedIndex = -1;
            WdAwgComboBox.SelectedIndex = -1;
            IdMmRadiobutton.IsChecked = true;
            WdMmRadiobutton.IsChecked = true;
        }

        private void WdSwgComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e) =>
            WireParameters.Wd = Swg.Values[(SwgName) e.AddedItems[0]];

        private void IdInchComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e) =>
            WireParameters.Id = Inch.Values[(InchName) e.AddedItems[0]];
        
        private void WdAwgComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e) =>
            WireParameters.Wd = Awg.Values[(AwgName) e.AddedItems[0]];

        private void AllowOnlyNumbers(object sender, TextCompositionEventArgs e) {
            TextBox textBox = (TextBox)sender;
            string text = textBox.Text;
            text += e.Text;
            e.Handled = !decimal.TryParse(text, out _);
        }
        private void AllowPastOnlyNumbers(object sender, DataObjectPastingEventArgs e) {
            PastedTextValidator.AllowPastOnlyNumbers(e);
        }
        private void ButtonCalculate_OnClick(object sender, RoutedEventArgs e) {
            if (WireParameters.Wd == null) {
                WireParameters.Wd = Math.Round(WdCalculator.Calculate(WireParameters.Id, WireParameters.Ar, WireParameters.Od), 2) ;
            }

            if (WireParameters.Ar == null) {
                WireParameters.Ar = Math.Round(ArCalculator.Calculate(WireParameters.Id, WireParameters.Wd, WireParameters.Od), 2);
            }

            if (WireParameters.Id == null) {
                WireParameters.Id = Math.Round(IdCalculator.Calculate(WireParameters.Ar, WireParameters.Wd, WireParameters.Od), 2);
            }

            if (WireParameters.Od == null) {
                WireParameters.Od = Math.Round(OdCalculator.Calculate(WireParameters.Ar, WireParameters.Wd, WireParameters.Id), 2);
            }
        }
    }
}