using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Web.Routing;
using LL.Common;
using LL.Common.EnumClass;
using Project.Common;
using LL.BLL.News;
using LL.Model.News;
using LL.Model.Temp;
using LL.BLL.Temp;
/// <summary>
///LLRoute 的摘要说明
/// </summary>
public class BLLRoute
{



    public BLLRoute()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        // 
    }


    /// <summary>
    /// 转发规则
    /// </summary>
    /// 

    public static string UrlFormatPrefix_LeiBie = "leibie-";

    public static string UrlFormatPrefix_ClassID = "c";

    public static string UrlFormatPrefix_BClassID = "b";
    public static string UrlFormatPrefix_ZhaoBiaoList = "z-";
    public static string UrlFormatPrefix_List = "list-";




    private static string RouteSubDomainValueParm_ClassID = UrlFormatPrefix_ClassID + "{" + PubConstant.Key_ClassID + "}.aspx";
    private static string RouteSubDomainValueParm_BClassID = UrlFormatPrefix_BClassID + "{" + PubConstant.Key_BClassID + "}.aspx";
    private static string RouteSubDomainValueParm_LeiBie = UrlFormatPrefix_LeiBie + "{leibie}.aspx";


    private static string RouteSubDomainPageParam_List = UrlFormatPrefix_List + "{" + PubConstant.Key_Route_ListParams + "}.aspx";

  
    

    private static string RouteValueParm_ClassID = "{page}/" + UrlFormatPrefix_ClassID + "{" + PubConstant.Key_ClassID + "}.aspx";
    private static string RouteValueParm_BClassID = "{page}/" + UrlFormatPrefix_BClassID + "{" + PubConstant.Key_BClassID + "}.aspx";
    private static string RouteValueParm_LeiBie = "{page}/" + UrlFormatPrefix_LeiBie + "{leibie}.aspx";

    private static string RoutePageParam_List = "{page}/" + UrlFormatPrefix_List + "{" + PubConstant.Key_Route_ListParams + "}.aspx";
    private static string RoutePageParam_List_ZhaoBiao = "{page}/" + UrlFormatPrefix_ZhaoBiaoList + "{" + PubConstant.Key_Route_ListParams + "}.aspx";





    public static void InitRoute()
    {

        RouteNewsList();
        RouteGskAddress();
       

    }


    public static  void  RouteVipSite()
    {

       // string route = ;
   
    
    
    }

    #region  域名地址常量
    public static string MainDomain = LL.Common.Cache.ConfigManager.MainDomain;
 



    //根据Dir得到域名
    public static string GetSubMainByDir(string dir)
    {
        dir = dir.Trim().ToLower();

        return dir;
    }









    #endregion

    #region  routeRewritePath
    public static void RouteA(string url)
    {
        //总规则

        string detailPageParmRule = @"^\d{1,10}-\d{1,10}\.html$";
        string listPageParmRule = @"^\d{1,10}\.html$";
        //转发前缀
        string reUrl = url.Substring(0, url.LastIndexOf('/') + 1);
        //结页面
        string page = url.Substring(reUrl.Length);

        string classid = "";
        string id = "";

        ReListPage(classid, id, reUrl, page, listPageParmRule);
        ReDetailPage(classid, id, reUrl, page, detailPageParmRule);
    }

    /// <summary>
    /// 转发详细页
    /// </summary>
    /// <param name="classid"></param>
    /// <param name="id"></param>
    /// <param name="reUrl"></param>
    /// <param name="page"></param>
    /// <param name="detailPageParmRule"></param>
    private static void ReDetailPage(string classid, string id, string reUrl, string page, string detailPageParmRule)
    {
        Regex reg = new Regex(detailPageParmRule);
        Match m = reg.Match(page);
        if (m.Success)
        {
            page = m.Groups[0].Value.Replace(@".html", "");
            string[] arrV = page.Split(new char[] { '-' });
            classid = arrV[0];
            id = arrV[1];
            reUrl = string.Format("{0}detail.aspx?classid={1}&id={1}", reUrl, classid, id);
            HttpContext.Current.RewritePath(reUrl);
        }
    }

    /// <summary>
    /// 转发列表页
    /// </summary>
    /// <param name="classid"></param>
    /// <param name="id"></param>
    /// <param name="reUrl"></param>
    /// <param name="page"></param>
    /// <param name="listPageParmRule"></param>
    private static void ReListPage(string classid, string id, string reUrl, string page, string listPageParmRule)
    {
        //列表页转发
        Regex reg = new Regex(listPageParmRule);
        Match m = reg.Match(listPageParmRule);
        if (m.Success)
        {
            classid = m.Groups[0].Value.Replace(@".html", "");
            reUrl = string.Format("{0}list.aspx?classid={1}&id={0}", reUrl, classid);
            HttpContext.Current.RewritePath(reUrl);
        }

    }

    #endregion
    #region 详细页url格式
    public static string UrlInfoDetail(object defaultUrl, object reTitleurl)
    {
        if (!string.IsNullOrEmpty(reTitleurl.ToString()) && reTitleurl.ToString() != "0")
        {
            if (reTitleurl.ToString().Contains("http://www.LL.org.cn/e/space/"))
            {
                reTitleurl = reTitleurl.ToString().Replace("http://www.LL.org.cn/e/space/", "/VipWebSite/index.aspx");
            }
            return reTitleurl.ToString();
        }
        else
        {
            return defaultUrl.ToString();
        }
    }
    //详细页url
    public static string UrlDetailPage(PageDirectory dir, object id, object classid, object newstime, object titleUrl)
    {
        //目前先不用时间
        string defaultUrl = string.Format("/{0}/{1}.aspx", dir.ToString(), id);
        return UrlInfoDetail(defaultUrl, titleUrl);
    }


    #region  静态页路径
    public static string GetDetailPagePathName(DateTime newstime, object id)
    {
        return GetDetailPagePathName("",newstime,id);
    }
    public static string GetDetailPagePathName(string domain,DateTime newstime,object id)
    {
        string defaultUrl = string.Format("{0}/{1}.html", newstime.ToString("yyyy-MM-dd"), id);

        if (!string.IsNullOrEmpty(domain))
        {
            defaultUrl = string.Format("{0}/{1}", domain, defaultUrl);
        }
        return defaultUrl;
    }
    #endregion
    

    /// <summary>
    /// 在外围进行datetime转换
    /// </summary>
    /// <param name="domain">不能为空</param>
    /// <param name="dir"></param>
    /// <param name="id"></param>
    /// <param name="titleUrl"></param>
    /// <returns></returns>
    public static string UrlDomainDetailPage(string domain, DateTime newsitme, object id, object titleUrl)
    {
     string  defaultUrl=GetDetailPagePathName(domain,newsitme,id);
        return UrlInfoDetail(defaultUrl, titleUrl);

    }
    public static string UrlDetailPage(string domain, PageDirectory dir, object id, object classid, object newstime, object titleUrl)
    {
        string defaultUrl = string.Format("{0}/{1}/{2}", domain, dir.ToString(), GetDetailPagePathName(Format.DataConvertToDateTime(newstime),id));
        return UrlInfoDetail(defaultUrl, titleUrl);
    }

    /// <summary>
    ///返回 ID.aspx 不包括 时间路径 
    /// </summary>
    /// <param name="domain"></param>
    /// <param name="dri"></param>
    /// <param name="id"></param>
    /// <param name="titleUrl"></param>
    /// <returns></returns>
    public static string UrlDetailPage(string domain, PageDirectory dir, object id, object titleUrl)
    {
        string defaultUrl = string.Format("/{0}/{1}.aspx",dir, id);
        if (!string.IsNullOrEmpty(domain))
        {
            defaultUrl = string.Format("{0}{1}",domain, defaultUrl);
        }
        return UrlInfoDetail(defaultUrl, titleUrl);
    }
    public static string UrlDetailPage_ASPX(string domain, PageDirectory dir, object id, object titleUrl)
    {
        string defaultUrl = string.Format("/{0}/{1}.aspx", dir, id);
        if (!string.IsNullOrEmpty(domain))
        {
            defaultUrl = string.Format("{0}{1}", domain, defaultUrl);
        }
        return UrlInfoDetail(defaultUrl, titleUrl);
    }
    public static string UrlDetailPage(object id, object classid, object newstime, object titleUrl)
    {
        //目前先不用时间
        string defaultUrl = GetDetailPagePathName(Format.DataConvertToDateTime(newstime), id);
        return UrlInfoDetail(defaultUrl, titleUrl);
    }
    #endregion
    #region 列表页静态化路径
    public static string UrlListPageByClassID(PageDirectory dir, object classid)
    {


        string url = string.Format("/{0}/{1}", dir.ToString(), UrlListPageByClassID(classid));

        return url;
    }

    public static string UrlListPageByClassID(object classid)
    {

        string url = string.Format("{0}{1}.aspx", UrlFormatPrefix_ClassID, classid);
        return url;

    }

    public static string UrlListPageByBClassID(object classid)
    {
        string url = string.Format("{0}{1}.aspx", UrlFormatPrefix_BClassID, classid);
        return url;
    }
    #endregion
    /// <summary>
    /// 按类别查询
    /// </summary>
    /// <param name="leibieValue"></param>
    /// <returns></returns>
    public static string UrlListPageByLeiBie(object leibieValue)
    {
        string url = string.Format("{0}{1}.aspx", UrlFormatPrefix_LeiBie, leibieValue);
        return url;
    }
    public static string ListPageByZhaoBiao(object parm)
    {
        string url = string.Format("{0}{1}.aspx", UrlFormatPrefix_ZhaoBiaoList, parm);
        return url;
    }
    public static string ListPageByParms(object parm)
    {
        string url = string.Format("{0}{1}.aspx", UrlFormatPrefix_List, parm);
        return url;
    }




   


    public static string UrlDomainListPageByBClassID(string subDomain, object classid)
    {
        return string.Format("{0}/{1}", subDomain, UrlListPageByBClassID(classid));
    }



    public static string UrlDomainListPageByParms(string SubDoamin, object param)
    {

        return string.Format("{0}/{1}", SubDoamin, ListPageByParms(param));
    }

    public static string UrlDomainListPageByClassID(string subDomain, object classid)
    {
        return string.Format("{0}/{1}", subDomain, UrlListPageByClassID(classid));
    }

    public static string UrlDomainListPageByLeiBie(string subDomain, string param)
    {
        return string.Format("{0}/{1}", subDomain, UrlListPageByLeiBie(param));
    }




    private const string  RouteListParmsPage="{" + PubConstant.Key_Route_ListParams + "}.aspx";

   public const  string Url_List_Gsk = "~/template/gsk/list.aspx";
   public const string Url_Detail_Gsk = "~/template/gsk/detail.aspx";
   public const string Url_List_News = "~/template/news/list.aspx";
   public const string Url_Detail_News = "~/template/news/detail.aspx";

   public static string RouteUrl_GskAddress(string address)
   {
       return string.Format("gsk-address_{0}.aspx",address);
   }

    public static void RouteGskAddress()
    {
        RouteTable.Routes.MapPageRoute("gsk-addresss", "{page}/gsk-"+RouteListParmsPage,Url_List_Gsk);

        
        //RouteTable.Routes.MapPageRoute("subdomain-list-bclassid", RouteSubDomainValueParm_BClassID, RePageSubDomainList);
        //RouteTable.Routes.MapPageRoute("subdomain-list-param", RouteSubDomainPageParam_List, RePageSubDomainList);
        //RouteTable.Routes.MapPageRoute("subdomain-list-leibie", RouteSubDomainValueParm_LeiBie, RePageSubDomainList);

        //RouteTable.Routes.MapPageRoute("list-classid", RouteValueParm_ClassID, RePageList);
        //RouteTable.Routes.MapPageRoute("list-bclassid", RouteValueParm_BClassID, RePageList);
        //RouteTable.Routes.MapPageRoute("list-leibie", RouteValueParm_LeiBie, RePageList);
        //RouteTable.Routes.MapPageRoute("list-listparms", RoutePageParam_List, RePageList);

        //RouteTable.Routes.MapPageRoute("detail", RouteValueParm_DetailPage, RePageDetail, false, new RouteValueDictionary { }, new RouteValueDictionary { { "id", @"\d{1,10}" } });
        //RouteTable.Routes.MapPageRoute("detail2", RouteValueParm_DetailPage2, RePageDetail, false, new RouteValueDictionary { }, new RouteValueDictionary { { "id", @"\d{1,10}" } });


        //RouteTable.Routes.MapPageRoute("searchpage", RoutePageParam_List_ZhaoBiao, RePageList_ZhaoBiao);
    }
    public static string SubDomain_News { get; set; }

    public static string SubDomain_Gsk { get; set; }

 

    public static void RouteNewsList()
    {

        BLLphome_enewsclass bllClass = new BLLphome_enewsclass();
        List<phome_enewsclass> arrClass = bllClass.GetModelAllByCache();
        BLLTempItem bllTemp = new BLLTempItem();
        foreach (phome_enewsclass item in arrClass)
        {
                   if (item.islist>0)
                {
                //    string routeName = string.Format("route_{0}", item.classid);
                //    string routePath = string.Format("{1}page{2}/{0}", item.classpath.Replace(@"\", @"/"),"{","}");
                //    string tbName = item.tbname;
                //    tbName = string.IsNullOrEmpty(tbName) ? "news" : tbName;
                //    string rePageList = string.Format("~/{1}page{2}/template/{0}/list.aspx", tbName,"{","}");
                //    RouteTable.Routes.MapPageRoute(routeName, routePath, rePageList);
                }

            }


    

        

    }


}