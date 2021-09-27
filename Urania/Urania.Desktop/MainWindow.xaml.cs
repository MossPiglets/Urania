using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Urania.Core;
using Urania.Core.Data;
using Urania.Desktop.States;

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

        private void HowToUse_Click(object sender, RoutedEventArgs e) {
            var howToUseText = "Program uwzględnia cztery podstawowe parametry, którymi określamy rozmiar ogniw. " + 
                "Aby uruchomić przeliczanie musisz wpisać dwa spośród nich. Są to:" + '\n' + '\n' +
                "- WD - grubość drutu, z którego ogniwko zostało zrobione. Możesz podać go w milimetrach lub w jednej z amerykańskich jednostek 'gauge'. " +
                "Są to tzw. AWG i SWG. Należy zwrócić uwagę na to, że jednostki te mają nieznacznie różne wartości. Jeżeli nie mamy podane, o którą z tych jednostek chodzi, to można z dużą dozą prawdopodobieństwa uznać, że o AWG. " +
                "Po wybraniu wartości gauge(AWG lub SWG) z rozwijanej listy program automatycznie przeliczy go na milimetry." + '\n' + '\n' +
                "- ID - wewnętrzna średnica ogniwka. Ta wartość podawana jest zazwyczaj w sklepach dedykowanych technice chainmaille i w amerykańskich tutorialach. " +
                "Możesz podać ją w milimetrach lub wybrać odpowiednią wartość w calach, która zostanie automatycznie przeliczona na milimetry." + '\n' + '\n' +
                "- OD - zewnętrzna średnica ogniwka. Ta wartość podawana jest zazwyczaj w polskich sklepach z półfabrykatami do biżuterii.Podajesz ją w milimetrach." + '\n' +
                "- AR - współczynnik proporcji, najważniejszy parametr w technice chainmaille.To stosunek ID do WD.Wartość ta określa przydatność ogniwka do poszczególnych splotów." + '\n' + '\n' +
                "Po wprowadzeniu dwóch z posiadanych parametrów wciśnij przycisk 'przelicz', aby otrzymać pozostałe wartości." + '\n' + '\n' +
                "Aby wyczyścić wszystkie pola kliknij przycisk 'wyczyść'.";
            AdonisUI.Controls.MessageBox.Show(howToUseText, "Jak korzystać z programu?", (AdonisUI.Controls.MessageBoxButton)MessageBoxButton.OK, (AdonisUI.Controls.MessageBoxImage)MessageBoxImage.Information);
        }
    }
}