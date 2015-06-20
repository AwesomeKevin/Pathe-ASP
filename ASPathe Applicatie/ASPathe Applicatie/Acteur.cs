using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPathe_Applicatie
{
    public class Acteur
    {
        private string voornaam;
        private string achternaam;
        private string geboortedatum;

        public string Voornaam
        {
            get { return voornaam; }
            set { voornaam = value; }
        }

        public string Achternaam
        {
            get { return achternaam; }
            set { achternaam = value; }
        }

        public string Geboortedatum
        {
            get { return geboortedatum; }
            set { geboortedatum = value; }
        }

        public Acteur(string voornaam, string achternaam, string geboortedatum)
        {
            this.voornaam = voornaam;
            this.achternaam = achternaam;
            this.geboortedatum = geboortedatum;
        }
    }
}
