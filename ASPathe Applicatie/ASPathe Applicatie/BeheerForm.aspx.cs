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
            RefreshAlles();
        }

        public void GeefMessage(string message)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }

        public void RefreshAlles()
        {
            ddlBioscopen.Items.Clear();
            lbBioscopen.Items.Clear();
            ddlActeurs.Items.Clear();
            lbActeurs.Items.Clear();
            foreach (Acteur a in databasekoppeling.HaalActeursOp())
            {
                ddlActeurs.Items.Add(a.Voornaam + a.Achternaam);
                lbActeurs.Items.Add(a.Voornaam + a.Achternaam + a.Geboortedatum);
            }
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
            }
        }

        protected void btnMaakActeurAan_Click(object sender, EventArgs e)
        {
            if (tbVoornaam.Text != "")
            {
                if (tbAchternaam.Text != "")
                {
                    if (tbGeboortedatum.Text != "")
                    {
                        int id = databasekoppeling.VraagHoogsteActeurIDOp() + 1;
                        string voornaam = tbVoornaam.Text;
                        string achternaam = tbAchternaam.Text;
                        string geboortedatum = tbGeboortedatum.Text;
                        databasekoppeling.VoegActeurToe(id, voornaam, achternaam, geboortedatum);
                        RefreshAlles();
                        GeefMessage("Achteur aangemaakt");
                    }
                    GeefMessage("Voer een geboortedatum in");
                }
                GeefMessage("Voer een achternaam in");
            }
            GeefMessage("Voer een voornaam in");
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            tbGeboortedatum.Text = Convert.ToString(Calendar1.SelectedDate.ToShortDateString());
        }
    }
}