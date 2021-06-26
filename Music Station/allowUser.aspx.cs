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
    public partial class allowUser : System.Web.UI.Page
    {
        public string name;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dataBind();
            }
        }

        //載入資料
        protected void dg_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dg.CurrentPageIndex = e.NewPageIndex;
            dataBind();
        }

        //搜尋全部使用者帳戶資料，不包含管理者
        public void dataBind()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
            try
            {
                msg.Text = "";
                string sqlselect = "SELECT * FROM [user] where type='user'";

                SqlCommand cmd = new SqlCommand(sqlselect, conn);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                SqlCommandBuilder sqlcb = new SqlCommandBuilder(da);
                DataTable dt = new DataTable();

                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dg.DataSource = dt;
                    dg.DataBind();
                }
                else
                {
                    msg.Text = "還沒有註冊之用戶！";
                    dg.Visible = false;
                }
                //彈出是否删除訊息
                for (int i = 0; i < this.dg.Items.Count; i++)
                {
                    this.dg.Items[i].Cells[0].Attributes.Add("onclick", "return confirm('確定授權該用戶為系統管理員？')");
                    this.dg.Items[i].Cells[1].Attributes.Add("onclick", "return confirm('確認刪除該紀錄？')");
                }
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

        //刪除資料
        protected void dg_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            msg.Text = "";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
            string userId = dg.DataKeys[e.Item.ItemIndex].ToString();
            name = userId;
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "delete from [user] where userId=@userId";
                cmd.Connection = conn;
                cmd.Parameters.Add("@userId", SqlDbType.NChar).Value = userId.Trim();
                cmd.ExecuteNonQuery();
                dataBind();
                dataFavorite();
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
 
        //使用者授權
        protected void dg_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "allowUser")
            {
                msg.Text = "";
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
                string userId = dg.DataKeys[e.Item.ItemIndex].ToString();
                conn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "update [user] set type ='admin' where userId=@userId";
                    cmd.Connection = conn;
                    cmd.Parameters.Add("@userId", SqlDbType.NChar).Value = userId.Trim();
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
        }

        //如果刪除使用者權限，同步需刪除對應之個人撥放清單資料
        public void dataFavorite()
        {
            msg.Text = "";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "delete from [favorite] where userId=@userId";
                cmd.Connection = conn;
                cmd.Parameters.Add("@userId", SqlDbType.NChar).Value = name;
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

        protected void btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("manage_page");
        }
    }
}