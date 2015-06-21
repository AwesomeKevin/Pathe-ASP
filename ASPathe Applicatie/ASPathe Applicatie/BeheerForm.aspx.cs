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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshAlles();
            }
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
            //Hier worden de ddl en lb voor bioscopen leeggemaakt en gevuld
            ddlBioscopen.Items.Clear();
            lbBioscopen.Items.Clear();
            foreach (Bioscoop b in databasekoppeling.HaalBioscopenOp())
            {
                ddlBioscopen.Items.Add(b.Bioscoopnaam);
                lbBioscopen.Items.Add(b.Bioscoopnaam + " - " + b.Plaats + " - " + b.Adres + " - " + b.Postcode);
            }
            //Hier worden de ddl en lb voor acteurs leeggemaakt en gevuld
            ddlActeurs.Items.Clear();
            lbActeurs.Items.Clear();
            foreach (Acteur a in databasekoppeling.HaalActeursOp())
            {
                ddlActeurs.Items.Add(a.Voornaam);
                lbActeurs.Items.Add(a.Voornaam + " " + a.Achternaam + " - " + a.Geboortedatum);
            }
            //Hier worden de ddl en lb voor films leeggemaakt en gevuld
            ddlFilms.Items.Clear();
            lbFilms.Items.Clear();
            foreach (Film f in databasekoppeling.HaalFilmsOp())
            {
                ddlFilms.Items.Add(f.Titel);
                lbFilms.Items.Add(f.Titel + " - " + f.Regisseur + " - " + f.Genre + " - " + f.Tijdsduur + " - " + f.Ondertiteling);
            }
            //Hier worden alle textboxen leeggemaakt
            tbTitel.Text = "";
            tbGenre.Text = "";
            tbTijdsduur.Text = "";
            tbRegisseur.Text = "";
            tbTaalversie.Text = "";
            tbOndertiteling.Text = "";
            tbLeeftijd.Text = "";
            tbVoornaam.Text = "";
            tbAchternaam.Text = "";
            tbGeboortedatum.Text = "";
            tbBioscoopnaam.Text = "";
            tbPlaats.Text = "";
            tbAdres.Text = "";
            tbPostcode.Text = "";
        }

        //Hieronder staan alle button_Click methodes voor het aanmaken
        //Aanmaken van een bioscoop
        public void btnMaakBioscoopAan_Click(object sender, EventArgs e)
        {
            if (tbBioscoopnaam.Text != "")
            {
                if (tbPlaats.Text != "")
                {
                    if (tbAdres.Text != "")
                    {
                        if (tbPostcode.Text != "")
                        {
                            string bioscoopnaam = tbBioscoopnaam.Text;
                            string plaats = tbPlaats.Text;
                            string adres = tbAdres.Text;
                            string postcode = tbPostcode.Text;
                            if (databasekoppeling.VoegBioscoopToe(bioscoopnaam, plaats, adres, postcode))
                            {
                                RefreshAlles();
                                GeefMessage("Bioscoop aangemaakt");
                            }
                            GeefMessage("Bioscoop aanmaken mislukt");
                        }
                        GeefMessage("Voer postcode in");
                    }
                    GeefMessage("Voer adres in");
                }
                GeefMessage("Voer plaats in");
            }
            GeefMessage("Voer bioscoopnaam in");
        }

        //Aanmaken van een acteur
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
                        if (databasekoppeling.VoegActeurToe(id, voornaam, achternaam, geboortedatum))
                        {
                            RefreshAlles();
                            GeefMessage("Acteur aangemaakt");
                        }
                        GeefMessage("Acteur aanmaken mislukt");
                    }
                    GeefMessage("Voer een geboortedatum in");
                }
                GeefMessage("Voer een achternaam in");
            }
            GeefMessage("Voer een voornaam in");
        }

        //Wanneer de selectie van de calender veranderd wordt dit in de textbox gezet
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            tbGeboortedatum.Text = Convert.ToString(Calendar1.SelectedDate.ToShortDateString());
        }

        //Film aanmaken
        protected void btnMaakFilmAan_Click(object sender, EventArgs e)
        {
            if (tbTitel.Text != "")
            {
                if (tbGenre.Text != "")
                {
                    if (tbTijdsduur.Text != "")
                    {
                        if (tbRegisseur.Text != "")
                        {
                            if (tbTaalversie.Text != "")
                            {
                                if (tbOndertiteling.Text != "")
                                {
                                    if (tbLeeftijd.Text != "")
                                    {
                                        int id = databasekoppeling.VraagHoogsteFilmIDOp() + 1;
                                        string titel = tbTitel.Text;
                                        string genre = tbGenre.Text;
                                        int tijdsduur = Convert.ToInt32(tbTijdsduur.Text);
                                        string regisseur = tbRegisseur.Text;
                                        string taalversie = tbTaalversie.Text;
                                        string ondertiteling = tbOndertiteling.Text;
                                        int leeftijd = Convert.ToInt32(tbLeeftijd.Text);
                                        if (databasekoppeling.VoegFilmToe(id, titel, genre, tijdsduur, regisseur, taalversie, ondertiteling, leeftijd))
                                        {
                                            RefreshAlles();
                                            GeefMessage("Film aangemaakt");
                                        }
                                        GeefMessage("Film aanmaken mislukt");
                                    }
                                    GeefMessage("Voer een minimale leeftijd in");
                                }
                                GeefMessage("Voer ondertiteling in");
                            }
                            GeefMessage("Voer taalversie in");
                        }
                        GeefMessage("Voer regisseur in");
                    }
                    GeefMessage("Voer tijdsduur in");
                }
                GeefMessage("Voer gnere in");
            }
            GeefMessage("Voer titel in");
        }

        //Hieronder staan alle button_Click methodes voor het aanpassen
        //Film aanpassen
        protected void btnPasFilmAan_Click(object sender, EventArgs e)
        {
            string geselecteerdeFilm = Convert.ToString(ddlFilms.SelectedItem);
            string titel = tbTitel.Text;
            string genre = tbGenre.Text;
            string tijdsduur = tbTijdsduur.Text;
            string regisseur = tbRegisseur.Text;
            string taalversie = tbTaalversie.Text;
            string ondertiteling = tbOndertiteling.Text;
            string leeftijd = tbLeeftijd.Text;
            if (databasekoppeling.WijzigFilm(geselecteerdeFilm, titel, genre, tijdsduur, regisseur, taalversie, ondertiteling, leeftijd))
            {
                RefreshAlles();
                GeefMessage("Film aangepast");
            }
            GeefMessage("Film aanpassen mislukt");
        }

        //Acteur aanpassen
        protected void btnPasActeurAan_Click(object sender, EventArgs e)
        {
            string geselecteerdeActeur = Convert.ToString(ddlActeurs.SelectedItem);
            string voornaam = tbVoornaam.Text;
            string achternaam = tbAchternaam.Text;
            string geboortedatum = tbGeboortedatum.Text;
            if (databasekoppeling.WijzigActeur(geselecteerdeActeur, voornaam, achternaam, geboortedatum))
            {
                RefreshAlles();
                GeefMessage("Acteur aangepast");
            }
            GeefMessage("Acteur aanpassen mislukt");
        }

        //Bioscoop aanpassen
        protected void btnPasBioscoopAan_Click(object sender, EventArgs e)
        {
            string geselecteerdeBioscoop = Convert.ToString(ddlBioscopen.SelectedItem);
            string bioscoopnaam = tbBioscoopnaam.Text;
            string plaats = tbPlaats.Text;
            string adres = tbAdres.Text;
            string postcode = tbPostcode.Text;
            if (databasekoppeling.WijzigBioscoop(geselecteerdeBioscoop, bioscoopnaam, plaats, adres, postcode))
            {
                RefreshAlles();
                GeefMessage("Bioscoop aangepast");
            }
            GeefMessage("Bioscoop aanpassen mislukt");
        }

        protected void btnVerwijderFilm_Click(object sender, EventArgs e)
        {
            string geselecteerdeFilm = Convert.ToString(ddlFilms.SelectedItem);
            if (databasekoppeling.VerwijderFilm(geselecteerdeFilm))
            {
                RefreshAlles();
                GeefMessage("Film verwijderd");
            }
            GeefMessage("Film verwijderen mislukt");
        }

        protected void btnVerwijderActeur_Click(object sender, EventArgs e)
        {
            string geselecteerdeActeur = Convert.ToString(ddlActeurs.SelectedItem);
            if (databasekoppeling.VerwijderActeur(geselecteerdeActeur))
            {
                RefreshAlles();
                GeefMessage("Acteur verwijderd");
            }
            GeefMessage("Acteur verwijderen mislukt");
        }

        protected void btnVerwijderBioscoop_Click(object sender, EventArgs e)
        {
            string geselecteerdeBioscoop = Convert.ToString(ddlBioscopen.SelectedItem);
            if (databasekoppeling.VerwijderBioscoop(geselecteerdeBioscoop))
            {
                RefreshAlles();
                GeefMessage("Bioscoop verwijderd");
            }
            GeefMessage("Bioscoop verwijderen mislukt");
        }
    }
}