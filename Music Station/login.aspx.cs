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
                string sql = "select * from [user] where userId='" + Id + "'";          //搜尋使用者之密碼與帳戶類型
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                string passwd = "";
                if (dr.Read())                                                          //判定帳號是否存在資料
                {
                    string type = dr.GetString(5).Trim();                               //紀錄資料庫帳戶類型
                    passwd = dr.GetString(1).Trim();                                           //紀錄資料庫密碼
                    string valid = dr.GetString(6).Trim();

                    if (passwd == Password.Text.Trim().ToString())    //比對密碼是否一致
                    {
                        if (valid == validation.Text.Trim().ToString())
                        {
                            if (verify.Text == Session["ValidatePictureCode"].ToString())   //比對驗證碼是否輸入正確
                            {
                                Session["userId"] = userId.Text.ToString();
                                Session["type"] = type;
                                Response.Redirect("Default");
                            }
                            else
                            {
                                Session["userId"] = null;
                                FailureText.Text = "圖形驗證碼輸入錯誤!!";
                                verify.Text = "";
                            }
                        }
                        else
                        {
                            Session["userId"] = null;
                            FailureText.Text = "個人驗證碼輸入錯誤!!";
                            validation.Text = "";
                        }
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
                FailureText.Text = ex.ToString();
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