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
    public partial class forgetId : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void check_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
            try
            {
                Session["userId"] = "";
                string Id = userId.Text;
                string sql = "select * from [user] where userId='" + Id + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                string email = "";
                if (dr.Read())
                {
                    email = dr.GetString(4).Trim();

                    if (email.Trim().ToString() == eMail.Text.Trim().ToString())
                    {
                        if (password.Text == repassword.Text)
                        {
                            modify();
                            meg.Text = "密碼修改成功，請以新密碼登入";
                            userId.Text = "";
                            eMail.Text = "";
                            password.Text = "";
                            repassword.Text = "";
                            Session["userId"] = null;
                        }
                        else
                        {
                            meg.Text = "密碼輸入不一致，無法重置密碼";
                            repassword.Text = "";
                        }
                    }
                    else
                        meg.Text = "e-Mail驗證失敗，無法取得註冊資訊";
                }
                else
                {
                    meg.Text = "無此使用者帳號，請重新註冊";
                    userId.Text = "";
                    eMail.Text = "";
                    password.Text = "";
                    repassword.Text = "";
                }
            }
            finally
            {
                conn.Close();
            }
        }

        public void modify()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update [user] set password =@password where userId=@userId";
            cmd.Connection = conn;
            cmd.Parameters.Add("@userId", SqlDbType.NChar).Value = userId.Text.Trim();
            cmd.Parameters.Add("@password", SqlDbType.NChar).Value = password.Text.Trim();
            cmd.ExecuteNonQuery();
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("login");
        }
    }
}