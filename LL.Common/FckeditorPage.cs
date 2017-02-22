using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using LL.Common.Cache;
namespace LL.Common
{
    /// <summary>
    /// 分页显示类,只适用 .net 服务器
    /// </summary>
    public class FckeditorPage
    {

        public static int ArticlePage(int id, int currentPage, ref string content, ref string pageStr, bool IsCreateHtml)
        {
            return ArticlePage(id, currentPage, "", ref  content, ref  pageStr, IsCreateHtml);
        }

        public static int ArticlePage(int id, int currentPage, string urlQuery, ref string content, ref string pageStr, bool IsCreateHtml)
        {
            string r = "\\\"";
            int pageCount = 1;//页数


          
    

            string pattern = "<div style=\"page-break-after: always;\"><span style=\"display:none\">&nbsp;</span></div>";
            string pattern2 = "<div style=\"page-break-after: always; \"><span style=\"DISPLAY:none\">&nbsp;</span></div>";


            content = content.Replace(pattern, "[--page--]");
            content = content.Replace(pattern2, "[--page--]");

            content = content.Replace("[!--empirenews.page--]", "[--page--]");
            content = content.Replace("[/!--empirenews.page--]","");
            content = content.Replace(r, "");
            string[] tempContent = System.Text.RegularExpressions.Regex.Split(content, "\\u005B--page--]"); //取得分页符 "\\u005B"为"["的转义


            pageCount = tempContent.Length;

        //    if (!string.IsNullOrEmpty(urlQuery))
          //  {
               // urlQuery = urlQuery.IndexOf('&') < 0 ? "&" + urlQuery : urlQuery;
          //  }
              //有分页
            if (pageCount > 1)
            {
                //得到分页内容
                currentPage = currentPage - 1;
                content = tempContent[currentPage >= pageCount ? pageCount - 1 : currentPage>=0?currentPage:0];
                //内容页分页导航链接
                CreatePage(id, pageCount, currentPage, urlQuery, ref pageStr, IsCreateHtml);
            }
            return pageCount;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageCount"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageUrl"></param>
        /// <param name="pageStr">分页字符串</param>
        /// <returns></returns>
        private static void CreatePage(int id, int pageCount, int currentPage,string  urlQuery, ref string pageStr, bool IsCreateHtml)
        {
             //分页字符串

            var urlPrefix =System.Web.HttpContext.Current.Request.RawUrl;
   
            //有页码
            if (currentPage < 0)
            {
                currentPage = 0;
                var d = @"/";
                urlPrefix = urlPrefix.EndsWith(d) ? urlPrefix : urlPrefix + d;
            }
            else
            {
                urlPrefix = "";
            }


      
            if (currentPage > 0 && pageCount>2)
            {
                   //生成上一页文件名
                int preNum = currentPage - 1;
                var pageUrl = preNum > 1 ? string.Format("{0}{1}", urlPrefix, preNum) : "";

                pageStr += string.Format("<a class='prev' href =\"{0}\"><img  /></a>", pageUrl);
            }
           
            for (int i = 1; i < pageCount+1; i++)
            {
            
                    if (i == currentPage+1)
                    {
                        pageStr += string.Format("<span class='active'>【{0}】</span>", i);
                    }
                    else
                    {
                        pageStr += string.Format("<a class='num' href =\"{0}\">【{1}】</a>", string.Format("{0}{1}", urlPrefix, i), i);
                    }
             
               
                
            }

            //总页数大于3页时才显示
            if (currentPage>0 && pageCount>2)
            {

                int nextNum = currentPage+1;

                if (nextNum < pageCount)
                {


                    pageStr += string.Format("<a class='next' href =\"/{0}\" target=\"_self\"><img /></a>", string.Format("{0}{1}", urlPrefix, nextNum));
                }
            }
    
         
        }




        public string PageHtml(int PageIndex,int PageSize)
        {

            StringBuilder  pageHtml = new StringBuilder();


            return pageHtml.ToString();
        
        
        
        }
      
      
    }
}
