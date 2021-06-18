using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Music_Station
{
    public partial class introductionAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void exit_Click(object sender, EventArgs e)
        {
            Response.Redirect("manage_page");
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            msg.Text = "";
            string filename = "";
            string filename1 = "";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString3"].ToString());
            filename = upload.PostedFile.FileName.ToString();

            filename1 = FileUpload.PostedFile.FileName.ToString();
            int n = filename.LastIndexOf("\\");
            int m = filename1.LastIndexOf("\\");
            filename = filename.Substring(n + 1);
            filename1 = filename1.Substring(m + 1);
            string path = new DirectoryInfo(Server.MapPath("")).FullName.ToString() + @"\introduction\";
            string path1 = new DirectoryInfo(Server.MapPath("")).FullName.ToString() + @"\PIC\";
            path = path.Replace('\\', '/');
            path1 = path1.Replace('\\', '/');
            FileInfo fi = new FileInfo(path + filename);
            FileInfo FI = new FileInfo(path1 + filename1);
            string introduction = filename;
            string PIC = filename1;
            int i = 1;
            int j = 1;
            while (fi.Exists)
            {
                introduction = i.ToString() + "_" + filename;
                fi = new FileInfo(path + introduction);
                i++;
            }
            while(FI.Exists)
            {
                PIC = j.ToString() + "_" + filename1;
                FI = new FileInfo(path1 + PIC);
            }
            try
            {
                if (filename == "" && filename1 != "")
                    FileUpload.SaveAs(path1 + PIC);
                else if (filename != "" && filename1 == "")
                    upload.SaveAs(path + introduction);
                else
                {
                    //msg.Text = filename;
                    upload.SaveAs(path + introduction);
                    FileUpload.SaveAs(path1 + PIC);
                }
                conn.Open();
                msg.Text = "專輯介紹添加成功！";
            }
            finally
            {
                conn.Close();
            }


        }
    }
}