using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GraKK {
    public partial class MainWindow : Window {
        
        #region POLA KLASY
        SilnikGRY GraKK1;
        Gracz gracz1;
        Gracz gracz2;
        #endregion

        #region KONSTRUKTOR (Inicjalizacja)
        public MainWindow() {
            InitializeComponent();
        }
        #endregion

        #region OBSŁUGA ZDARZEŃ
        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
            if (GraKK1 == null) return;
            Label pole = (Label)sender;
            byte nrPola = Convert.ToByte(pole.Tag);
            char znakPola = GraKK1.Klikniecie(nrPola);
            if (znakPola != 'n') {
                pole.Content = znakPola.ToString();
                string czyKoniecRundy = GraKK1.KoniecRundy();
                if (czyKoniecRundy != "") NowaRunda(czyKoniecRundy);
                GraKK1.ZmianaGracza();
                WyswietlAktywnego();
            }
        }

        private void Label_MouseEnter(object sender, MouseEventArgs e) {
            Label tlo = (Label)sender;
            tlo.Background = System.Windows.Media.Brushes.White;
        }

        private void Label_MouseLeave(object sender, MouseEventArgs e) {
            Label tlo = (Label)sender;
            tlo.Background = System.Windows.Media.Brushes.LightGreen;
        }

        private void ButtonNowaGra_Click(object sender, RoutedEventArgs e) => NowaGra();

        private void ButtonKoniec_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
        #endregion

        #region METODY
        private void NowaGra() {
            WyczyscPoleGry();
            WyczyscObiekty();
            gracz1 = new Gracz(NadajImie("1 (X)"), 1, 'X');
            gracz2 = new Gracz(NadajImie("2 (O)"), 5, 'O');
            GraKK1 = new SilnikGRY(gracz1, gracz2);
            PanelGracz1.DataContext = gracz1;
            PanelGracz2.DataContext = gracz2;
            WyswietlAktywnego();
            WyswietlInfo(string.Format("Rozpoczyna gracz: {0}", GraKK1.AktywnyGracz().nazwa));
        }

        private void NowaRunda(string wynik) {
            if (wynik == "Remis") WyswietlInfo("Remis");
            else WyswietlInfo(string.Format("Wygrał gracz {0}", wynik));
            WyczyscPoleGry();
            WyswietlAktywnego();
            WyswietlInfo(string.Format("Rozpoczyna gracz: {0}", GraKK1.AktywnyGracz().nazwa));
        }

        private void WyswietlInfo(string tekstInformacji) {
            Informacja info = new Informacja {Owner = this};
            info.GrafikaInfo.Content = string.Format(tekstInformacji);
            info.ShowDialog();
        }

        private void WyczyscPoleGry() {
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

        private void WyswietlAktywnego() {
            this.LabelAktywnyGracz.Content = string.Format("Aktualny gracz: {0}", GraKK1.AktywnyGracz().nazwa);
        }

        private string NadajImie(string nr) {
            InputTextBox okienko = new InputTextBox(string.Format("Podaj imię gracza {0}", nr));
            okienko.Owner = this;
            okienko.ShowDialog();
            return okienko.WprowdzonyTekst.Text;
        }

        private void WyczyscObiekty() {
            if (GraKK1 != null) GraKK1 = null;
            if (gracz1 != null) gracz1 = null;
            if (gracz2 != null) gracz2 = null;
        }
        #endregion
    }
}
