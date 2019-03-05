using System.ComponentModel;

namespace GraKK {

    class Gracz : INotifyPropertyChanged {

        #region POLA KLASY / WŁAŚCIWOŚCI
        public event PropertyChangedEventHandler PropertyChanged;
        private byte ileZwyciestw;
        public string Nazwa { get; }
        public bool Aktywny { get; set; }
        public byte Liczba { get; }
        public char Znak { get; }
        public byte IleZwyciestw {
            get { return ileZwyciestw; }
            set {
                ileZwyciestw = value;
                OnPropertyChanged("IleZwyciestw");
            }
        }
        #endregion

        #region KONSTRUKTOR
        public Gracz(string imie, byte numer, char litera) {   
            Nazwa = imie;
            ileZwyciestw = 0;
            Liczba = numer;
            Znak = litera;
        }
        #endregion

        #region ZDARZENIA
        protected void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
