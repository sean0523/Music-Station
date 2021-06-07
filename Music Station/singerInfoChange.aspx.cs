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
    public partial class singerInfoChange : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                db_singer();
            }
        }
        public void db_singer()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
            try
            {
                string sqlselect = "SELECT * FROM [singer]";

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
                    msg.Text = "暫時還沒有添加任何歌手！";
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
        protected void dg_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
            string singer_name = dg.DataKeys[e.Item.ItemIndex].ToString();
            conn.Open();
            SqlTransaction myTrans = conn.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Transaction = myTrans;
                cmd.CommandText = "delete from [singer] where singer=@singer";
                cmd.Connection = conn;
                cmd.Parameters.Add("@singer", SqlDbType.NChar).Value = dg.DataKeys[e.Item.ItemIndex].ToString();
                cmd.ExecuteNonQuery();

                cmd.CommandText = "select * from [music] where singer = @singer";
                string musicpath = "";
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    musicpath = new DirectoryInfo(Server.MapPath("")).FullName.ToString() + @"\file\" + dr.GetString(1).Trim().ToString();
                    File.Delete(musicpath);
                }
                dr.Close();

                cmd.CommandText = "delete from [music] where singer =@singer";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "delete from [album] where singer =@singer";
                cmd.ExecuteNonQuery();

                myTrans.Commit();

                db_singer();
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
        protected void dg_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dg.CurrentPageIndex = e.NewPageIndex;
            db_singer();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("manage_page");
        }
    }
}