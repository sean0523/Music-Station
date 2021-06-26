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
using System.Text;

namespace Music_Station
{
    public partial class downLoadList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string m_name = downMusic();   //取得歌名
                string path = new DirectoryInfo(Server.MapPath("")).FullName.ToString() + @"\file\" + m_name;
                string str = path.Replace('\\', '/');
                update_album();   //更新專輯資料表內count數值
                update_singer();  //更新歌手資料表內count數值
                System.IO.FileInfo file = new System.IO.FileInfo(str);

                if (file.Exists)   //檔案下載
                {
                    Response.Clear();
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(Encoding.UTF8.GetBytes(m_name)));
                    Response.AddHeader("Content-Length", file.Length.ToString());
                    Response.ContentType = "application/octet-stream";
                    Response.Filter.Close();
                    Response.WriteFile(file.FullName);
                    Response.End();
                }

                else
                {
                    Response.Write("This file does not exist.");
                }
                Response.Redirect("Default.aspx");
            }
        }

        //更新歌手資料表 count 數值
        public void update_singer()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                string s_name = getSinger(cmd);
                cmd.CommandText = "select * from [singer] where singer=@singer";
                cmd.Parameters.Add("@singer", SqlDbType.NChar).Value = s_name.Trim().ToString();
                SqlDataReader dr = cmd.ExecuteReader();
                int count = 0;
                if (dr.Read())
                {
                    count = dr.GetInt32(3) + 1;
                }
                dr.Close();
                cmd.CommandText = "update [singer] set count='" + count + "'where singer = @singer";
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }

        //獲得歌手資訊
        public string getSinger(SqlCommand cmd)
        {
            cmd.CommandText = "select * from [music] where id=@id";
            cmd.Parameters.Add("@id", SqlDbType.NChar).Value = getId().ToString();
            SqlDataReader dr = cmd.ExecuteReader();
            string m_name = "";
            if (dr.Read())
            {
                m_name = dr.GetString(2).Trim().ToString();
            }
            dr.Close();
            return m_name;
        }

        //更新專輯資料表內 count 數值
        public void update_album()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                string a_name = getAlbum(cmd);
                cmd.CommandText = "select * from [album] where album=@album";
                cmd.Parameters.Add("@album", SqlDbType.NChar).Value = a_name.Trim().ToString();
                SqlDataReader dr = cmd.ExecuteReader();
                int count = 0;
                if (dr.Read())
                {
                    count = dr.GetInt32(3) + 1;
                }
                dr.Close();
                cmd.CommandText = "update [album] set count='" + count + "'where album = @album";
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }

        //獲取專輯名
        public string getAlbum(SqlCommand cmd)
        {
            cmd.CommandText = "select * from [music] where id=@id";
            cmd.Parameters.Add("@id", SqlDbType.NChar).Value = getId().ToString();
            SqlDataReader dr = cmd.ExecuteReader();
            string m_name = "";
            if (dr.Read())
            {
                m_name = dr.GetString(3).Trim().ToString();
            }
            dr.Close();
            return m_name;
        }

        //取得音樂資料表資訊，並更新下載量與總訪問量數值
        public string downMusic()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from [music] where id=@id";
                cmd.Connection = conn;
                cmd.Parameters.Add("@id", SqlDbType.NChar).Value = getId().ToString();
                SqlDataReader dr = cmd.ExecuteReader();
                string m_name = "";
                int downLoadCount = 0;
                int count = 0;
                if (dr.Read())
                {
                    downLoadCount = dr.GetInt32(6) + 1;           //下載量
                    count = dr.GetInt32(5) + downLoadCount;       //總訪問量
                    m_name = dr.GetString(1).Trim().ToString();   //曲名
                }
                dr.Close();
                cmd.CommandText = "update [music] set downLoadCount='" + downLoadCount + "',count='" + count + "'where id = @id";
                cmd.ExecuteNonQuery();
                return m_name;
            }
            finally
            {
                conn.Close();
            }
        }

        //獲得當前選擇之歌曲ID
        public string getId()
        {
            string id = HttpContext.Current.Request.Url.PathAndQuery;
            int n = id.LastIndexOf('=');
            id = id.Substring(n + 1);
            return id;
        }
    }
}