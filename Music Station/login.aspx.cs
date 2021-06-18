using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Music_Station
{
    public partial class regist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] != null)
                Response.Redirect("searchMusic");
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
            try
            {
                Session["type"] = "";
                Session["userId"] = "";
                string Id = userId.Text;
                string sql = "select password,type from [user] where userId='" + Id + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                string passwd = "";
                if (dr.Read())
                {
                    string type = dr.GetString(1).Trim();
                    passwd = dr.GetString(0);

                    if (passwd.Trim().ToString() == Password.Text.Trim().ToString())
                    {
                        Session["userId"] = userId.Text.ToString();
                        Session["type"] = type;
                        Response.Redirect("Default");
                    }
                    else
                    {
                        FailureText.Text = "密碼錯誤，登錄失敗！";
                        Session["userId"] = null;
                        Password.Text = "";
                    }
                }
                else
                {
                    Session["userId"] = null;
                    Session.Clear();
                    userId.Text = "";
                    Password.Text = "";
                    FailureText.Text = "無此帳號，登錄失敗！";
                }
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('登錄失敗！')</script>");
                Response.Write(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        protected void button_Click(object sender, EventArgs e)
        {
            Response.Redirect("regist");
        }

        protected void forget_Click(object sender, EventArgs e)
        {
            Response.Redirect("forgetId");
        }
    }
}