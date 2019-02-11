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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GraKK
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SilnikGRY GraKK;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OknoGry_Loaded(object sender, RoutedEventArgs e)
        {
            GraKK = new SilnikGRY();
        }

        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Label pole = (Label)sender;
            byte nrPola = Convert.ToByte(pole.Tag);
            char znakPola = GraKK.Klikniecie(nrPola);

            if (znakPola != 'n')
            {
                pole.Content = znakPola.ToString();
                string czyKoniecRundy = GraKK.KoniecRundy();
                if (czyKoniecRundy != "")
                {
                    if (czyKoniecRundy == "Remis") MessageBox.Show("Remis");
                    else MessageBox.Show (string.Format("Wygrał {0}", czyKoniecRundy));
                }
                GraKK.ZmianaGracza();
                //WyswietlAktywnego();
            }
        }

        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            Label tlo = (Label)sender;
            tlo.Background = System.Windows.Media.Brushes.White;
        }

        private void Label_MouseLeave(object sender, MouseEventArgs e)
        {
            Label tlo = (Label)sender;
            tlo.Background = System.Windows.Media.Brushes.LightGreen;
        }
    }
}
