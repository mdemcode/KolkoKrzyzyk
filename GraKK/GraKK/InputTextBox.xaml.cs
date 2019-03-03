using System;
using System.Windows;
using System.Windows.Input;

namespace GraKK {

    public partial class InputTextBox : Window {

        public InputTextBox(string tekstZachety) {
            InitializeComponent();
            this.TekstZachety.Content = tekstZachety;
            this.WprowdzonyTekst.Focus();
        }

        private void OK_Click(object sender, RoutedEventArgs e) => Zamknij();

        private void Grid_KeyUp(object sender, KeyEventArgs e) {
            if (e.Key == Key.Enter) Zamknij();
        }

        private void Zamknij() {
            this.Close();
        }
    }
}
