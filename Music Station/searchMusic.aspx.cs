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
    public partial class searchMusic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] == null)
                Response.Redirect("login");
            else
                meg.Text = "用戶 " + Session["userId"].ToString() + " ，你好";
        }

        //依據關鍵字進行資料搜尋
        public void dataBind()
        {
            string name = txt.Text.Trim().ToString();
            string type = RadioButtonList1.SelectedValue;
            //string name = Request.QueryString["name"].Trim();
            //string type = Request.QueryString["type"].Trim();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
            try
            {
                msg.Text = "";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                if (type.Equals("music"))
                {
                    cmd.CommandText = "SELECT * FROM [music] WHERE(musicName like '%'+@musicName+'%') ORDER BY count DESC";
                    cmd.Parameters.Add("@musicName", SqlDbType.NChar).Value = name;
                }
                else if (type.Equals("singer"))
                {
                    cmd.CommandText = "SELECT * FROM [music] WHERE(singer like '%'+@singer+'%') ORDER BY count DESC";
                    cmd.Parameters.Add("@singer", SqlDbType.NChar).Value = name;
                }
                else
                {
                    cmd.CommandText = "SELECT * FROM [music] WHERE(album like '%'+@album+'%') ORDER BY count DESC";
                    cmd.Parameters.Add("@album", SqlDbType.NChar).Value = name;
                }

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                SqlCommandBuilder sqlcb = new SqlCommandBuilder(da);
                DataSet ds = new DataSet();
                da.Fill(ds, "music");
                if (ds.Tables["music"].Rows.Count > 0)
                {
                    dg.DataSource = ds;
                    dg.DataBind();
                }
                else
                {
                    dg.Visible = false;
                    msg.Text = "沒有找到相關的資料！";
                }
                for (int i = 0; i < this.dg.Items.Count; i++)
                {
                    this.dg.Items[i].Cells[0].Attributes.Add("onclick", "return confirm('確定收藏此音樂？')");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message.ToString() + "')</script>");

            }
            finally
            {
                conn.Close();
                
            }
        }
        protected void dg_SortCommand(object source, DataGridSortCommandEventArgs e)
        {

            sort(e.SortExpression);
        }

        protected void search_btn_Click(object sender, EventArgs e)
        {
            dg.Visible = true;
            dataBind();
            txt.Text = "";

            //if (!txt.Text.ToString().Equals(""))
            //{
            //  Response.Redirect("searchMusic? name=" + txt.Text.ToString() + "&type=" + RadioButtonList2.SelectedValue);
            //}
            //else
            //  msg.Text = "";

        }
        public void sort(string sortField)
        {
            msg.Text = "";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
            try
            {
                string sqlselect = "SELECT * FROM [music]";
                SqlCommand cmd = new SqlCommand(sqlselect, conn);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "music");
                DataView source = new DataView(ds.Tables["music"]);
                source.Sort = sortField + " DESC";

                dg.DataSource = source;
                dg.DataBind();
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
        protected void dg_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {

        }

        protected void dg_CreateCommand(object source, DataGridCommandEventArgs e)
        {
        }
        protected void dg_GetCommand(object source, DataGridSortCommandEventArgs e)
        {

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default");
        }

        /*protected void manage_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
            try
            {
                string Id = Session["userId"].ToString();
                string sql = "select type from [user] where userId='" + Id + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                string type="";
                if (dr.Read())
                {
                    type = dr.GetString(0).Trim();

                    if (type == "admin")
                        Response.Redirect("manage_page");
                    else
                        msg.Text = "目前無權限進入，請與管理者聯繫!!!";
                }
                cmd.Connection.Close();
            }
            finally
            {
                conn.Close();
            }
        }*/
    }
}