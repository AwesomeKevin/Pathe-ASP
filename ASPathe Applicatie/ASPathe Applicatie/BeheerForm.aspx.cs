using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPathe_Applicatie
{
    public partial class BeheerForm : System.Web.UI.Page
    {
        DatabaseKoppeling databasekoppeling = new DatabaseKoppeling();
        List<Bioscoop> bioscopen;
        protected void Page_Load(object sender, EventArgs e)
        {
            bioscopen = new List<Bioscoop>();
            VerversBioscopen();
        }

        public void btnMaakBioscoopAan_Click(object sender, EventArgs e)
        {
            string bioscoopnaam = tbBioscoopnaam.Text;
            string plaats = tbPlaats.Text;
            string adres = tbAdres.Text;
            string postcode = tbPostcode.Text;
            databasekoppeling.VoegBioscoopToe(bioscoopnaam, plaats, adres, postcode);
            foreach (Bioscoop b in bioscopen)
            {
                lbBioscopen.Items.Add(b.Bioscoopnaam);
                VerversBioscopen();
            }
        }

        public void VerversBioscopen()
        {
            lbBioscopen.Items.Clear();
            foreach (Bioscoop b in bioscopen)
            {
                string info = b.Bioscoopnaam + ", " + b.Plaats + ", " + b.Adres + ", " + b.Postcode;
                lbBioscopen.Items.Add(info);
            }
            ddlBioscopen.Items.Clear();
            foreach (Bioscoop bios in bioscopen)
            {
                lbBioscopen.Items.Add(bios.Bioscoopnaam);
            }
        }

        
    }
}