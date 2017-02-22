using System;
using System.Collections.Generic;
using System.Linq;
using LL.Model.News;
using System.Text;
using LL.BLL.News;
using Project.Common;
using LL.Common.Cache;
using LL.Common;
using System.Web;
using System.Data;
namespace LL.BLL
{
    public class BLLNewsCommon
    {


        BLLphome_ecms_news bllNews = new BLLphome_ecms_news();



        /// <summary>
        /// 解析表字段titlefont  返回 样式表达形式
        /// 适用表中有 fitlefont 字段的表
        /// </summary>
        /// <param name="titlefont"></param>
        /// <returns></returns>
        public static string SetTitleFontStyle(string title, string titlefont)
        {

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(titlefont))
            {

                return title;
            }

            string fontStyle = "";
            string fontColor = "";

            StringBuilder titleCss = new StringBuilder();

            string[] arr = titlefont.Split(new char[] { ',' });

            //解析出 color,

            if (arr.Length == 2)
            {
                fontColor = arr[0];
                fontStyle = arr[1];

            }
            else if (arr.Length == 1)
            {
                fontStyle = arr[0];
            }

            //解析出font样式
            if (!string.IsNullOrEmpty(fontColor))
            {

                titleCss.AppendFormat("color:{0};", fontColor);
            }
            //解析出其它 
            if (!string.IsNullOrEmpty(fontStyle))
            {
                arr = fontStyle.Split(new char[] { '|' });
                foreach (string item in arr)
                {
                    switch (item)
                    {
                        case "i":
                            titleCss.AppendFormat("font-style: oblique;");
                            break;

                        case "b":
                            titleCss.AppendFormat("font-weight: bolder;");
                            break;

                        case "s":
                            titleCss.AppendFormat("text-decoration: line-through;");
                            break;
                        default:
                            break;
                    }

                }
            }

            string css = titleCss.ToString();
            if (!string.IsNullOrEmpty(css))
            {
                return string.Format("<span style=\"{0}\">{1}</span>", css, title);
            }
            else
            {
                return title;
            }


        }

