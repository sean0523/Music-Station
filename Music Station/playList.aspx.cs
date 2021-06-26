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
        public string mvName;
        public int i = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            Label3.Visible = false;
            Label4.Visible = false;
            Image1.Visible = false;

            if (!IsPostBack)
            {
                //設定撥放檔案路徑
                string path = new DirectoryInfo(Server.MapPath("")).FullName.ToString() + @"\file\" ;
                string str = path.Replace('\\', '/');
                fileUrl = str;
                //列出個人收藏清單
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
            mvSearch.Attributes.Add("onclick", "this.form.target='_blank'");        //按下mvSearch時開啟新頁面
            btnIsPlay.Attributes.Add("onclick", "this.form.target=''");
            btnSelectPlay.Attributes.Add("onclick", "this.form.target=''");
            Button1.Attributes.Add("onclick", "this.form.target=''");
        }

        //獲取音樂ID
        public string getId()
        {
            string id = HttpContext.Current.Request.Url.PathAndQuery;
            int n = id.LastIndexOf('=');
            id = id.Substring(n + 1);
            return id;
        }

        //音樂撥放
        protected void btnSelectPlay_Click1(object sender, EventArgs e)
        {
            Label1.Text = "";
            Label3.Visible = true;
            Label4.Visible = true;
            Image1.Visible = true;
            PlayMusic();        //讀取音樂播放函數
        }

        //下一首
        protected void btnIsPlay_Click(object sender, EventArgs e)
        {
            Label1.Text = "";
            Label3.Visible = true;
            Label4.Visible = true;
            Image1.Visible = true;
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
            PlayMusic();        //讀取音樂播放函數
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Response.Redirect("favorite");
            ClientScript.RegisterStartupScript(Page.GetType(), "", "<script language=javascript>window.opener=null;window.open('','_self');window.close();</script>");
        }

        protected void mvSearch_Click(object sender, EventArgs e)
        {
            string id = Select1.Items[Select1.SelectedIndex].Value;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
            String sql = "select * from [music] where id=" + id;
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                char[] MyChar = { '.', 'm', 'p', '3' };
                mvName = dr.GetString(1).Trim().TrimEnd(MyChar);
            }
            string link = "https://www.youtube.com/results?search_query=" + mvName;
            Response.Redirect(link);
        }
        
        //音樂播放動作
        public void PlayMusic()
        {
            string id = Select1.Items[Select1.SelectedIndex].Value;
            SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
            String sql = "select * from [music] where id=" + id;
            SqlCommand cmd = new SqlCommand(sql, conn1);
            cmd.Connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string path = new DirectoryInfo(Server.MapPath("")).FullName.ToString() + @"\file\" + dr.GetString(1);
                string str = path.Replace('\\', '/');
                fileUrl = str;
                name = @"\file\" + dr.GetString(1).Trim();
            }
            char[] MyChar = { '.', 'm', 'p', '3' };                             //設定字元陣列
            string NewString = fileUrl.Trim().TrimEnd(MyChar);                  //移除字串最後幾個包含字元陣列的內容
            string path1 = NewString + ".txt";
            string imagePath = "~/PIC/" + dr.GetString(3).Trim() + ".jpg";      //圖片檔路徑
            Image1.ImageUrl = imagePath;
            album.Text = dr.GetString(3).Trim();
            singer.Text = dr.GetString(2).Trim();

            if (File.Exists(path1))
            {
                string[] readText = File.ReadAllLines(path1);                   //讀取每行文字
                foreach (string s in readText)                                  //依序顯示
                {
                    string a = s + "<br/>";
                    Label1.Text = Label1.Text + a;
                }
            }
        }
    }
}