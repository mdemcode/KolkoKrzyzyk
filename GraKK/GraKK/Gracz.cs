using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GraKK
{
    class Gracz
    {
        public string nazwa { get; }
        public byte ileZwyciestw { get; }
        public bool aktywny { get; set; }
        public byte liczba { get; }
        public char znak { get; }

        public Gracz(string imie, bool aktywnosc, byte numer, char litera)
        {
            nazwa = imie; // NadajImie(); // "Gracz"; // 
            ileZwyciestw = 0;
            aktywny = aktywnosc;
            liczba = numer;
            znak = litera;
        }
    }
}
