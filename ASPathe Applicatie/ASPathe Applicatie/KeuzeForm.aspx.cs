using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPathe_Applicatie
{
    public partial class KeuzeForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUitloggen_Click(object sender, EventArgs e)
        {
            Response.Redirect("InlogForm.aspx");
        }

        protected void btnBeheren_Click(object sender, EventArgs e)
        {
            Response.Redirect("BeheerForm.aspx");

        }

        protected void btnKoppelen_Click(object sender, EventArgs e)
        {
            Response.Redirect("KoppelForm.aspx");

        }

        protected void btnOverzicht_Click(object sender, EventArgs e)
        {
            Response.Redirect("OverzichtForm.aspx");

        }
    }
}