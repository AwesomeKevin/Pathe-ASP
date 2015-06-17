using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPathe_Applicatie
{
    public class Klant : Persoon
    {
        public Klant(string voornaam, string achternaam, string gebruikersnaam, string wachtwoord, string email) : base(voornaam, achternaam, gebruikersnaam, wachtwoord, email)
        {

        }
    }
}
