using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPathe_Applicatie
{
    public partial class InlogForm : System.Web.UI.Page
    {
        static DatabaseKoppeling database;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
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

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            if (tbGebruikersnaam.Text != null && tbWachtwoord.Text != null)
            {
                Persoon tempPersoon = database.CheckGebruikersnaam(tbGebruikersnaam.Text);
                if (tempPersoon != null)
                {
                    if (tempPersoon.Wachtwoord == tbWachtwoord.Text)
                    {
                        GeefMessage("Succesvol");
                        database.NuIngelogdePersoon = tempPersoon;
                        Doorverwijzen(tbGebruikersnaam.Text, tbWachtwoord.Text);
                    }
                    GeefMessage("Ongeldig wachtwoord");
                }
                GeefMessage("Niet succesvol");
            }
            GeefMessage("Ongeldige gebruikersnaam");
        }

        public void Doorverwijzen(string gebruikersnaam, string wachtwoord)
        {
            gebruikersnaam = tbGebruikersnaam.Text;
            wachtwoord = tbWachtwoord.Text;

            if (gebruikersnaam == "Kevin" && wachtwoord == "Kopp")
            {
                Response.Redirect("KeuzeForm.aspx");
            }
            else
            {
                Response.Redirect("OverzichtForm.aspx");
            }
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUpForm.aspx");
        }
    }
}