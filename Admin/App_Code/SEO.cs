using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LL.Common;
using LL.BLL.News;
using System.Web.Routing;
using System.Text;
using LL.Common.Cache;
using Project.Common;
using LL.Common.EnumClass;
using LL.Model.News;
using System.Net;

/// <summary>
///SEO 的摘要说明
/// </summary>
public class SEO
{
    Route route = new Route();
   public  static string MainDomain = ConfigManager.MainDomain;


   public SEO()
   {
       //
       //TODO: 在此处添加构造函数逻辑
       //
   }
   public static void InitRoute()
   {
       //Route.RouteRule();
   }
    #region 详细页名重命名
   

    /// <summary>
    /// 新闻信息页转发
    /// </summary>
    /// <param name="id"></param>
    /// <param name="classid"></param>
    /// <param name="newstime"></param>
    /// <param name="titleurl"></param>
    /// <returns></returns>
    public static string DetailPage_AdminView(object id, object classid)
    {
        BLLphome_enewsclass bllNewsClass = new BLLphome_enewsclass();

        phome_enewsclass modelClass = bllNewsClass.GetModelByCache(Format.DataConvertToInt(classid));

        string tbname = "news";
        //if (modelClass!=null)
        //{

        //    tbname = modelClass.tbname;
        //}
      //  return string.Format("{0}/{1}/detail.aspx?id={2}", SEO.MainDomain, tbname, id);

        return string.Format("{0}/articles/{1}?adminview=true", SEO.MainDomain, id);
      }
    public static string DetailPage(object id,object classid, object newstime,object havehtml, object titleurl)
    {

        return DetailPage_AdminView( id,  classid);
    //  return   LL.BLL.BLLNewsCommon.SetDetailPageUrl(id,classid,newstime,havehtml,titleurl);
    }


    #endregion


    #region  生成html

    public static string CreateADJs(string page)
    {
        return CreateADJs(page, "", "");
    }

    public static string CreateADJs(string adpage, string ADPagePosition, string seq)
    {
        string url = "/cache/ad.aspx";
        string webAdUrl = string.Format("{0}?{1}={2}&{3}={4}&{5}={6}", url, PubConstant.Key_ADPage, adpage, PubConstant.Key_ADPagePosition, ADPagePosition, PubConstant.Key_ADSeq, seq);

        return "";
        // return CreateHtml.HttpReqPage(webAdUrl);

    }

    public static string EncodingGb2312(string param)
    {
        return HttpUtility.UrlEncode(param, Encoding.GetEncoding("gb2312"));

    }






    public static string HttpReqPage(string url)
    {
        WebRequest req = null;
        WebResponse res = null;
        StringBuilder msg = new StringBuilder();
        try
        {
            req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Timeout = 5000;
            res = (HttpWebResponse)req.GetResponse();
            //StreamReader sr = new StreamReader(res.GetResponseStream());
            //string rmsg = HttpUtility.UrlDecode(sr.ReadToEnd(),Encoding.GetEncoding("gb2312"));
            // msg.Append(rmsg);
            msg.Append("刷新成功!");
            //sr.Close();
            res.Close();
            req.Abort();
        }
        catch (Exception ee)
        {
            if (res != null)
            {
                res.Close();
            }
            //BLL.News.BLLErrorMsg bllError = new BLL.News.BLLErrorMsg();
            msg.Append(string.Format("【刷新页面({0})：】-【{1}】\\n", url, ee.Message));
            // bllError.Add(msg.ToString());

        }
        return msg.ToString();

    }





    #region  列表中 刷新详细页生html
    public static string RefreshDetailPage_News(List<int> arrIDS)
    {



        return RefreshDetailPage("news", arrIDS);


    }

    public static string RefreshDetailPage_Gsk(List<int> arrIDS)
    {

        return RefreshDetailPage("gsk", arrIDS);
    }

    public static string RefreshDetailPage(string tbname, List<int> arrID)
    {

        return "错误，没有这个功能! 表名：" + tbname;
    }


    /// <summary>
    /// 要刷新的页面及参数
    /// </summary>
    public static string RefreshIndexPage()
    {
        StringBuilder msg = new StringBuilder();

        string url = string.Format("{0}/index.aspx?{1}=t", ConfigManager.MainDomain, PubConstant.Key_CreateHtml);

        return string.Format("[{0}]{1}", "首页", HttpReqPage(url));
    }
    #endregion

    #endregion






    public static string DominRoot { get; set; }
}