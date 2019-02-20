using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GraKK
{
    /// <summary>
    /// Logika interakcji dla klasy InputTextBox.xaml
    /// </summary>
    public partial class InputTextBox : Window
    {
        public InputTextBox(string tekstZachety)
        {
            InitializeComponent();
            this.TekstZachety.Content = tekstZachety;
            this.WprowdzonyTekst.Focus();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
