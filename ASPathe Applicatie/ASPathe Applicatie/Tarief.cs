using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPathe_Applicatie
{
    public class Tarief
    {
        private string prijs;

        public string Prijs
        {
            get { return prijs; }
            set { prijs = value; }
        }

        public Tarief(string prijs)
        {
            this.prijs = prijs;
        }
    }
}
