 using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Music_Station
{
    public partial class musicChange : System.Web.UI.Page
    {
        public Hashtable typeindex;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                db_music();
            }
            typeindex = new Hashtable();
            typeindex["中港台"] = 0;
            typeindex["日韓"] = 1;
            typeindex["歐美"] = 2;
            typeindex["鄉村"] = 3;
            typeindex["卡通"] = 4;
            typeindex["歌劇"] = 5;
            typeindex["其他"] = 6;
        }

        //判斷資料庫是否存在相同名稱
        protected Boolean isExisted(string keyword, string table, SqlConnection con, SqlCommand cmd)
        {
            cmd.CommandText = "select * from [" + table + "] where " + keyword + "=@" + keyword;
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();
            Boolean check = dr.Read();
            dr.Close();
            return check;
        }


        //載入所有音樂資料
        protected void dg_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dg.CurrentPageIndex = e.NewPageIndex;
            db_music();
        }

        public void db_music()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
            try
            {
                msg.Text = "";
                string sqlselect = "SELECT * FROM [music]";

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
                    msg.Text = "暫時還沒有添加歌曲！";
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
        public int gettype(string type)
        {
            if (typeindex[type] != null)
                return (int)typeindex[type];
            else
                return 0;
        }

        //刪除選定的音樂資料
        protected void dg_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
            string id = dg.DataKeys[e.Item.ItemIndex].ToString();
            conn.Open();
            SqlTransaction myTrans = conn.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Transaction = myTrans;
                cmd.CommandText = "select * from [music] where id=@id";
                cmd.Connection = conn;
                cmd.Parameters.Add("@id", SqlDbType.NChar).Value = dg.DataKeys[e.Item.ItemIndex].ToString();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string musicName = dr.GetString(1);
                    string album = dr.GetString(3);
                    string singer = dr.GetString(2);
                    dr.Close();
                    cmd.Parameters.Add("@singer", SqlDbType.NChar).Value = singer;
                    cmd.Parameters.Add("@album", SqlDbType.NChar).Value = album;
                    cmd.Parameters.Add("@musicName", SqlDbType.NChar).Value = musicName;
                    //刪除音樂
                    cmd.CommandText = "delete from [music] where id = @id";
                    cmd.ExecuteNonQuery();
                    //刪除收藏清單
                    cmd.CommandText = "delete from [favorite] where musicName = @musicName";
                    cmd.ExecuteNonQuery();
                    
                    if (!isExisted("singer", "music", conn, cmd))
                    {
                        cmd.CommandText = "delete from [singer] where singer=@singer";
                        cmd.ExecuteNonQuery();
                    }

                    if (!isExisted("album", "music", conn, cmd))
                    {
                        cmd.CommandText = "delete  from [album] where album=@album";
                        cmd.ExecuteNonQuery();
                    }

                    myTrans.Commit();
                    //刪除專案file資料夾的檔案
                    string path = new DirectoryInfo(Server.MapPath("")).FullName.ToString() + @"\file\" + musicName;
                    path = path.Replace('\\', '/');
                    File.Delete(path);
                }
                db_music();
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
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("manage_page.aspx");
        }
    }
}