using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPathe_Applicatie
{
    public class Formaat
    {
        private string naam;

        public string Naam
        {
            get { return naam; }
            set { naam = value; }
        }

        public Formaat(string naam)
        {
            this.naam = naam;
        }
    }
}
