using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Music_Station
{
    public partial class SongAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            msg.Text = "";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
            string filename = upload.PostedFile.FileName.ToString();
            int n = filename.LastIndexOf("\\");
            filename = filename.Substring(n + 1);
            string path = new DirectoryInfo(Server.MapPath("")).FullName.ToString() + @"\listen\";
            path = path.Replace('\\', '/');
            FileInfo fi = new FileInfo(path + filename);
            string musicname = filename;
            int i = 1;
            while (fi.Exists)
            {
                musicname = i.ToString() + "_" + filename;
                fi = new FileInfo(path + musicname);
                i++;
            }
            try
            {
                upload.SaveAs(path + musicname);
                conn.Open();
                msg.Text = "試聽曲目添加成功！";
            }
            finally
            {
                conn.Close();
            }
        }

        protected void exit_Click(object sender, EventArgs e)
        {
            Response.Redirect("manage_page");
        }
    }
}