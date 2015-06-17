using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPathe_Applicatie
{
    public class Persoon
    {
        private string voornaam;
        private string achternaam;
        private string gebruikersnaam;
        private string wachtwoord;
        private string email;

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

        public string Gebruikersnaam
        {
            get { return gebruikersnaam; }
            set { gebruikersnaam = value; }
        }

        public string Wachtwoord
        {
            get { return wachtwoord; }
            set { wachtwoord = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public Persoon(string voornaam, string achternaam, string gebruikersnaam, string wachtwoord, string email)
        {
            this.voornaam = voornaam;
            this.achternaam = achternaam;
            this.gebruikersnaam = gebruikersnaam;
            this.wachtwoord = wachtwoord;
            this.email = email;
        }
    }
}
