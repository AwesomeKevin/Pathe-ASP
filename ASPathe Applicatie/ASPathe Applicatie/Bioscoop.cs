using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPathe_Applicatie
{
    public class Bioscoop
    {
        private string bioscoopnaam;
        private string plaats;
        private string adres;
        private string postcode;
        public string Bioscoopnaam
        {
            get { return bioscoopnaam; }
            set { bioscoopnaam = value; }
        }

        public string Plaats
        {
            get { return plaats; }
            set { plaats = value; }
        }
        public string Adres
        {
            get { return adres; }
            set { adres = value; }
        }

        public string Postcode
        {
            get { return postcode; }
            set { postcode = value; }
        }

        public Bioscoop(string bioscoopnaam, string plaats, string adres, string postcode)
        {
            this.bioscoopnaam = bioscoopnaam;
            this.plaats = plaats;
            this.adres = adres;
            this.postcode = postcode;
        }
    }
}
