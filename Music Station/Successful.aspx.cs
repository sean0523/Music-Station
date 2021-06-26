using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Music_Station
{
    public partial class Successful : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string from = "sean.su0611@gmail.com";
                string to = Session["3"].ToString();
                string subject = "酷炫音樂  會員註冊訊息說明";
                string body = "恭喜用戶註冊成功，請妥善保存個人註冊資訊，謝謝。" + "<br/><br/>" +
                            "使用者帳號: " + Session["1"] + "<br/>" +
                            "使用者密碼: " + Session["2"] + "<br/>" +
                           "個人驗證碼: " + Session["4"];
                try
                {
                    MailMessage messange = new MailMessage(from, to, subject, body);
                    messange.IsBodyHtml = true;
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.EnableSsl = true;
                    client.Credentials = new System.Net.NetworkCredential("sean.su0611@gmail.com", "rxupgpyujsanaxkx");
                    client.Send(messange);
                    status.Text = "註冊信發送成功!!!";
                }
                catch (Exception ex)
                {
                    status.Text = ex.StackTrace;
                }
            }
        }

        protected void exit_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default");
        }
    }
}