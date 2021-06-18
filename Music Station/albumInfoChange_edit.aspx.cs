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
using System.Text;

namespace Music_Station
{
    public partial class albumInfoChange_edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dataBind();
            }
        }
        public void dataBind()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from [album] where albumId=@albumId";
                cmd.Parameters.Add("@albumId", SqlDbType.NChar).Value = getId();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    album.Text = dr.GetString(1).Trim();
                    singer.Text = dr.GetString(2).Trim();
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                msg.Text = ex.ToString();
            }
            finally
            {
                conn.Close();
            }
        }
        public string getId()
        {
            string id = HttpContext.Current.Request.Url.PathAndQuery.ToString();
            int n = id.LastIndexOf('=');
            id = id.Substring(n + 1);
            return id;
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            update_album();
            msg.Text = "專輯訊息修改完成";
            //Response.Redirect("albumInfoChange");
        }

        public void update_album()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from [album] where albumId=@albumId";
                cmd.Parameters.Add("@albumId", SqlDbType.NChar).Value = getId().Trim().ToString();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                string album_name = dr.GetString(1).Trim();
                string oldsinger = dr.GetString(2).Trim();
                dr.Close();

                cmd.CommandText = "update [album] set album=@album,singer=@singer where albumId=@albumId";
                cmd.Parameters.Add("@album", SqlDbType.NChar).Value = album.Text.Trim().ToString();
                cmd.Parameters.Add("@singer", SqlDbType.NChar).Value = singer.Text.Trim().ToString();
                cmd.Parameters.Add("@oldalbum", SqlDbType.NChar).Value = album_name.ToString();

                if (!album.Text.Trim().ToString().Equals(album_name))
                {
                    if (!isExisted(cmd))
                    {
                        cmd.CommandText = "update [album] set album=@album,singer=@singer where albumId=@albumId";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "update [music] set album='" + album.Text.Trim().ToString() + "',singer='" + singer.Text.Trim().ToString() + "' where album=@album";
                        cmd.Parameters["@album"].Value = album_name;
                        cmd.Parameters["@singer"].Value = oldsinger.ToString();
                        cmd.ExecuteNonQuery();
                        if (!isExistedInSinger(cmd))
                        {
                            insert_singer(cmd);
                        }
                    }
                    else
                        Response.Write("<script>alert('專輯名稱已經存在！')</script>");
                }
                else
                {
                    cmd.ExecuteNonQuery();
                    if (!isExistedInSinger(cmd))
                    {
                        insert_singer(cmd);
                    }
                }
            }
            catch (Exception ex)
            {
                msg.Text = ex.ToString();
            }
            finally
            {
                conn.Close();
            }
        }
        public string GetRndNumber(int Pos)
        {
            Random rnd = new Random(DateTime.Now.TimeOfDay.Milliseconds);
            StringBuilder str = new StringBuilder(10);
            for (int i = 0; i < Pos; i++)
            {
                int n = rnd.Next(10);
                str.Append(n.ToString());
            }
            return str.ToString();
        }
        protected void insert_singer(SqlCommand cmd)
        {
            cmd.CommandText = "insert into [singer] values(@singerId,@singer,@sex@count)";
            cmd.Parameters.Add("@singerId", SqlDbType.NChar).Value = GetRndNumber(15);
            cmd.Parameters["@singer"].Value = singer.Text.Trim().ToString();
            cmd.Parameters.Add("@sex", SqlDbType.NChar).Value = "男";
            cmd.Parameters.Add("@count", SqlDbType.Int).Value = 0;
            cmd.ExecuteNonQuery();
        }
        protected Boolean isExisted(SqlCommand cmd)
        {
            cmd.CommandText = "select * from [album] where album=@album";
            SqlDataReader dr = cmd.ExecuteReader();
            Boolean check = dr.Read();
            dr.Close();
            return check;
        }
        public Boolean isExistedInSinger(SqlCommand cmd)
        {
            cmd.CommandText = "select * from [singer] where singer=@singer";
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            Boolean check = dr.Read();
            dr.Close();
            return check;
        }

        protected void return_Click(object sender, EventArgs e)
        {
            Response.Redirect("manage_page");
        }
    }
}