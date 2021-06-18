using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Music_Station
{
    public partial class RankLink : System.Web.UI.Page
    {
        public string fileUrl;
        public string name;

        protected void Page_Load(object sender, EventArgs e)
        {

            album.Text = Session["albumName"].ToString();
            if (!IsPostBack)
            {
                string path = new DirectoryInfo(Server.MapPath("")).FullName.ToString() + @"\file\";
                string str = path.Replace('\\', '/');
                fileUrl = str;

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM [music] WHERE(album like '%'+@album+'%') ORDER BY count DESC";
                cmd.Parameters.Add("@album", SqlDbType.NChar).Value = Session["albumName"];
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    singer.Text = dr.GetString(2);
                    ListItem listItem = new ListItem { Value = dr.GetString(0), Text = dr.GetString(1) };
                    Select1.Items.Add(listItem);
                }
                Select1.Items[0].Selected = true;
                dr.Close();
                cmd.Connection.Close();

                string imagePath = "~/PIC/" + Session["albumName"] + ".jpg";
                Image1.ImageUrl = imagePath;

                string path1 = new DirectoryInfo(Server.MapPath("")).FullName.ToString() + @"\introduction\" + Session["albumName"] + ".txt";
                string str1 = path1.Replace('\\', '/');
                if (File.Exists(str1))
                {
                    string[] readText = File.ReadAllLines(path1);
                    foreach (string s in readText)
                    {
                        string a = s + "<br/>";
                        list.Text = list.Text + a;
                    }
                }
                else
                    list.Text = "目前無專輯介紹";
            }

        }

        public string getId()
        {
            string id = HttpContext.Current.Request.Url.PathAndQuery;
            int n = id.LastIndexOf('=');
            id = id.Substring(n + 1);
            return id;
        }

        protected void btnSelectPlay_Click(object sender, EventArgs e)
        {
            string id = Select1.Items[Select1.SelectedIndex].Value;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
            String sql = "select * from [music] where id=" + id;
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string path = new DirectoryInfo(Server.MapPath("")).FullName.ToString() + @"\file\" + dr.GetString(1);
                string str = path.Replace('\\', '/');
                fileUrl = str;
                name = @"\listen\" + dr.GetString(1).Trim();
            }
        }

        protected void return_Click(object sender, EventArgs e)
        {
            Response.Redirect("Rank");
        }
    }
}