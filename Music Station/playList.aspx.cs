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
    
    public partial class playList : System.Web.UI.Page
    {
        public string fileUrl;
        public string name;
        public int i = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string path = new DirectoryInfo(Server.MapPath("")).FullName.ToString() + @"\file\" ;
                string str = path.Replace('\\', '/');
                fileUrl = str;

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
                string sql = "select * from [favorite] where userId='" + Session["userId"] + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListItem listItem = new ListItem { Value = dr.GetString(1), Text = dr.GetString(2) };
                    Select1.Items.Add(listItem);
                }
                Select1.Items[0].Selected = true;
                dr.Close();
                cmd.Connection.Close();
            }
        }
        public string getId()
        {
            string id = HttpContext.Current.Request.Url.PathAndQuery;
            int n = id.LastIndexOf('=');
            id = id.Substring(n + 1);
            return id;
        }
        protected void btnSelectPlay_Click1(object sender, EventArgs e)
        {
            Label1.Text = "";
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
                name = @"\file\" + dr.GetString(1).Trim();
            }
            
            char[] MyChar = { '.', 'm', 'p', '3' };
            string NewString = fileUrl.Trim().TrimEnd(MyChar);
            string path1 = NewString + ".txt";
            if (File.Exists(path1))
            {
                string[] readText = File.ReadAllLines(path1);
                foreach (string s in readText)
                {
                    string a = s +"<br/>";
                    Label1.Text = Label1.Text + a;
                }
            }
        }

        //下一首
        protected void btnIsPlay_Click(object sender, EventArgs e)
        {
            Label1.Text = "";
            string id = "";
            int selectIx = Select1.SelectedIndex;
            //順序播放
            if (ddlPlayType.SelectedValue == "0")
            {
                int listCount = Select1.Items.Count;
                //最後一首
                if ((selectIx + 1) == listCount)
                {
                    Select1.Items[selectIx].Selected = false;
                    Select1.Items[0].Selected = true;
                    id = Select1.Items[0].Value;
                }
                else
                {
                    //取下一首歌曲ID
                    id = Select1.Items[Select1.SelectedIndex + 1].Value;
                    Select1.Items[selectIx].Selected = false;
                    Select1.Items[selectIx + 1].Selected = true;
                }
            }
            //隨機撥放
            else if (ddlPlayType.SelectedValue == "1")
            {
                Random rad = new Random();
                int radIx = rad.Next(0, Select1.Items.Count);
                id = Select1.Items[radIx].Value;
                Select1.Items[selectIx].Selected = false;
                Select1.Items[radIx].Selected = true;

            }

            else
            {
                //單曲撥放
                id = Select1.Items[selectIx].Value;
            }
            string id1 = Select1.Items[Select1.SelectedIndex].Value;
            SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
            String sql1 = "select * from [music] where id=" + id;
            SqlCommand cmd1 = new SqlCommand(sql1, conn1);
            cmd1.Connection.Open();
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                string path = new DirectoryInfo(Server.MapPath("")).FullName.ToString() + @"\file\" + dr1.GetString(1);
                string str = path.Replace('\\', '/');
                fileUrl = str;
                name = @"\file\" + dr1.GetString(1).Trim();
            }
            char[] MyChar = { '.', 'm', 'p', '3' };
            string NewString = fileUrl.Trim().TrimEnd(MyChar);
            string path1 = NewString + ".txt";
            if (File.Exists(path1))
            {
                string[] readText = File.ReadAllLines(path1);
                foreach (string s in readText)
                {
                    string a = s + "<br/>";
                    Label1.Text = Label1.Text + a;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("favorite");
        }
    }
}