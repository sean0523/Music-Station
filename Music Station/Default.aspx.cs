using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Music_Station
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {   
            //頁面載入時判斷Session是否已經存在
            if (Session["userId"] == null)
                msg.Text = "";
            else
                msg.Text = Session["userId"].ToString() + " 你好，歡迎回來~~ ";
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["userId"] == null)
                Response.Redirect("login");
            else
                Response.Redirect("searchMusic");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("login");
        }
    }
}