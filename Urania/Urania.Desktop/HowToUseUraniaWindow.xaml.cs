﻿using System.IO;
using System.Windows;

namespace Urania.Desktop {

    public partial class HowToUseUrania {

        private string lines = File.ReadAllText("Resources/HowToUseUrania.txt");

        public HowToUseUrania() {
            InitializeComponent();
            lastLines.Text = lines;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
