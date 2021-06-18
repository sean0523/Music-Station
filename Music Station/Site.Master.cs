using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Music_Station
{
    public partial class SiteMaster : MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] == null)
            {
                LinkButton1.Text = "🔐登入";
                LinkButton2.Visible = false;
            }
            else
            {
                LinkButton1.Text = "用戶: " + Session["userId"] + "  🔐登出";
                if (Session["userId"].ToString() == "admin")
                    LinkButton2.Visible = true;
                else
                    LinkButton2.Visible = false;
            }  
        }
    }
}