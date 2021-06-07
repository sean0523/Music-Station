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
using System.Net;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace Music_Station
{
    public partial class musicChange_edit : System.Web.UI.Page
    {
        Hashtable typeindex, singerindex, albumindex;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                typeindex = new Hashtable();
                singerindex = new Hashtable();
                albumindex = new Hashtable();
                bindsingerlist();
                bindalbumlist();
                dataBind();
            }
        }

        public void bindsingerlist()
        {

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
            try
            {

                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from [singer]";

                SqlDataReader dr = cmd.ExecuteReader();

                singer.Items.Clear();
                int i = 0;

                while (dr.Read())
                {
                    singerindex[dr.GetString(1).Trim()] = i;
                    singer.Items.Add(dr.GetString(1).Trim());
                    i++;
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
        public void bindalbumlist()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from [album]";
                SqlDataReader dr = cmd.ExecuteReader();
                album.Items.Clear();
                int i = 0;
                while (dr.Read())
                {
                    albumindex[dr.GetString(1).Trim()] = i;
                    album.Items.Add(dr.GetString(1).Trim());
                    i++;
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

        public int gettype(string type, Hashtable hs)
        {
            if (hs[type] != null)
                return (int)hs[type];
            else
                return 0;
        }

        public void dataBind()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from [music] where id=@id";
                cmd.Parameters.Add("@id", SqlDbType.NChar).Value = getId();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                musicName.Text = dr.GetString(1).Trim();
                singer.SelectedIndex = gettype(dr.GetString(2).Trim(), singerindex);
                album.SelectedIndex = gettype(dr.GetString(3).Trim(), albumindex);
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
        protected void btn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from [music] where id=@id";
                cmd.Parameters.Add("@id", SqlDbType.NChar).Value = getId();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                string m_name = dr.GetString(1).Trim().ToString();
                dr.Close();

                cmd.CommandText = "update [music] set musicName=@musicName,singer=@singer,album=@album,type=@type where id=@id";
                cmd.Parameters.Add("@musicName", SqlDbType.NChar).Value = musicName.Text.Trim().ToString();
                cmd.Parameters.Add("@singer", SqlDbType.NChar).Value = singer.SelectedValue.Trim().ToString();
                cmd.Parameters.Add("@album", SqlDbType.NChar).Value = album.SelectedValue.Trim().ToString();
                cmd.Parameters.Add("@type", SqlDbType.NChar).Value = typelist1.SelectedValue.Trim().ToString();
                string oldpath = new DirectoryInfo(Server.MapPath("")).FullName.ToString() + @"\file\" + m_name;
                string newpath = new DirectoryInfo(Server.MapPath("")).FullName.ToString() + @"\file\" + musicName.Text.Trim().ToString();
                FileInfo fi = new FileInfo(newpath);
                if (!musicName.Text.Trim().ToString().Equals(m_name))
                {
                    if (!fi.Exists)
                    {
                        cmd.ExecuteNonQuery();
                        File.Move(oldpath, newpath);
                        msg.Text = oldpath;
                    }
                    else
                        Response.Write("<script>alert('文件名稱已存在！')</script>");
                }
                else
                    cmd.ExecuteNonQuery();
                Response.Redirect("musicChange");

            }
            catch (Exception ex)
            {
                msg.Text = ex.Message.ToString();
            }
            finally
            {
                conn.Close();
            }
        }
    }
}