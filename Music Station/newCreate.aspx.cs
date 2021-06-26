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
    public partial class newCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string m_name = updateMusic();      //更新音樂資料表內訪問量 visitVount 與總訪問量 count
                update_album();                     //更新專輯資料表內 count 數值
                update_singer();                    //更新歌手資料表內 count 數值
                addFavorite();                      //更新收藏資料表
                Response.Redirect("favorite");
                
            }
        }

        public string GetRndNumber(int Pos)
        {
            Random rnd = new Random(DateTime.Now.TimeOfDay.Milliseconds);
            StringBuilder str = new StringBuilder(Pos);
            for (int i = 0; i < Pos; i++)
            {
                int n = rnd.Next(10);
                str.Append(n.ToString());
            }
            return str.ToString();
        }

        //更新收藏資料表
        public void addFavorite()
        {
            string results = isExisted().ToString();
            if (results =="0")
            {
                string musicId = getId().ToString();
                string musicName = "";
                string singer = "";
                string album = "";

                //獲取音樂相關欄位資料
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "select * from [music] where id=@id";
                    cmd.Parameters.Add("@id", SqlDbType.NChar).Value = getId().ToString();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        musicName = dr.GetString(1).Trim().ToString();
                        singer = dr.GetString(2).Trim().ToString();
                        album = dr.GetString(3).Trim().ToString();
                    }
                    dr.Close();
                }
                finally
                {
                    conn.Close();
                }

                //寫入音樂相關欄位資料至收藏資料表內
                SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
                try
                {
                    conn1.Open();
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.Connection = conn1;
                    cmd1.Parameters.Add("@favoriteId", SqlDbType.NChar).Value = GetRndNumber(15);
                    cmd1.Parameters.Add("@ID", SqlDbType.NChar).Value = musicId;
                    cmd1.Parameters.Add("@musicName", SqlDbType.NChar).Value = musicName;
                    cmd1.Parameters.Add("@singer", SqlDbType.NChar).Value = singer;
                    cmd1.Parameters.Add("@album", SqlDbType.NChar).Value = album;
                    cmd1.Parameters.Add("@userId", SqlDbType.NChar).Value = Session["userId"].ToString();
                    cmd1.CommandText = "INSERT INTO [favorite] VALUES (@favoriteId,@ID,@musicName,@singer,@album,@userId)";
                    cmd1.ExecuteNonQuery();
                }
                finally
                {
                    conn1.Close();
                }
            }
        }

        //更新音樂資料表內訪問量 visitVount 與總訪問量 count
        public string updateMusic()
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
                int visitCount = 0;
                int count = 0;
                if (dr.Read())
                {
                    visitCount = dr.GetInt32(5) + 1;
                    count = dr.GetInt32(6) + visitCount;
                    m_name = dr.GetString(1).Trim().ToString();
                }
                dr.Close();
                cmd.CommandText = "update [music] set visitCount='" + visitCount + "',count='" + count + "'where id = @id";
                cmd.ExecuteNonQuery();
                return m_name;
            }
            finally
            {
                conn.Close();
            }
        }

        //更新歌手資料表內count數值
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
        public string getSinger(SqlCommand cmd)
        {
            cmd.CommandText = "select * from [music] where id=@id";
            cmd.Parameters.Add("@id", SqlDbType.NChar).Value = getId().ToString();
            SqlDataReader dr1 = cmd.ExecuteReader();
            string m_name = "";
            if (dr1.Read())
            {
                m_name = dr1.GetString(2).Trim().ToString();
            }
            dr1.Close();
            return m_name;
        }

        //更新專輯資料表內的count數
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

        //獲取專輯名稱
        public string getAlbum(SqlCommand cmd)
        {
            cmd.CommandText = "select * from [music] where id=@id";
            cmd.Parameters.Add("@id", SqlDbType.NChar).Value = getId().ToString();
            SqlDataReader dr2 = cmd.ExecuteReader();
            string m_name = "";
            if (dr2.Read())
            {
                m_name = dr2.GetString(3).Trim().ToString();
            }
            dr2.Close();
            return m_name;
        }

        //獲取歌曲名稱
        public string getmuName(SqlCommand cmd) 
        {
            cmd.CommandText = "select * from [music] where id=@id";
            cmd.Parameters.Add("@id", SqlDbType.NChar).Value = getId().ToString();
            SqlDataReader dr = cmd.ExecuteReader();
            string musicName = "";
            if (dr.Read())
            {
                musicName = dr.GetString(1).Trim().ToString();
            }
            dr.Close();
            
            return musicName;
        }

        //獲取歌曲ID
        public string getId()
        {
            string id = HttpContext.Current.Request.Url.PathAndQuery;
            int n = id.LastIndexOf('=');
            id = id.Substring(n + 1);
            return id;
        }

        //判斷個人收藏是否已存在相同歌曲
        public string isExisted()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
            conn.Open();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = conn;
            cmd1.CommandText = "select * from [favorite] where ID=@ID and userId=@userId";
            cmd1.Parameters.Add("@ID", SqlDbType.NChar).Value = getId().ToString();
            cmd1.Parameters.Add("@userId", SqlDbType.NChar).Value = Session["userId"].ToString();
            SqlDataReader dr = cmd1.ExecuteReader();
            int check;
            if (dr.Read())
            {
                check = 1;
            }
            else
                check = 0;
            dr.Close();
            conn.Close();
            string result = check.ToString();
            return result;
        }
    }
}