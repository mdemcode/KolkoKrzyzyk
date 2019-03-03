using System.Windows;
using System.Windows.Input;

namespace GraKK {

    public partial class Informacja : Window {

        public Informacja() {
            InitializeComponent();
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e) => Zamknij();

        private void Zamknij() {
            this.Hide();
        }
    }
}
