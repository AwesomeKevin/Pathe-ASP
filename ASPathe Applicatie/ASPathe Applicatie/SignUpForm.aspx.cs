﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPathe_Applicatie
{
    public partial class SignUpForm : System.Web.UI.Page
    {
        private static DatabaseKoppeling database;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                database = new DatabaseKoppeling();
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

        protected void btnAnnuleer_Click(object sender, EventArgs e)
        {
            Response.Redirect("InlogForm.aspx");
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            if (tbVoornaam.Text != "")
            {
                if (tbAchternaam.Text != "")
                {
                    if (tbGeboortedatum.Text != "")
                    {
                        if (tbGeslacht.Text != "")
                        {
                            if (tbWachtwoord.Text != "")
                            {
                                if (tbEmail.Text != "")
                                {
                                    int id = database.VraagHoogstePersoonIDOp() + 1;
                                    string voornaam = tbVoornaam.Text;
                                    string tussenvoegsel = tbTussenvoegsel.Text;
                                    string achternaam = tbAchternaam.Text;
                                    string geboortedatum = tbGeboortedatum.Text;
                                    string geslacht = tbGeslacht.Text;
                                    string wachtwoord = tbWachtwoord.Text;
                                    string email = tbEmail.Text;
                                    if (database.VoegPersoonToe(id, voornaam, tussenvoegsel, achternaam, geboortedatum, geslacht, wachtwoord, email))
                                    {
                                        GeefMessage("Nieuwe persoon aangemaakt");
                                        tbVoornaam.Text = "";
                                        tbTussenvoegsel.Text = "";
                                        tbAchternaam.Text = "";
                                        tbGeboortedatum.Text = "";
                                        tbGeslacht.Text = "";
                                        tbWachtwoord.Text = "";
                                        tbEmail.Text = "";
                                    }
                                    GeefMessage("Nieuwe persoon aanmaken mislukt");
                                }
                                GeefMessage("Voer een email in");
                            }
                            GeefMessage("Voer een wachtwoord in");
                        }
                        GeefMessage("Voer een geslacht in");
                    }
                    GeefMessage("Voer een geboortedatum in");
                }
                GeefMessage("Voer een achternaam in");
            }
            GeefMessage("Voer een Voornaam in");
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            tbGeboortedatum.Text = Convert.ToString(Calendar1.SelectedDate.ToShortDateString());
        }
    }
}