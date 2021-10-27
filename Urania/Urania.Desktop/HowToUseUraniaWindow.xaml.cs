using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace Urania.Desktop {

    public partial class HowToUseUrania {

        public string firstLines = File.ReadAllText("/Resources/HowToUseUrania.txt").Take(2).ToString();
        public string lastLines = File.ReadLines("/Resources/HowToUseUrania.txt").Skip(2).ToString();

        public HowToUseUrania() {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
