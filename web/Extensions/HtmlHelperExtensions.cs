using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using LL.Model.News;


namespace System.Web.Mvc.Html
{

    public static class MyHtmlExtensions
    {


        public static MvcHtmlString ActionLinkVideoDetails(this HtmlHelper html, string title, object id)
        {
            string path= string.Format("/{0}/{1}", "video", id);

            return ActionLink(html, path,"" ,title, null, true, null);
        }

        #region  ActionLinkListNews

        public static MvcHtmlString ActionLinkArticleList(this HtmlHelper html, string title, object classid)
        {
            return ActionLinkArticleList(html, title, classid, null);
        }

        public static MvcHtmlString ActionLinkArticleList(this HtmlHelper html, string title, object classid, object  htmlAttr)
        {
            string path =string.Format("{0}-{1}", title.Trim() ,classid); //GetActionArticleList();
            return ActionLink(html, path, "",title,null, true, AnonymousObjectToHtmlAttributes(htmlAttr));
        }

       
        #endregion


        #region  ActionLinkArticleDetails
        /// <summary>
        /// 适用新闻图片，新闻简介
        /// </summary>
        /// <param name="html"></param>
        /// <param name="title"></param>
        /// <param name="newsModel"></param>
        /// <returns></returns>
        public static MvcHtmlString ActionLinkArticleDetails(this HtmlHelper html, phome_ecms_news newsModel)
        {
            return ActionLinkArticleDetails(html, newsModel, null);
        }
        /// <summary>
        /// 新闻详细页连接，默认target=_blank
        /// </summary>
        /// <param name="html"></param>
        /// <param name="newsModel"></param>
        /// <returns></returns>
        public static MvcHtmlString ActionLinkArticleDetails(this HtmlHelper html, string displayTitle, phome_ecms_news newsModel)
        {
            return ActionLinkArticleDetails(html, displayTitle, newsModel, null);
        }
        public static MvcHtmlString ActionLinkArticleDetails(this HtmlHelper html, string displayTitle, phome_ecms_news newsModel, object htmlAttributes)
        {
            string actionName = GetActionArticleDetails(newsModel);

            return ActionLinkArticle(html, actionName,newsModel.titleurl ,displayTitle, new string[] { newsModel.ID.ToString() }, AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString ActionLinkArticleDetails(this HtmlHelper html, phome_ecms_news newsModel, object  htmlAttributes)
        {
            string actionName = GetActionArticleDetails(newsModel);

            return ActionLinkArticle(html, actionName,newsModel.titleurl, newsModel.title, new string[] { newsModel.ID.ToString() }, AnonymousObjectToHtmlAttributes(htmlAttributes));
        }
        /// <summary>
        /// 新闻解析地址
        ///默认 target=_black
        /// </summary>
        /// <param name="html"></param>
        /// <param name="actionName"></param>
        /// <param name="title"></param>
        /// <param name="urlParam"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString ActionLinkArticle(this HtmlHelper html, string actionName,string titleurl, string title, string[] urlParam, IDictionary<string, object> htmlAttributes)
        {
            return ActionLink(html, actionName,titleurl, title, urlParam, true, htmlAttributes);
        }
        #endregion
        /// <summary>
        /// 返回Action link过滤掉Controller路径
        /// </summary>
        /// <param name="html"></param>
        /// <param name="pathdir/urlpath"></param>
        /// <param name="title"></param>
        /// <param name="urlParam"></param>
        /// <returns></returns>
        private static MvcHtmlString ActionLink(this HtmlHelper html, string path,string titleurl, string title, string[] urlParam, bool isBlankTarget, IDictionary<string, object> htmlAttributes)
        {

          
    StringBuilder url = new StringBuilder();

    url.Append(titleurl);

    if (string.IsNullOrEmpty(url.ToString()))
    {
        
    
            char[] split = { '/' };
        
            url.AppendFormat("/{0}/", path.TrimStart(split).TrimEnd(split));

            if (urlParam!=null)
            {
                   url.AppendFormat("{0}", string.Join("-", urlParam));
            }

    }

            TagBuilder titleLink = new TagBuilder("a");
            titleLink.InnerHtml = title;
            titleLink.MergeAttribute("href", url.ToString());

            if (htmlAttributes != null)
            {
                if (!htmlAttributes.Keys.Contains("title")) titleLink.MergeAttribute("title", title);
                if (!htmlAttributes.Keys.Contains("target") && isBlankTarget) htmlAttributes.Add("target", "_blank");
            }
            else
            {
                if (isBlankTarget)
                {
                    titleLink.MergeAttribute("target", "_blank");
                }
            }
            titleLink.MergeAttributes(htmlAttributes);
            return MvcHtmlString.Create(titleLink.ToString());
        }
       
        /// <summary>
        /// 新闻详细页显示目录
        /// </summary>
        /// <param name="newsModel"></param>
        /// <returns></returns>
    

    
       

        public  static string GetActionArticleDetails(phome_ecms_news newsModel)
        {
            return "/articles/";
        }

        #region  解析匿名类成字典类

        #region   得到 新闻详细页面 地址

        public static string GetUrlArticleDetalis(string titleurl, int  titleid)
        {

            return  string.IsNullOrEmpty(titleurl) ? string.Format("/articles/{0}", titleid) :titleurl;
       
        }

        #endregion


        public static IDictionary<string, object> AnonymousObjectToHtmlAttributes(object v)
        {

            var _dictionary = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(v))
            {
                object obj2 = descriptor.GetValue(v);
                _dictionary.Add(descriptor.Name, obj2);
            }

            return _dictionary;
        }
        #endregion
    }
}

