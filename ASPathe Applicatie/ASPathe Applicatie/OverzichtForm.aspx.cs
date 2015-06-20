using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPathe_Applicatie
{
    public partial class OverzichtForm : System.Web.UI.Page
    {
        DatabaseKoppeling databasekoppeling = new DatabaseKoppeling();
        protected void Page_Load(object sender, EventArgs e)
        {
            RefreshAlles();
        }

        public void RefreshAlles()
        {
            lbBioscopen.Items.Clear();
            foreach (Bioscoop b in databasekoppeling.HaalBioscopenOp())
            {
                lbBioscopen.Items.Add(b.Bioscoopnaam + " - " + b.Plaats + " - " + b.Adres + " - " + b.Postcode);
            }
            lbActeurs.Items.Clear();
            foreach (Acteur a in databasekoppeling.HaalActeursOp())
            {
                lbActeurs.Items.Add(a.Voornaam + " " + a.Achternaam + " - " + a.Geboortedatum);
            }
            lbFilms.Items.Clear();
            foreach (Film f in databasekoppeling.HaalFilmsOp())
            {
                lbFilms.Items.Add(f.Titel + " - " + f.Regisseur + " - " + f.Genre + " - " + f.Tijdsduur + " - " + f.Ondertiteling);
            }
        }

        protected void btnUitloggen_Click(object sender, EventArgs e)
        {
            Response.Redirect("InlogForm.aspx");
        }
    }
}