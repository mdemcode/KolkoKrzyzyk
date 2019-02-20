using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GraKK
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region PolaKlasy
        SilnikGRY GraKK1;
        //Gracz gracz1, gracz2;
        #endregion

        #region Inicjalizacja
        public MainWindow()
        {
            InitializeComponent();
            //TBGracz1.Text = "Gracz1";
            //TBGracz2.Text = "Gracz2";

            //imieGracza1 = "Gracz1";
            //imieGracza2 = "Gracz2";
        }
        #endregion

        #region Obsługa Zdarzeń
        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (GraKK1 == null) return;
            Label pole = (Label)sender;
            byte nrPola = Convert.ToByte(pole.Tag);
            char znakPola = GraKK1.Klikniecie(nrPola);

            if (znakPola != 'n')
            {
                pole.Content = znakPola.ToString();
                string czyKoniecRundy = GraKK1.KoniecRundy();
                if (czyKoniecRundy != "")
                {
                    if (czyKoniecRundy == "Remis") WyswietlInfo("Remis");
                    else WyswietlInfo (string.Format("Wygrał {0}", czyKoniecRundy));
                    WyczyscPoleGry();
                    // graKK1=>nowaRunda
                }
                GraKK1.ZmianaGracza();
                WyswietlAktywnego();
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

        private void ButtonNowaGra_Click(object sender, RoutedEventArgs e) => NowaGra();
        #endregion

        #region Metody
        private void NowaGra()
        {
            WyczyscPoleGry();
            if (GraKK1 != null) GraKK1 = null;
            Gracz gracz1 = new Gracz(NadajImie("1 (X)"), true, 1, 'X');
            Gracz gracz2 = new Gracz(NadajImie("2 (O)"), false, 5, 'O');
            GraKK1 = new SilnikGRY(gracz1, gracz2);
            TBGracz1.DataContext = gracz1;
            TBGracz2.DataContext = gracz2;
            WyswietlAktywnego();
            WyswietlInfo(string.Format("Rozpoczyna gracz: {0}", GraKK1.AktywnyGracz().nazwa.ToString()));
        }

        private void WyswietlInfo(string tekstInformacji)
        {
            Informacja info = new Informacja {Owner = this};
            info.GrafikaInfo.Content = string.Format(tekstInformacji);
            info.ShowDialog();
        }

        private void WyczyscPoleGry()
        {
            this.label1.Content = "";
            this.label2.Content = "";
            this.label3.Content = "";
            this.label4.Content = "";
            this.label5.Content = "";
            this.label6.Content = "";
            this.label7.Content = "";
            this.label8.Content = "";
            this.label9.Content = "";
        }

        private void ButtonKoniec_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void WyswietlAktywnego()
        {
            this.LabelAktywnyGracz.Content = string.Format("Aktualny gracz: {0}", GraKK1.AktywnyGracz().nazwa);
        }

        private string NadajImie(string nr)
        {
            InputTextBox okienko = new InputTextBox(string.Format("Podaj imię gracza {0}", nr));
            okienko.Owner = this;
            okienko.ShowDialog();
            return okienko.WprowdzonyTekst.Text;
        }

        #endregion
    }
}
