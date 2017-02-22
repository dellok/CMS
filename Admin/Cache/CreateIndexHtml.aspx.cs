using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using LL.BLL.News;
using Project.Common;
using LL.DAL;
using System.Net;
using LL.Common;


public partial class Cache_CreateIndexHtml : System.Web.UI.Page
{
    
    public StringBuilder iframeHtml = new StringBuilder();
    protected void Page_Load(object sender, EventArgs e)
    {

    
            GetDirs();
           
        
   
    }
   
    public void GetDirs()
    {

        string Dirs = Request["dirs"];



        if (string.IsNullOrEmpty(Dirs))
        {

            ReflashWebSiteIndex();
        }
        else
        {

            ReflashSubDomainIndex(Dirs);

        }

    }

    private void ReflashSubDomainIndex(string Dirs)
    {
        string[] arrDirs = Dirs.Split(new char[] { ',' });
        for (int i = 0; i < arrDirs.Length; i++)
        {
            //在进行分割
            string pidaoNameAndValue = arrDirs[i];
            if (!string.IsNullOrEmpty(pidaoNameAndValue))
            {
                string[] dir = pidaoNameAndValue.Split(new char[] { '-' });

                if (dir.Length == 2)
                {
                    string dirName = dir[0];
                    string dirVlaue = dir[1];
                    CreateIframe(dirName, dirVlaue);
                }

            }
        }
    }
    //频道页首页刷新
    private void ReflashPinDaoIndex(string Dirs)
    {

        string[] arrDirs = Dirs.Split(new char[] { ',' });

        for (int i = 0; i < arrDirs.Length; i++)
        {
            //在进行分割
            string pidaoNameAndValue = arrDirs[i];
            if (!string.IsNullOrEmpty(pidaoNameAndValue))
            {
                string[] dir = pidaoNameAndValue.Split(new char[] { '-' });

                if (dir.Length == 2)
                {
                    string dirName = dir[0];
                    string dirVlaue = dir[1];
                    CreateIframe(dirName, dirVlaue);
                }

            }
        }
    }
    //网站首页刷新
    private void ReflashWebSiteIndex()
    {
        string url = string.Format("{0}/index.aspx?{1}=true",SEO.MainDomain, PubConstant.Key_CreateHtml);
        iframeHtml.AppendFormat("<table width='98%'   align=center cellpadding=1 cellspacing=1 class=tb_grid>");
        iframeHtml.AppendFormat(" <tr class='tr_grid_title' style='height:25px;'><th class='th_grid_title textleft' style='font-style:' >刷新【{0}网站】首页</th></tr>", SEO.MainDomain);
        iframeHtml.AppendFormat("<tr class='tr_grid_row'><td  class='td_grid_col'>");
        iframeHtml.AppendFormat("<iframe frameborder=0 height=35  scrolling=no   src=\"{0}\"  width=\"100%\" ></iframe>", url);
        iframeHtml.AppendFormat("</td></tr></table>");
    }




  
    public void CreateIframe(string dirName, string dirVlaue)
    {
       
         string url = string.Format("{0}/{1}?{2}=true",SEO.MainDomain, dirVlaue, PubConstant.Key_CreateHtml);

         

         iframeHtml.AppendFormat("<table width='98%'   align=center cellpadding=1 cellspacing=1 class=tb_grid>");
         iframeHtml.AppendFormat(" <tr class='tr_grid_title' style='height:25px;'><th class='th_grid_title textleft' style='font-style:' >刷新【{0}】【{1}】首页</th></tr>", url, dirName);
         iframeHtml.AppendFormat("<tr class='tr_grid_row'><td  class='td_grid_col'>");
         iframeHtml.AppendFormat("<iframe frameborder=0 height=35  scrolling=no   src=\"{0}\"  width=\"100%\"></iframe>", url);
         iframeHtml.AppendFormat("</td></tr></table>");


    }


}


