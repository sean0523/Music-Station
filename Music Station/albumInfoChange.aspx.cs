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

namespace Music_Station
{
    public partial class albumInfoChange : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                db_album();
            }
        }

        //顯示專輯資訊
        public void db_album()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
            try
            {
                msg.Text = "";
                string sqlselect = "SELECT * FROM [album]";
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
                    msg.Text = "還沒有添加任何專輯！";
                    dg.Visible = false;
                }
                for (int i = 0; i < this.dg.Items.Count; i++)
                {
                    this.dg.Items[i].Cells[1].Attributes.Add("onclick", "return confirm('確定刪除該紀錄？')");
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

        //專輯資料刪除
        protected void dg_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
            string singer_name = dg.DataKeys[e.Item.ItemIndex].ToString();
            conn.Open();
            SqlTransaction myTrans = conn.BeginTransaction();
            try
            {
                //刪除專輯資料庫訊息
                SqlCommand cmd = new SqlCommand();
                cmd.Transaction = myTrans;
                cmd.CommandText = "delete  from [album] where album=@album";
                cmd.Connection = conn;
                cmd.Parameters.Add("@album", SqlDbType.NChar).Value = dg.DataKeys[e.Item.ItemIndex].ToString();
                cmd.ExecuteNonQuery();

                //刪除音樂資料庫訊息 & file 資料夾檔案
                cmd.CommandText = "select * from [music] where album = @album";
                string musicpath = "";
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    musicpath = new DirectoryInfo(Server.MapPath("")).FullName.ToString() + @"\file\" + dr.GetString(1).Trim().ToString();
                    File.Delete(musicpath);
                }
                dr.Close();
                cmd.CommandText = "delete from [music] where album =@album";
                cmd.ExecuteNonQuery();
                myTrans.Commit();
                db_album();
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

        //顯示全部專輯資料
        protected void dg_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dg.CurrentPageIndex = e.NewPageIndex;
            db_album();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("manage_page");
        }
    }
}