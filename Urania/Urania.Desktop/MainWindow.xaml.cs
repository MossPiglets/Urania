using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
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
				MainViewModel.WireParameters.Wd = Swg.Values[(SwgName) e.AddedItems[0]];
			}
		}

		private void IdInchComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
			if (e.AddedItems.Count != 0) {
				MainViewModel.WireParameters.Id = Inch.Values[(InchName) e.AddedItems[0]];
			}
		}

		private void WdAwgComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
			if (e.AddedItems.Count != 0) {
				MainViewModel.WireParameters.Wd = Awg.Values[(AwgName) e.AddedItems[0]];
			}
		}

		private void AllowOnlyNumbers(object sender, TextCompositionEventArgs e) {
			TextBox textBox = (TextBox) sender;
			string text = textBox.Text;
			text += e.Text;
			e.Handled = !decimal.TryParse(text, out _);
		}

		private void AllowPastOnlyNumbers(object sender, DataObjectPastingEventArgs e) {
			PastedTextValidator.AllowPastOnlyNumbers(e);
		}

		private void ButtonCalculate_OnClick(object sender, RoutedEventArgs e) {
			try {
				if (MainViewModel.WireParameters.Wd == null) {
					MainViewModel.WireParameters.Wd =
						Math.Round(
							WdCalculator.Calculate(MainViewModel.WireParameters.Id, MainViewModel.WireParameters.Ar,
								MainViewModel.WireParameters.Od), 2);
				}

				if (MainViewModel.WireParameters.Ar == null) {
					MainViewModel.WireParameters.Ar =
						Math.Round(
							ArCalculator.Calculate(MainViewModel.WireParameters.Id, MainViewModel.WireParameters.Wd,
								MainViewModel.WireParameters.Od), 2);
				}

				if (MainViewModel.WireParameters.Id == null) {
					MainViewModel.WireParameters.Id =
						Math.Round(
							IdCalculator.Calculate(MainViewModel.WireParameters.Ar, MainViewModel.WireParameters.Wd,
								MainViewModel.WireParameters.Od), 2);
				}

				if (MainViewModel.WireParameters.Od == null) {
					MainViewModel.WireParameters.Od =
						Math.Round(
							OdCalculator.Calculate(MainViewModel.WireParameters.Ar, MainViewModel.WireParameters.Wd,
								MainViewModel.WireParameters.Id), 2);
				}
			}
			catch (Exception ex) {
				AdonisUI.Controls.MessageBox.Show(ex.Message, "Error", AdonisUI.Controls.MessageBoxButton.OK,
					AdonisUI.Controls.MessageBoxImage.Error);
			}
		}

		private void IdMmRadiobutton_Checked(object sender, RoutedEventArgs e) {
			IdCalComboBox.SelectedItem = -1;
		}

		private void WdMmRadiobutton_Checked(object sender, RoutedEventArgs e) {
			WdSwgComboBox.SelectedIndex = -1;
			WdAwgComboBox.SelectedIndex = -1;
		}

		private void BruxaPl_OnClick(object sender, RoutedEventArgs e) {
			var url = "https://bruxa.pl/";
			try {
				Process.Start(url);
			}
			catch {
				if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
					url = url.Replace("&", "^&");
					Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
				}
				else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) {
					Process.Start("xdg-open", url);
				}
				else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) {
					Process.Start("open", url);
				}
				else {
					throw;
				}
			}
		}
	}
}