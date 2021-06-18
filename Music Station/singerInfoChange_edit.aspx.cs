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

namespace Music_Station
{
    public partial class singerInfoChange_edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dataBind();
            }
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            update_singer();
            Response.Redirect("singerInfoChange");
        }
        public void update_singer()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
            conn.Open();
            SqlTransaction myTrans = conn.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Transaction = myTrans;
                cmd.Connection = conn;
                cmd.CommandText = "select * from [singer] where singerId=@singerId";
                cmd.Parameters.Add("@singerId", SqlDbType.NChar).Value = getId().Trim().ToString();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                string oldsinger = dr.GetString(1).Trim();
                dr.Close();

                cmd.CommandText = "update [singer] set singer=@singer,sex=@sex where singerId=@singerId";

                cmd.Parameters.Add("@singer", SqlDbType.NChar).Value = singer.Text.Trim().ToString();
                cmd.Parameters.Add("@sex", SqlDbType.NChar).Value = sex.SelectedValue.Trim().ToString();
                cmd.Parameters.Add("@oldsinger", SqlDbType.NChar).Value = oldsinger;
                msg.Text = oldsinger;

                if (!singer.Text.Trim().ToString().Equals(oldsinger))
                {
                    if (!isExisted(cmd))
                    {
                        msg.Text = oldsinger;
                        cmd.CommandText = "update [singer] set singer=@singer,sex=@sex where singerId=@singerId";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "update [music] set singer='" + singer.Text.Trim().ToString() + "' where singer=@oldsinger";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "update [album] set singer='" + singer.Text.Trim().ToString() + "' where singer=@oldsinger";
                        cmd.ExecuteNonQuery();

                    }
                    else
                        Response.Write("<script>alert('文件名稱已存在！')</script>");
                }
                else
                {
                    cmd.ExecuteNonQuery();
                }
                myTrans.Commit();
            }
            catch (Exception ex)
            {
                msg.Text = ex.ToString();
                myTrans.Rollback();
            }
            finally
            {
                conn.Close();
            }
        }

        protected Boolean isExisted(SqlCommand cmd)
        {
            cmd.CommandText = "select * from [singer] where singer=@singer";
            SqlDataReader dr = cmd.ExecuteReader();
            Boolean check = dr.Read();
            dr.Close();
            return check;
        }
        public string getId()
        {
            string id = HttpContext.Current.Request.Url.PathAndQuery.ToString();
            int n = id.LastIndexOf('=');
            id = id.Substring(n + 1);
            return id;
        }
        public void dataBind()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from [singer] where singerId=@singerId";
                cmd.Parameters.Add("@singerId", SqlDbType.NChar).Value = getId();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    singer.Text = dr.GetString(1).Trim();
                    if (dr.GetString(2).Trim().ToString().Equals("男"))
                    {
                        sex.SelectedIndex = 0;
                    }
                    else
                        sex.SelectedIndex = 1;
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

        protected void return_Click(object sender, EventArgs e)
        {
            Response.Redirect("singerInfoChange");
        }
    }
}