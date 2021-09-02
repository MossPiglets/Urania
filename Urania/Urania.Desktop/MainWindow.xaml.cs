using System.Windows;
using Urania.Desktop.States;

namespace Urania.Desktop {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow {
		public WdState WdState { get; set; } = WdState.Inch;
		public MainWindow() {
			InitializeComponent();
			this.DataContext = this;
		}
	}
}