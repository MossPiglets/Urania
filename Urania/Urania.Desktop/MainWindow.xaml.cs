using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using AdonisUI.Controls;
using Urania.Core;
using Urania.Core.Data;
using Urania.Desktop.States;
using System.Web;

namespace Urania.Desktop {
    public partial class MainWindow {
        MainViewModel MainViewModel { get; set; } = new MainViewModel();
        public MainWindow() {
            InitializeComponent();
            this.DataContext = MainViewModel;
        }
        private void CleanButton_Click(object sender, System.Windows.RoutedEventArgs e) {
            MainViewModel.WireParameters.Wd = null;
            MainViewModel.WireParameters.Id = null;
            MainViewModel.WireParameters.Od = null;
            MainViewModel.WireParameters.Ar = null;
            IdCalComboBox.SelectedIndex = -1;
            WdSwgComboBox.SelectedIndex = -1;
            WdAwgComboBox.SelectedIndex = -1;
            MainViewModel.IdState = IdState.Millimeter;
            MainViewModel.WdState = WdState.Millimeter;
        }
        private void OUranii_Click(object sender, System.Windows.RoutedEventArgs e) {
            
            string version = typeof(MainWindow).Assembly.GetName().Version.ToString();
            var messageBox = new MessageBoxModel {
                Text = "Urania to aplikacja dedykowana twórcom zajmującym się techniką chainmaille, która pomoże Ci przeliczyć dowolne parametry posiadanych, bądź poszukiwanych ogniwek." +
                " Wystarczy, że podasz dwa spośród nich, także w amerykańskich jednostkach, które zostaną zamienione na system metryczny." +
                "\nObecna wersja: " + version +
                "\nAutorzy: " +
                "\n- Katarzyna Kądziołka: https://github.com/Katarzyna-Kadziolka" +
                "\n- Hubert Morawski: https://github.com/Morasiu" +
                "\n- Krystyna Sybalska: https://github.com/Krystyna-Szybalska" +
                "\n- Zofia Szybalska: https://github.com/Zofia-Szybalska",
                
                Caption = "O Uranii",
                Buttons = new[]
                    {
                        MessageBoxButtons.Cancel("Zamknij"),
                    },
            };
            AdonisUI.Controls.MessageBox.Show(messageBox);
        }

        private void WdSwgComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (e.AddedItems.Count != 0) {
                MainViewModel.WireParameters.Wd = Swg.Values[(SwgName)e.AddedItems[0]];
            }
        }

        private void IdInchComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (e.AddedItems.Count != 0) {
                MainViewModel.WireParameters.Id = Inch.Values[(InchName)e.AddedItems[0]];
            }
        }
        private void WdAwgComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (e.AddedItems.Count != 0) {
                MainViewModel.WireParameters.Wd = Awg.Values[(AwgName)e.AddedItems[0]];
            }
        }

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
            if (MainViewModel.WireParameters.Wd == null) {
                MainViewModel.WireParameters.Wd = Math.Round(WdCalculator.Calculate(MainViewModel.WireParameters.Id, MainViewModel.WireParameters.Ar, MainViewModel.WireParameters.Od), 2) ;
            }
            
            if (MainViewModel.WireParameters.Ar == null) {
                MainViewModel.WireParameters.Ar = Math.Round(ArCalculator.Calculate(MainViewModel.WireParameters.Id, MainViewModel.WireParameters.Wd, MainViewModel.WireParameters.Od), 2);
            }
            
            if (MainViewModel.WireParameters.Id == null) {
                MainViewModel.WireParameters.Id = Math.Round(IdCalculator.Calculate(MainViewModel.WireParameters.Ar, MainViewModel.WireParameters.Wd, MainViewModel.WireParameters.Od), 2);
            }
            
            if (MainViewModel.WireParameters.Od == null) {
                MainViewModel.WireParameters.Od = Math.Round(OdCalculator.Calculate(MainViewModel.WireParameters.Ar, MainViewModel.WireParameters.Wd, MainViewModel.WireParameters.Id), 2);
            }
        }

        private void IdMmRadiobutton_Checked(object sender, RoutedEventArgs e) {
            IdCalComboBox.SelectedItem = -1;
        }

        private void WdMmRadiobutton_Checked(object sender, RoutedEventArgs e) {
            WdSwgComboBox.SelectedIndex = -1;
            WdAwgComboBox.SelectedIndex = -1;
        }
    }
}