using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Common;
using LL.Common;
using LL.Common.Cache;
using System.Text;
using LL.BLL.News;
public partial class Cache_ClassDir : System.Web.UI.Page
{

    BLLphome_enewsclass bllClass = new BLLphome_enewsclass();
   
    protected void Page_Load(object sender, EventArgs e)
    {



    }


    public void CreateClassDirListTempAndIndexFile(int type)
    {
        //在应用程序启动时运行的代码
        LL.BLL.News.BLLphome_enewsclass bllClass = new LL.BLL.News.BLLphome_enewsclass();
        List<LL.Model.News.phome_enewsclass> arrClass = bllClass.GetModelAllByCache();
        foreach (LL.Model.News.phome_enewsclass item in arrClass)
        {
            if (item.islist > 0)
            {
                string routeName = string.Format("route_{0}", item.classid);
                string dir = string.Format(@"{0}\{1}", ConfigManager.DirMainDomainRoot, item.classpath.Replace(@"/", @"\"));


                CreateFile(dir, item, type);


            }
        }
    }
    private void CreateFile(string dir, LL.Model.News.phome_enewsclass item, int type)
    {

        try
        {
            FileCommon.ExistsDirAndCreateDir(dir);
            Response.Write(string.Format("生成文件目录【{0}】成功!<br>", dir));
        }
        catch (Exception e)
        {

            Response.Write(string.Format("<b style='color=red'>生成文件目录错误:{0}<br>错误源:{1}</b><br>}", e.Message, e.Source));
        }



        if (type == 2)
        {
            try
            {
           
        

                string filePath = string.Format(@"{0}/index.aspx", dir);
                StringBuilder fileContent = new StringBuilder();
                fileContent.Append("<%       ");
                string tbName = item.tbname;
                tbName = string.IsNullOrEmpty(tbName) ? "news" : tbName;
                string query = string.Format("{1}={2}", Request.Url.Query, PubConstant.Key_ClassID, item.classid);
               // string rePageList = string.Format("\"/template/{0}/list.aspx?{1}\"", tbName, query);
               string rePageList = string.Format("\"/template/{0}/list.aspx?\"+PageCommon.ClassServerTransferParm({1},{2})", tbName, item.classid,bllClass.ExistsSonNode(item.classid));

                
                fileContent.AppendFormat("Server.Transfer({0},true)   ", rePageList);
                fileContent.Append("%>");
               // Request.Url.Query.Replac

                //Request.Url.Query.Replac
                //生成文件
                FileCommon.CreateFile(filePath, fileContent.ToString());
                Response.Write(string.Format("生成文件目录【{0}】中默认首页 成功!<br><hr/>", dir));
            }
            catch (Exception e)
            {

                Response.Write(string.Format("<b style='color=red'>生成文件错误:{0}<br>错误源:{1}</b><br><hr>", e.Message, e.Source));
            }

        }



    }


    protected void btnCreateDir_Click(object sender, EventArgs e)
    {
        CreateClassDirListTempAndIndexFile(1);
    }
    protected void btnCreateDirAndFile_Click(object sender, EventArgs e)
    {
        CreateClassDirListTempAndIndexFile(2);

    }
}