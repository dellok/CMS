using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Common
{
    public class WebSiteMap
    {

        public WebSiteMap()
        { }

        public WebSiteMap(string url, string lastmod, string changefreq, string priority)
        {

            LOC = url;
            Lastmod = lastmod;
            ChangeFreq = changefreq;
            Priority = priority;
        
        }

        public WebSiteMap(string url, string lastmod)
        {

            LOC = url;
            Lastmod = lastmod;
       
        }

        public enum SearchEngineSpider
        {
            Google=0,
            Baidu=1,
            Yahoo=2

        }

        public enum SiteMapChangeFreq 
        {
            always,
            hourly,
            daily,
            weekly,
            monthly,
            yearly,
            never
        }
        public static string xmlTop = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
        public static string Tag_urlset = "urlset";
        public static string Tag_url = "url";
        public static string Tag_loc = "loc";
        public static string Tag_lastmod = "lastmod";
        public static string Tag_changefreq = "changefreq";
        public static string Tag_priority = "priority";
        public static string Tag_sitemap = "sitemap";
        public static string Tag_GoogleSiteMapIndex = "<sitemapindex xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\">";




        public string LOC { get; set; }
        public string URL { get; set; }
        public string Lastmod { get; set; }
        public string ChangeFreq { get; set; }
        public string Priority { get; set; }


        public static string CreateSiteMap(List<WebSiteMap> arrSiteMap ,SearchEngineSpider  spider)
        {
            StringBuilder xml = new StringBuilder();
            xml.AppendFormat("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            if (spider == SearchEngineSpider.Google)
            {
                xml.AppendFormat("<urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\">");
     
            }
            else
            {
                xml.Append("<urlset>");
            }
            
            foreach (var item in arrSiteMap)
            {
                xml.AppendFormat("<url>");

                xml.AppendFormat("<loc>{0}</loc>", item.LOC);
                xml.AppendFormat("<lastmod>{0}</lastmod>", item.Lastmod);

                if (!string.IsNullOrEmpty(item.ChangeFreq))
                {
                    xml.AppendFormat("<changefreq>{0}</changefreq>", item.ChangeFreq);
                }

                if (!string.IsNullOrEmpty(item.Priority))
                {
                    xml.AppendFormat("<priority>{0}</priority>", item.Priority);
                }
                xml.AppendFormat("</url>");
            }
            xml.AppendFormat("</urlset>");
            return xml.ToString();
        }

        public static string CreateSiteMapIndex(List<WebSiteMap> arrSiteMap)
        {
            StringBuilder xml = new StringBuilder();
            xml.AppendFormat("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            xml.AppendFormat("<sitemapindex xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\">");
            foreach (var item in arrSiteMap)
            {
                xml.AppendFormat("<sitemap>");
                xml.AppendFormat("<loc>{0}</loc>", item.LOC);
                xml.AppendFormat("<lastmod>{0}</lastmod>", item.Lastmod);
                xml.AppendFormat("</sitemap>");
            }
            xml.Append("</sitemapindex>");

            return xml.ToString();

        }


    }
}
