using System;
using System.Windows;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GraKK
{
    class SilnikGRY
    {
        public Gracz gracz1, gracz2;
        public byte[] poleGry;
        private byte ileRuchow;

        public SilnikGRY()
        {
            poleGry = new byte[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            gracz1 = new Gracz("Gracz1", 0, true, 1, 'X');
            gracz2 = new Gracz("Gracz2", 0, false, 5, 'O');
            ileRuchow = 0;
            MessageBox.Show(string.Format("Rozpoczyna gracz: {0}", AktywnyGracz().nazwa));
        }

        public char Klikniecie(byte nrPola)
        {
            if (poleGry[nrPola] > 0)
            {
                MessageBox.Show("To pole jest już zajęte!");
                return 'n';
            }
            ileRuchow++;
            poleGry[nrPola] = AktywnyGracz().liczba;
            return AktywnyGracz().znak;
        }

        public string KoniecRundy()
        {
            string wygrany = "";
            bool war1 = Warunek1();
            bool war2 = Warunek2();
            if (war1) wygrany = gracz1.nazwa;
            if (war2) wygrany = gracz2.nazwa;
            if (ileRuchow == 9 && !war1 && !war2) wygrany = "Remis";

            return wygrany;
        }

        private bool Warunek1()
        {
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

        private bool Warunek2()
        {
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

        public Gracz AktywnyGracz()
        {
            return gracz1.aktywny ? gracz1 : gracz2;
        }

        public void ZmianaGracza()
        {
            gracz1.aktywny = gracz1.aktywny ? false : true;
            gracz2.aktywny = gracz2.aktywny ? false : true;
        }
    }
}
