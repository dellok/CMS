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
using System.IO;
using System.Threading;
using LL.Common;

public partial class Cache_DoDetailHtml : System.Web.UI.Page
{
 
    public string detailUrl = "";

    string tb = "news";

    int havehtml = -1;
    int chd = -1;
    int PageSize = 100;
    int PageIndex = 1;
    int PageCount = 1;
    int RecordCount = 1;
    string sdate = "";
    string edate = "";
    string tableName = "phome_ecms_news";
    StringBuilder where = new StringBuilder(" 1=1");




    protected void Page_Load(object sender, EventArgs e)
    {

        GetNewsHtmlModel();

    }


    public void AddCache(string msg)
    {


        if (Cache["Error"] != null)
        {

            Cache["Error"] = Cache["Error"] + msg;
        }
        else
        {


            Cache["Error"] = msg;

        }

    }
    public string GetErrorMsg()
    {
        return Cache["Error"].ToString();
    }

    private void GetNewsHtmlModel()
    {

        StringBuilder msg = new StringBuilder();

        tb = Request["tablename"];
        tb = string.IsNullOrEmpty(tb) ? "news" : tb;
       

        tableName = tb == "news" ? "phome_ecms_news" : "phome_ecms_gsk";

        string isDoErrorUrl = Request["IsDoErrorUrl"];

        if (!string.IsNullOrEmpty(isDoErrorUrl))
        {
            DoErrorUrl();

           
        }
        else
        {




            havehtml = Project.Common.Format.DataConvertToInt(Request["havehtml"]);
            chd = Project.Common.Format.DataConvertToInt(Request["checked"]);
            PageSize = Project.Common.Format.DataConvertToInt(Request["PageSize"]);
            PageIndex = Project.Common.Format.DataConvertToInt(Request["PageIndex"]);
            PageCount = Project.Common.Format.DataConvertToInt(Request["PageCount"]);


            RecordCount = Project.Common.Format.DataConvertToInt(Request["RecordCount"]);
            sdate = Request["sdate"];
            edate = Request["edate"];


            PageIndex = PageIndex < 1 ? 1 : PageIndex;
            PageCount = PageCount < 1 ? 1 : PageCount;
            PageSize = PageSize < 1 ? 1 : PageSize;
            sdate = string.IsNullOrEmpty(sdate) ? DateTime.Now.ToShortDateString() : sdate;
            edate = string.IsNullOrEmpty(edate) ? DateTime.Now.AddDays(1).ToShortDateString() : edate;


            if (PageIndex <= 1)
            {
                Cache["Error"] = "";
            }
            if (PageIndex > PageCount)
            {
                string resultMsg = "执行完成!";


                Response.Write(resultMsg + "<br>");
                WriteErrorMsg();
                return;
            }


            //根据条件生成不同栏目静态页

            BuildStaticHtmlPage();

        }
    }


    private void WriteErrorMsg()
    {

        if (!string.IsNullOrEmpty(GetErrorMsg()))
        {
            string msg = "错误的请求:" + GetErrorMsg();

            Response.Write(msg);
            Response.Write(string.Format("重新生成错项:共{0}项",GetCache_ErrorUrlCount));
            Response.Write(string.Format("<script>location.href='DoDetailHtml.aspx?IsDoErrorUrl=true';</script>"));

        }

    }


    #region   Cache_ErrorUrl
    public string  Cache_ErrorUrl
    {
        get {

            if (Session["cerrorid"] != null)
            {
                return Session["cerrorid"].ToString();
            }
            else
            {

                return "";
            }
        
        }

        set {
                Session["cerrorid"] =Session["cerrorid"]+ "," + value;
        }
    }
    public void  Clear_CacheErrorUrl()
    {
        Session["cerrorid"] = "";
    }
    public int GetCache_ErrorUrlCount 
    {

        get {

            int i = 0;
            string strUrl = Project.Common.Util.SplitStartEndComma(Cache_ErrorUrl);

            if (!string.IsNullOrEmpty(strUrl))
            {
                string[] arrUrl = strUrl.Split(new char[] { ',' });

                i = arrUrl.Length;

            }
            return i;
        
        }
   
    }
    #endregion

  


