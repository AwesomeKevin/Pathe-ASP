using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPathe_Applicatie
{
    public class Voorstelling
    {
        private Bioscoop bioscoopnaam;
        private Film filmnaam;
        private DateTime datum;
        private Formaat formaat;

        public Bioscoop Bioscoopnaam
        {
            get { return bioscoopnaam; }
            set { bioscoopnaam = value; }
        }

        public Film Filmnaam
        {
            get { return filmnaam; }
            set { filmnaam = value; }
        }
        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }

        public Formaat Formaat
        {
            get { return formaat; }
            set { formaat = value; }
        }

        public Voorstelling(Bioscoop bioscoopnaam, Film filmnaam, DateTime datum, Formaat formaat)
        {
            this.bioscoopnaam = bioscoopnaam;
            this.filmnaam = filmnaam;
            this.datum = datum;
            this.formaat = formaat;
        }
    }
}
