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
public partial class Cache_CreateDetailHtml : System.Web.UI.Page
{
  public   StringBuilder iframeHtml = new StringBuilder();
    protected void Page_Load(object sender, EventArgs e)
    {

        GetDirs();
    }
    public void GetDirs()
    {
      
        string tbName = Request["tbName"];
        string urlCreateDetailHtml = "DoDetailHtml.aspx" + Request.Url.Query;


    


        string[] arrDirs = tbName.Split(new char[]{ ',' });

        for (int i = 0; i < arrDirs.Length; i++)
        {
            //在进行分割
            string  tbname = arrDirs[i];
            if (!string.IsNullOrEmpty(tbname))
            {
                string[] dir = tbname.Split(new char[] { '-' });
                if (dir.Length == 2)
                {
                    string dirName = dir[0];
                    string dirVlaue = dir[1];

                    CreateIframe(dirName, dirVlaue, string.Format("{0}&tablename={1}", urlCreateDetailHtml, dirVlaue));
                }

            }
        }


    }



    public void CreateIframe(string dirName, string dirVlaue, string urlCreateDetailHtml)
    {


       

        iframeHtml.AppendFormat("<table width='98%'   align=center cellpadding=1 cellspacing=1 class=tb_grid>");
        iframeHtml.AppendFormat(" <tr class='tr_grid_title' style='height:25px;'><th class='th_grid_title textleft' style='font-style:' >刷新【{0}】内容页</th></tr>", dirName);
        iframeHtml.AppendFormat("<tr class='tr_grid_row'><td  class='td_grid_col'>");
     
     iframeHtml.AppendFormat("<iframe frameborder=0 height=35  scrolling=no   src=\"{0}\"  width=\"100%\"></iframe>", urlCreateDetailHtml);
        iframeHtml.AppendFormat("</td></tr></table>");


    }


}


