using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPathe_Applicatie
{
    public class Voordeelticket
    {
        private string naam;
        private string prijs;

        public string Naam
        {
            get { return naam; }
            set { naam = value; }
        }

        public string Prijs
        {
            get { return prijs; }
            set { prijs = value; }
        }

        public Voordeelticket(string naam, string prijs)
        {
            this.naam = naam;
            this.prijs = prijs;
        }
    }
}
