using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPathe_Applicatie
{
    public class Film
    {
        private string titel;
        private string genre;
        private string tijdsduur;
        private string regisseur;
        private string ondertiteling;

        public string Titel
        {
            get { return titel; }
            set { titel = value; }
        }

        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        public string Tijdsduur
        {
            get { return tijdsduur; }
            set { tijdsduur = value; }
        }

        public string Regisseur
        {
            get { return regisseur; }
            set { regisseur = value; }
        }

        public string Ondertiteling
        {
            get { return ondertiteling; }
            set { ondertiteling = value; }
        }

        public Film(string titel, string genre, string tijdsduur, string regisseur, string ondertiteling)
        {
            this.titel = titel;
            this.genre = genre;
            this.tijdsduur = tijdsduur;
            this.regisseur = regisseur;
            this.ondertiteling = ondertiteling;
        }
    }
}
