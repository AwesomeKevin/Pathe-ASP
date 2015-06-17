using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPathe_Applicatie
{
    public partial class SignUpForm : System.Web.UI.Page
    {
        private DatabaseKoppeling database;

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
            if (tbID.Text != "")
            {
                if (Convert.ToInt32(tbID.Text) > Convert.ToInt32(database.VraagHoogsteIDOp()))
                {
                    if (tbVoornaam.Text != "")
                    {
                        if (tbAchternaam.Text != "")
                        {
                            if (tbGeboortedatum.Text != "")
                            {
                                if (tbGebruikersnaam.Text != "")
                                {
                                    if (tbWachtwoord.Text != "")
                                    {
                                        if (tbEmail.Text != "")
                                        {

                                        }
                                        GeefMessage("Voer een email in");
                                    }
                                    GeefMessage("Voer een wachtwoord in");
                                }
                                GeefMessage("Voer een gebruikersnaam in");
                            }
                            GeefMessage("Voer een geboortedatum in");
                        }
                        GeefMessage("Voer een achternaam in");
                    }
                    GeefMessage("Voer een Voornaam in");
                }
                GeefMessage("Dit ID bestaat al");
            }
            GeefMessage("Voer een ID in");
        }
    }
}