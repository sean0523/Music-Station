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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        public Boolean isExisted(SqlCommand cmd)
        {
            cmd.CommandText = "select * from [user] where userId=@userId";
            SqlDataReader dr = cmd.ExecuteReader();
            bool check;
            if (dr.Read())
            {
                check = true;
            }
            else
                check = false;
            dr.Close();
            return check;
        }

        protected void addbtn_Click(object sender, EventArgs e)
        {
            Label2.Text = "(必填)";
            Label1.Text = "(必填)";
            Label3.Text = "(必填)";
            Label4.Text = "(必填)";
            meg.Text = "";

            if (userId.Text == "" || password.Text == "")
            {
                Label2.Text = "請輸入使用者帳號";
                Label1.Text = "請輸入使用者密碼";
                meg.Text = "帳號與密碼欄位必填，請輸入";
            }
            else if(repassword.Text == "" || repassword.Text == null)
            {
                Label3.Text = "請再一次輸入密碼";
            }
            else if (password.Text != repassword.Text)
            {
                repassword.Text = "";
                meg.Text = "兩次密碼輸入不一致，請確認後並重新輸入";
                Label3.Text = "再次輸入密碼";
            }
            else if(mail.Text == "" || mail.Text == null )
            {
                Label4.Text = "E-mail 欄位不能為空，請輸入";
            }
                
            else if (Page.IsValid)
            {
                meg.Text = "";
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    cmd.Parameters.Add("@userId", SqlDbType.NChar).Value = userId.Text.Trim();
                    cmd.Parameters.Add("@passwd", SqlDbType.NChar).Value = password.Text.Trim();
                    cmd.Parameters.Add("@name", SqlDbType.NChar).Value = name.Text.Trim();
                    cmd.Parameters.Add("@sex", SqlDbType.NChar).Value = sex.SelectedValue.ToString();
                    cmd.Parameters.Add("@mail", SqlDbType.NChar).Value = mail.Text.Trim();
                    cmd.Parameters.Add("@type", SqlDbType.NChar).Value = "user";
                    if (!isExisted(cmd))
                    {
                        cmd.CommandText = "INSERT INTO [user] VALUES (@userId,@passwd,@name,@sex,@mail,@type)";
                        cmd.ExecuteNonQuery();
                        meg.Text = "註冊成功！";
                        userId.Text = "";
                        name.Text = "";
                        mail.Text = "";
                        Response.Redirect("Default.aspx");
                    }
                    else
                        meg.Text = "使用者帳號已存在！";
                        userId.Text = "";
                        password.Text = "";
                        repassword.Text = "";

                }
                catch (Exception ex)
                {
                    meg.Text = "註冊失敗！" + ex.ToString();

                }
                finally
                {
                    conn.Close();
                }
            }
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default");
        }
    }
}