        /// <summary>
        /// 设置新闻时间显示的格式
        /// </summary>
        /// <param name="p"></param>
        /// <param name="p_2"></param>
        /// <returns></returns>
        public static string FormatNewsTime(string newstime, string strformat)
        {

            if (string.IsNullOrEmpty(newstime))
            {

                newstime = DateTime.Now.ToShortDateString();
            }
            else
            {

                if (!string.IsNullOrEmpty(strformat))
                {


                    try
                    {

                        newstime = DateTime.Now.ToString(strformat);

                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }




            }

            return newstime;

        }


        /// <summary>
        /// 设置标题要前台的显示方式
        /// </summary>
        /// <param name="title"></param>
        /// <param name="len"></param>
        /// <param name="titlefont"></param>
        /// <returns></returns>
        public static string SetTitleHtml(string title, int len, string titlefont)
        {

            title = Util.SubStrNoPoint(title, len);


            return SetTitleFontStyle(title, titlefont);



        }


        /// <summary>
        /// 信息详细页最终url
        /// </summary>
        /// /// <param name="id"></param>
        /// <param name="classid"></param>
        /// <param name="newstime"></param>
        /// <param name="havehtml"></param>
        /// <param name="titleurl"></param>
        /// <returns></returns>
        public static string SetDetailPageUrl(object id, object classid, object newstime, object havehtml, object titleurl)
        {
       
          if (string.IsNullOrEmpty(titleurl.ToString()))
            {
                    titleurl = string.Format("/news/detail.aspx?id={0}",id);

            }

            return titleurl.ToString();
        }


        //public static string SetDetailPageUrl(object id, object classid, object newstime, object havehtml, object titleurl)
        //{
        //    BLLphome_enewsclass bllNewsClass = new BLLphome_enewsclass();
        //    string domain = ConfigManager.MainDomain;
        //    domain = domain.EndsWith("/") ? domain.TrimEnd(new char[] { '/' }) : domain;

        //    if (string.IsNullOrEmpty(titleurl.ToString()))
        //    {
        //        //是否已生成html
        //        if (Format.DataConvertToInt(havehtml) > 0)
        //        {


        //            //得到新闻页
        //            //得到分类所在目录 
        //            phome_enewsclass modelClass = bllNewsClass.GetModelByCache(Format.DataConvertToInt(classid));
        //            if (modelClass != null)
        //            {

        //                string path = modelClass.classpath;
        //                titleurl = string.Format("{0}/{1}/{2}.shtml", domain, path, id);

        //            }
        //            else
        //            {
        //                // string year = Format.DataConvertToDateTime(newstime).ToString("yyyy");
        //                //string md = Format.DataConvertToDateTime(newstime).ToString("MMdd");
        //                //titleurl = string.Format("{0}/{1}/{2}/{3}.shtml", ConfigManager.MainDomain, year, md, id);
        //                titleurl = "";
        //            }
        //        }
        //        else
        //        {

        //            titleurl = string.Format("{0}/template/news/detail.aspx?id={1}", domain, id);

        //        }

        //    }

        //    return titleurl.ToString();
        //}
        ///// <summary>
        /// 得到详细页物理地址
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="modelClass"></param>
        /// <returns></returns>
        public static string GetDetailPagePhyPath(string filename, phome_enewsclass modelClass)
        {

            string root = HttpContext.Current.Server.MapPath("~/");
            string path = modelClass.classpath.Replace("/", @"\");
            string filePath = string.Format("{0}/{1}", root, path);
            FileCommon.ExistsDir(filePath);
            return string.Format("{0}/{1}", filePath, filename);
        }


        /// <summary>
        /// 得到当前分类到目录路径的html 表示方式　
        /// 首页> classid> classid>
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        public static string GetCurClassToRootUrlPath(int classid)
        {

            return GetCurClassToRootUrlPath(classid, true);
        }
        public static string GetCurClassToRootUrlPath(int classid, bool isNeedShowIndex)
        {
            BLLphome_enewsclass bllNewsClass = new BLLphome_enewsclass();
            string NavSeperateSign = PubConstant.Key_Sign_NavSeperate; ;
            StringBuilder urlpath = new StringBuilder();
           
            List<phome_enewsclass> arrNode = bllNewsClass.GetClassNodePath(classid);
            int nodeCount = arrNode.Count();
            for (int i = 0; i < nodeCount; i++)
            {
                phome_enewsclass item = arrNode[i];

                if (item != null && item.classid > 0)
                {
                    int isHaveSonItem = bllNewsClass.ExistsSonNode(item.classid);
                    string url = string.Format("/news/list.aspx?{0}={1}", isHaveSonItem>0?"bclassid":"classid"  , item.classid);
                    if (i != nodeCount - 1)
                    {
                        urlpath.AppendFormat("<a href=\"{0}\">{1}</a>{2}", url, item.classname, NavSeperateSign);
                    }
                    else
                    {
                        urlpath.AppendFormat("<a href=\"{0}\">{1}</a>", url, item.classname, NavSeperateSign);
                    }
                }


            }

            return urlpath.ToString();
        }

        public static string GetListPageTitle(int classid)
        {
            BLLphome_enewsclass bllNewsClass = new BLLphome_enewsclass();
            StringBuilder urlpath = new StringBuilder();
            List<phome_enewsclass> arrNode = bllNewsClass.GetClassNodePath(classid);
            int nodeCount = arrNode.Count();

            for (int i = 0; i < nodeCount; i++)
            {
                phome_enewsclass item = arrNode[i];

                if (item != null && item.classid > 0)
                {
                   

                    urlpath.AppendFormat("{0}{1}", PubConstant.Key_Sign_Split, item.classname);
                 
                }


            }

            return urlpath.ToString();
        }
        /// <summary>
        /// 得到分类url
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public static string GetClassUrl(int cid)
        {
            string url = "";

            BLLphome_enewsclass bllNewsClass = new BLLphome_enewsclass();
            phome_enewsclass item = bllNewsClass.GetModelByCache(cid);

            if (item != null)
            {
                url = item.classpath;
                url = url.Replace(@"\", "/");
                if (url.Trim().IndexOf("/") != 0)
                {
                    url = string.Format("/{0}", url);
                }
                url = string.Format("{0}{1}", ConfigManager.MainDomain, url);
            }


            return url;
        }


        public static object GetClassName(object classid)
        {

            BLLphome_enewsclass bllclass = new BLLphome_enewsclass();

            phome_enewsclass model = bllclass.GetModelByCache(Format.DataConvertToInt(classid));

            if (model != null)
            {
                return model.classname;

            }
            else
            {

                return "";

            }

        }

        public static void SignHaveHtml(int ID, string tbName)
        {
            if (ID > 0 && !string.IsNullOrEmpty(tbName))
            {


                if (tbName.ToLower().Trim() == "gsk")
                {
                    BLLphome_ecms_gsk bllGsk = new BLLphome_ecms_gsk();
                    bllGsk.SignHaveHtml(ID, 1);
                }
                else
                {
                    BLLphome_ecms_news bllNews = new BLLphome_ecms_news();
                    bllNews.SignHaveHtml(ID, 1);
                }





            }

        }


        /// <summary>
        /// 得到详细表的路径(以表phome_ecms_ 开头表的信息)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="classid"></param>
        /// <returns></returns>
        public static string GetDetailUrlByIDAndClassID(int id, int classid)
        {

            BLLphome_ecms_news bllNews = new BLLphome_ecms_news();

            DataSet ds = bllNews.GetModelByIDAndClassID(id, classid);


            if (ds.Tables[0].Rows.Count > 0)
            {


                DataRow row = ds.Tables[0].Rows[0];

                return SetDetailPageUrl(row["id"], row["classid"], row["newstime"], row["havehtml"], row["titleurl"]);
            }
            else
            {

                return "";
            }


        }
    }
}
