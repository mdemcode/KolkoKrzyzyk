using System.ComponentModel;

namespace GraKK {

    class Gracz : INotifyPropertyChanged {

        #region POLA KLASY / WŁAŚCIWOŚCI
        public event PropertyChangedEventHandler PropertyChanged;
        private byte ileZwyciestw;
        public string nazwa { get; }
        public bool aktywny { get; set; }
        public byte liczba { get; }
        public char znak { get; }
        public byte IleZwyciestw {
            get { return ileZwyciestw; }
            set {
                ileZwyciestw = value;
                OnPropertyChanged("IleZwyciestw");
            }
        }
        #endregion

        #region KONSTRUKTOR
        public Gracz(string imie, bool aktywnosc, byte numer, char litera) {
            this.nazwa = imie;
            this.ileZwyciestw = 0;
            this.aktywny = aktywnosc;
            this.liczba = numer;
            this.znak = litera;
        }
        #endregion

        #region ZDARZENIA
        protected void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
