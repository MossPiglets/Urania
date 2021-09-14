using System;
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
            WdSwgComboBox.SelectedIndex = -1;
            WdAwgComboBox.SelectedIndex = -1;
            IdMmRadiobutton.IsChecked = true;
            WdMmRadiobutton.IsChecked = true;
        }

        private void WdSwgComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e) =>
            WireParameters.Wd = Swg.Values[(SwgName) e.AddedItems[0]];        
        
        private void WdAwgComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e) =>
            WireParameters.Wd = Awg.Values[(AwgName) e.AddedItems[0]];
    }
}