using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Music_Station
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] != null)
            {
                Session["userid"] = null;
                Session.Clear();
                Response.Redirect("Default");
            }
            else
                Response.Redirect("Default");
        }
    }
}