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

        //Deze methode zorgt ervoor dat alle ddl's en listboxen gevuld worden met de informatie van bioscopen, acteurs en films
        //d.m.v. de methodes in de databasekoppeling die uit de database de gevraagde informatie haalt
        public void RefreshAlles()
        {
            ddlBioscopen.Items.Clear();
            lbBioscopen.Items.Clear();
            foreach (Bioscoop b in databasekoppeling.HaalBioscopenOp())
            {
                ddlBioscopen.Items.Add(b.Bioscoopnaam);
                lbBioscopen.Items.Add(b.Bioscoopnaam + " - " + b.Plaats + " - " + b.Adres + " - " + b.Postcode);
            }
            ddlActeurs.Items.Clear();
            lbActeurs.Items.Clear();
            foreach (Acteur a in databasekoppeling.HaalActeursOp())
            {
                ddlActeurs.Items.Add(a.Voornaam + " " + a.Achternaam);
                lbActeurs.Items.Add(a.Voornaam + " " + a.Achternaam + " - " + a.Geboortedatum);
            }
            ddlFilms.Items.Clear();
            lbFilms.Items.Clear();
            foreach (Film f in databasekoppeling.HaalFilmsOp())
            {
                ddlFilms.Items.Add(f.Titel);
                lbFilms.Items.Add(f.Titel + " - " + f.Regisseur + " - " + f.Genre + " - " + f.Tijdsduur + " - " + f.Ondertiteling);
            }
        }

        public void btnMaakBioscoopAan_Click(object sender, EventArgs e)
        {
            string bioscoopnaam = tbBioscoopnaam.Text;
            string plaats = tbPlaats.Text;
            string adres = tbAdres.Text;
            string postcode = tbPostcode.Text;
            databasekoppeling.VoegBioscoopToe(bioscoopnaam, plaats, adres, postcode);
            RefreshAlles();
            GeefMessage("Bioscoop aangemaakt");
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

        protected void btnMaakFilmAan_Click(object sender, EventArgs e)
        {

        }
    }
}