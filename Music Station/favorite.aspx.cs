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
using System.Media;

namespace Music_Station
{
    public partial class favorite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["userId"] == null)
                Response.Redirect("login");
            else
            {
                meg.Text = "用戶 " + Session["userId"].ToString() + " ，你好";
                dataBind();
                if (msg.Text == "還沒有個人收藏清單！")
                    playBtn.Visible = false;
                else
                    playBtn.Visible = true;
            }
            playBtn.Attributes.Add("onclick", "this.form.target='_blank'");
            btn.Attributes.Add("onclick", "this.form.target=''");
            New.Attributes.Add("onclick", "this.form.target=''");
        }

        //載入資料
        protected void dg_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dg.CurrentPageIndex = e.NewPageIndex;
            dataBind();
        }

        //搜尋使用者之收藏清單資訊
        public void dataBind()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
            try
            {
                string Id = Session["userId"].ToString();
                string sqlselect = "SELECT musicName, singer, album FROM [favorite] where userId = '"+ Id +"'";
                SqlCommand cmd = new SqlCommand(sqlselect, conn);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                SqlCommandBuilder sqlcb = new SqlCommandBuilder(da);
                DataTable dt = new DataTable();

                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dg.DataSource = dt;
                    dg.DataBind();        //載入資料
                }
                else
                {
                    msg.Text = "還沒有個人收藏清單！";
                    dg.Visible = false;
                }

                for (int i = 0; i < this.dg.Items.Count; i++)
                     this.dg.Items[i].Cells[0].Attributes.Add("onclick", "return confirm('確認刪除該紀錄？')");
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

        //刪除被選定的欄位資料
        protected void dg_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
             msg.Text = "";
             SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
             string musicName = dg.DataKeys[e.Item.ItemIndex].ToString();
             conn.Open();
             try
             {
                  SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "delete from [favorite] where musicName=@Music";
                    cmd.Connection = conn;
                    cmd.Parameters.Add("@Music", SqlDbType.NChar).Value =  musicName;
                    cmd.ExecuteNonQuery();
                    dataBind();
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
        protected void dg_ItemCommand(object source, DataGridCommandEventArgs e)
        {

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default");        //返回首頁
        }

        protected void New_Click(object sender, EventArgs e)
        {
            Response.Redirect("searchMusic");    //歌曲新增
        }


        protected void playBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("playList");       //歌曲撥放
        }
    }
}