    private void DoErrorUrl()
    {
        string strUrl = Project.Common.Util.SplitStartEndComma(Cache_ErrorUrl);

        Clear_CacheErrorUrl();
        if (!string.IsNullOrEmpty(strUrl))
        {
            string[] arrUrl = strUrl.Split(new char[]{','});

            foreach (var item in arrUrl)
            {
                CreateDetailHtml(item);
            }

        }

        if (GetCache_ErrorUrlCount > 0)
        {
            Response.Write(string.Format("重新生成错项:共{0}项", GetCache_ErrorUrlCount));
            Response.Write(string.Format("<script>location.href='DoDetailHtml.aspx?IsDoErrorUrl=true';</script>"));

        }
        else
        {
            Response.Write("生成完成!");
        }


     
       
    

    }

    
    
    private void BuildStaticHtmlPage()
    {

        StringBuilder msg = new StringBuilder();
        //是否是审核状态
        if (chd > 0)
        {
            where.AppendFormat("  and  checked={0}", chd);
        }
        else if (chd == 0)
        {
            where.AppendFormat(" and  ( checked<>1 or  checked is null )");
        }


        //是否已生成过html
        if (havehtml == 0)
        {
            where.AppendFormat("  and  (havehtml<>1 or havehtml is null)");
        }
      
        where.AppendFormat(" and newstime  between  '{0}' and  '{1}'", sdate, edate);
      



        //默认为生成新闻信息静态页，不包括标书下载


        string sqlSearchTableName = string.Format(" select id  from {0} where {1} ", tableName, where.ToString());
        IPager pager = new IPager();
        pager.TableName = sqlSearchTableName;
        pager.PageIndex = PageIndex;
        pager.PageSize = PageSize;

        DataSet ds = pager.GetResult();
        
        if (ds.Tables.Count == 2)
        {
           /// if (RecordCount < 1)
            //{
                RecordCount = Format.DataConvertToInt(ds.Tables[1].Rows[0][0]);
            //}
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                string id = item["id"].ToString();
               // detailUrl = string.Format("{0}/detail.aspx?id={2}&tableName={3}&CreateHtml=true", GetSubDomain(), Dir, id, "");
                //detailUrl = string.Format("{0}/{1}/detail.aspx?id={2}&tableName={3}&CreateHtml=true", LL.Common.Cache.ConfigManager.MainDomain, Dir, id, tableName);
                detailUrl = string.Format("{0}/template/{1}/detail.aspx?id={2}&{3}=true", SEO.MainDomain, tb, id, PubConstant.Key_CreateHtml);
              
                msg.Append(CreateDetailHtml(detailUrl) + "<br>");
                Thread.Sleep(100);
            }
        }
        PageCount = RecordCount / PageSize;
        PageCount = PageCount > 1 ? PageCount : 1;

        Response.Write(string.Format("正在生成:【{0} 频道】,共:【{3}】记录!【{1}】页,现在执行第【{2}】页静态化处理!", tb, PageCount, PageIndex + 1, RecordCount));
        Response.Write(string.Format("<script>location.href='DoDetailHtml.aspx?pageindex={0}&pagesize={1}&PageCount={2}&sdate={3}&edate={4}&dir={5}&RecordCount={6}&checked={7}&havehtml={8}';</script>", PageIndex + 1, PageSize, PageCount, sdate, edate, tb, RecordCount, chd, havehtml));
    }

    public string CreateDetailHtml(string url)
    {
        WebRequest req = WebRequest.Create(url);
    
        req.Timeout = 5000;
  
        try
        {

            WebResponse res = req.GetResponse();
            //System.IO.StreamReader sr = new System.IO.StreamReader(res.GetResponseStream(), System.Text.Encoding.GetEncoding("gb2312"));
           // string msg = sr.ReadToEnd();

            string msg = "";
            //sr.Close();
            res.Close();
            req.Abort();
            return msg;
        }
        catch (Exception ee)
        {
      
            req.Abort();

            Cache_ErrorUrl = url;
            string error = "生成错误:" + url + ",Error:" + ee.Message + "<br>";
            AddCache(url + ":" + error + "<br>");
            return error;
        }
    }

 

}







