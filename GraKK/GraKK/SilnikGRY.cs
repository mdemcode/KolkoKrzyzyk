using System;
using System.Windows;

namespace GraKK {

    class SilnikGRY {

        #region POLA KLASY
        public Gracz _gracz1, _gracz2;
        public byte[] poleGry;
        private byte ileRuchow;
        private byte ktoZaczyna;
        #endregion

        #region KONSTRUKTOR
        public SilnikGRY(Gracz gracz1, Gracz gracz2) {
            poleGry = new byte[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            _gracz1 = gracz1;
            _gracz2 = gracz2;
            ileRuchow = 0;
            LosujZaczynajacego();
        }
        #endregion

        #region METODY
        public void LosujZaczynajacego() {
            Random losuj = new Random();
            if (losuj.NextDouble() > 0.5) {
                _gracz1.aktywny = true;
                _gracz2.aktywny = false;
                ktoZaczyna = 1;
            }
            else {
                _gracz1.aktywny = false;
                _gracz2.aktywny = true;
                ktoZaczyna = 2;
            }
        }

        public char Klikniecie(byte nrPola) {
            if (poleGry[nrPola] > 0) {
                MessageBox.Show("To pole jest już zajęte!");
                return 'n';
            }
            ileRuchow++;
            poleGry[nrPola] = AktywnyGracz().liczba;
            return AktywnyGracz().znak;
        }

        public string KoniecRundy() {
            string wygrany = "";
            bool war1 = Warunek1();
            bool war2 = Warunek2();
            if (war1) {
                wygrany = _gracz1.nazwa;
                _gracz1.IleZwyciestw += 1;
            }
            if (war2) {
                wygrany = _gracz2.nazwa;
                _gracz2.IleZwyciestw += 1;
            }
            if (ileRuchow == 9 && !war1 && !war2) wygrany = "Remis";
            if (wygrany != "") {
                poleGry = new byte[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                ileRuchow = 0;
                ZmianaZaczynajacego();
            }
            return wygrany;
        }

        private bool Warunek1() {
            if (poleGry[0] + poleGry[1] + poleGry[2] == 3 ||
                poleGry[3] + poleGry[4] + poleGry[5] == 3 ||
                poleGry[6] + poleGry[7] + poleGry[8] == 3 ||
                poleGry[0] + poleGry[3] + poleGry[6] == 3 ||
                poleGry[1] + poleGry[4] + poleGry[7] == 3 ||
                poleGry[2] + poleGry[5] + poleGry[8] == 3 ||
                poleGry[0] + poleGry[4] + poleGry[8] == 3 ||
                poleGry[2] + poleGry[4] + poleGry[6] == 3) return true;
            else return false;
        }

        private bool Warunek2() {
            if (poleGry[0] + poleGry[1] + poleGry[2] == 15 ||
                poleGry[3] + poleGry[4] + poleGry[5] == 15 ||
                poleGry[6] + poleGry[7] + poleGry[8] == 15 ||
                poleGry[0] + poleGry[3] + poleGry[6] == 15 ||
                poleGry[1] + poleGry[4] + poleGry[7] == 15 ||
                poleGry[2] + poleGry[5] + poleGry[8] == 15 ||
                poleGry[0] + poleGry[4] + poleGry[8] == 15 ||
                poleGry[2] + poleGry[4] + poleGry[6] == 15) return true;
            else return false;
        }

        public Gracz AktywnyGracz() {
            return _gracz1.aktywny ? _gracz1 : _gracz2;
        }

        public void ZmianaGracza() {
            _gracz1.aktywny = _gracz1.aktywny ? false : true;
            _gracz2.aktywny = _gracz2.aktywny ? false : true;
        }

        private void ZmianaZaczynajacego() {
            if (ktoZaczyna==1) {
                ktoZaczyna = 2;
                _gracz1.aktywny = false;
                _gracz2.aktywny = true;
            }
            else {
                ktoZaczyna = 1;
                _gracz1.aktywny = true;
                _gracz2.aktywny = false;
            }
        }
        #endregion
    }
}
