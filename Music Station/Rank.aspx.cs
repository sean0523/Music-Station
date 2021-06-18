using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;

namespace Music_Station
{
    public partial class Rank : System.Web.UI.Page
    {
        public string name;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["albumName"] = "";
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            name = @"\listen\因為是你.mp3";
            //Response.Redirect("searchMusic");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            name = @"\listen\我們都傷.mp3";
            //Response.Redirect("searchMusic");
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            name = @"\listen\離開你以後.mp3";
            //Response.Redirect("searchMusic");
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            name = @"\listen\我很好騙.mp3";
            //Response.Redirect("searchMusic");
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            name = @"\listen\刻在我心底的名字.mp3";
            //Response.Redirect("searchMusic");
        }

        protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
        {
            name = @"\listen\與我無關.mp3";
            //Response.Redirect("searchMusic");
        }

        protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
        {
            Session["albumName"] = "都是因為愛";
            Response.Redirect("RankLink");
        }

        protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
        {
            Session["albumName"] = "刻在我心底的名字";
            Response.Redirect("RankLink");
        }

        protected void ImageButton9_Click(object sender, ImageClickEventArgs e)
        {
            Session["albumName"] = "唯一想了解的人";
            Response.Redirect("RankLink");
        }
        protected void btn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM [music] WHERE (album = @album) ORDER BY count DESC";
                cmd.Parameters.Add("@album", SqlDbType.NChar).Value = search.Text.Trim().ToString();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                SqlCommandBuilder sqlcb = new SqlCommandBuilder(da);
                DataSet ds = new DataSet();
                da.Fill(ds, "music");
                if (ds.Tables["music"].Rows.Count > 0)
                {
                    Session["albumName"] = search.Text.Trim().ToString();
                    search.Text = "";
                    Response.Redirect("RankLink");
                }
                else
                {
                    msg.Text = "無此專輯資訊";
                    search.Text = "";
                }
            }
            finally
            {
                conn.Close();
            }
        }
    }
}