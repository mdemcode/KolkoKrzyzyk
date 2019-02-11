using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GraKK
{
    class Gracz
    {
        public string nazwa;
        public byte ileZwyciestw;
        public bool aktywny;
        public byte liczba;
        public char znak;

        public Gracz(string imie, byte punkty, bool aktywnosc, byte numer, char litera)
        {
            nazwa = imie;
            ileZwyciestw = punkty;
            aktywny = aktywnosc;
            liczba = numer;
            znak = litera;
        }

    }
}
