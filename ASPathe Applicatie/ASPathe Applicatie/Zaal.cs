using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPathe_Applicatie
{
    public class Zaal
    {
        private int zaalnummer;
        private int aantalStoelen;

        public int Zaalnummer
        {
            get { return zaalnummer; }
            set { zaalnummer = value; }
        }

        public int AantalStoelen
        {
            get { return aantalStoelen; }
            set { aantalStoelen = value; }
        }

        public Zaal(int zaalnummer, int aantalStoelen)
        {
            this.zaalnummer = zaalnummer;
            this.aantalStoelen = aantalStoelen;
        }
    }
}
