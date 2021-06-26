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
using System.Text;

namespace Music_Station
{
    
    public partial class musicAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            msg.Text = "";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
            string filename = upload.PostedFile.FileName.ToString();
            int n = filename.LastIndexOf("\\");
            filename = filename.Substring(n + 1);
            string path = new DirectoryInfo(Server.MapPath("")).FullName.ToString() + @"\file\";
            path = path.Replace('\\', '/');
            FileInfo fi = new FileInfo(path + filename);                
            string musicname = filename;
            int i = 1;
            while (fi.Exists)
            {
                musicname = i.ToString() + "_" + filename;
                fi = new FileInfo(path + musicname);
                i++;
            }
            try
            {
                upload.SaveAs(path + musicname);
                conn.Open();
                SqlTransaction myTrans = conn.BeginTransaction();
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Transaction = myTrans;
                    insert_music(conn, musicname, cmd);
                    
                    // 判別資料資料表是否存在相同資料，如果不存在就新增資料
                    if (!isExisted("album", "album", conn, cmd))
                    {
                        insert_album(conn, cmd);
                    }
                    if (!isExisted("singer", "singer", conn, cmd))
                    {
                        insert_singer(conn, cmd);
                    }
                    myTrans.Commit();
                    msg.Text = "音樂添加成功！";
                    singer.Text = "";
                    album.Text = "";
                }
                catch (Exception ee)
                {
                    msg.Text = ee.Message.ToString();
                    myTrans.Rollback();
                    File.Delete(path + musicname);
                }
            }
            catch (Exception ee)
            {
                msg.Text = ee.Message.ToString();
                //msg.Text = "錯誤:";
            }
            finally
            {
                conn.Close();
            }
        }

        //判定資料庫是否存在相關名稱
        protected Boolean isExisted(string keyword, string table, SqlConnection con, SqlCommand cmd)
        {
            cmd.CommandText = "select * from [" + table + "] where " + keyword + "=@" + keyword;
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();
            Boolean check = dr.Read();
            dr.Close();
            return check;
        }

        //新增資料到音樂資料表
        protected void insert_music(SqlConnection con, string musicname, SqlCommand cmd)
        {
            cmd.CommandText = "insert into [music] values(@id,@musicName,@singer,@album,@type,@visitCount,@downLoadCount,@count)";
            cmd.Connection = con;
            cmd.Parameters.Add("@id", SqlDbType.NChar).Value = GetRndNumber(15);
            cmd.Parameters.Add("@musicName", SqlDbType.NChar).Value = musicname;
            cmd.Parameters.Add("@singer", SqlDbType.NChar).Value = singer.Text.Trim();
            cmd.Parameters.Add("@album", SqlDbType.NChar).Value = album.Text.Trim();
            cmd.Parameters.Add("@type", SqlDbType.NChar).Value = typelist.SelectedValue.ToString().Trim();
            cmd.Parameters.Add("@visitCount", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@downLoadCount", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@count", SqlDbType.Int).Value = 0;
            cmd.ExecuteNonQuery();
        }

        //產生亂數ID
        public string GetRndNumber(int Pos)
        {
            Random rnd = new Random(DateTime.Now.TimeOfDay.Milliseconds);
            StringBuilder str = new StringBuilder(Pos);
            for (int i = 0; i < Pos; i++)
            {
                int n = rnd.Next(10);
                str.Append(n.ToString());
            }
            return str.ToString();
        }

        //新增資料到歌手資料表
        protected void insert_singer(SqlConnection con, SqlCommand cmd)
        {
            cmd.CommandText = "insert into [singer] values(@singerId,@singer,@sex,@count)";
            cmd.Connection = con;
            cmd.Parameters.Add("@singerId", SqlDbType.NChar).Value = GetRndNumber(15);
            cmd.Parameters.Add("@sex", SqlDbType.NChar).Value = sex.SelectedValue.ToString().Trim();
            cmd.Parameters["@count"].Value = 0;
            cmd.ExecuteNonQuery();
        }

        //新增資料到專輯資料表
        protected void insert_album(SqlConnection con, SqlCommand cmd)
        {
            cmd.CommandText = "insert into [album] values(@albumId,@album,@singer,@count)";
            cmd.Connection = con;
            cmd.Parameters.Add("@albumId", SqlDbType.NChar).Value = GetRndNumber(15);
            cmd.Parameters["@count"].Value = 0;
            cmd.ExecuteNonQuery();
        }

        protected void exit_Click(object sender, EventArgs e)
        {
            Response.Redirect("manage_page");
        }
    }
}