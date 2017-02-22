using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LL.Common
{
   public  class TempVarField
   {


       #region
       public static string Regular_Loop = @"\[e:loop={(.*)}\](.*[^\[\/e:loop\]].*)";
       public static string Regular_Info = @"\[info\](.*)\[\/info\]";
       public static string Regular_News = @"\[news\](.*)\[\/news\]";
       /// <summary>
       /// 分页符
       /// </summary>
       public static string Regular_Pager = @"\[\!--empirenews.page--](.*)\[\/\!--empirenews.page--\]";


       public static string NewsSignS = "[news]";
       public static string NewsSignE = "[/news]";
       /// <summary>
       /// [news] 标签第一个参数默认值
       /// </summary>
       public static string NewsSignTempFirstParm_selfinfo = "selfinfo";

       #endregion

       /// <summary>
       ///[!--id--]
       /// 信息ID
       /// </summary>
       public static string ID = "[!--id--]";
       /// <summary>
       ///[!--titleurl--]
       /// 标题连接
       /// </summary>
       public static string TitleUrl = "[!--titleurl--]";

       /// <summary>
       ///[!--title--]
       /// 标题
       /// </summary>
       public static string Title = "[!--title--]";

       /// <summary>
       /// [!--class.name--]
       /// 分类名称
       /// </summary>
       public static string ClassName = "[!--class.name--]";
       /// <summary>
       /// [!--newstime--]
       /// 新闻添加时间 newstime
       /// </summary>
       public static string NewsTime = "[!--newstime--]";

       /// <summary>
       /// 作者:
       /// [!--writer--]
       /// </summary>
        public static string Write="[!--writer--]";
       /// <summary>
       /// 文章来源
        ///[!--befrom--] 
       /// </summary>
            public static string   Befrom ="[!--befrom--]";
         /// <summary>
            /// 收藏
            /// [!--fava.url--]
         /// 
         /// </summary>
            public static string    Favaurl="[!--fava.url--]";
       /// <summary>
            /// 主域名
            /// 
            /// news.url-
       /// </summary>
            public static string   Newsurl ="[!--news.url--]";
       /// <summary>
       /// 分类id
       /// </summary>
            public static string   Classid ="[!--classid--]";
         /// <summary>
         /// 副标题
         /// </summary>
            public static string   Ftitle ="[!--ftitle--]";
   /// <summary>
   /// 简介
            /// [!--smalltext--]
   /// </summary>
            public static string   SmallText ="[!--smalltext--]";
   
       /// <summary>
       /// 文章页
       /// </summary>
            public static string    PageUrl="[!--page.url--]";
       /// <summary>
       /// 
       /// </summary>
            public static string   OtherLink ="[!--other.link--]";
       /// <summary>
       /// 文章内容
            /// [!--newstext--]
       /// </summary>
            public static string   NewsText ="[!--newstext--]";


            public static string PrintUrl = "[!----]";
     /// <summary>
            ///收藏
            /// [!--info.vote--]
     /// </summary>
            public static string   InfoVote ="[!--info.vote--]";

       /// <summary>
       /// [!--empirenews.listtemp--]
       /// 帝国的一些标签
       /// </summary>
       public static string EmpireenewsListtemp = "[!--empirenews.listtemp--]";

       /// <summary>
       /// 分页html,标签
       /// !--show.page--]
       /// </summary>
       public static string ShowPage="[!--show.page--]";

       public static string PageTitle="[!--pagetitle--]";

       /// <summary>
       /// 导航
       /// [!--newsnav--]
       /// </summary>
       public static string NewsNav = "[!--newsnav--]";
       /// <summary>
       /// 分类页中的分页
       /// <!--list.var1-->
       /// </summary>
       public static string ListVar1 = "<!--list.var1-->";



       /// <summary>
       /// 顶一下
       /// </summary>
       public static string Diggtop = "[!--diggtop--]";





       /// <summary>
       /// 模板常量值
       /// 
       /// </summary>
       /// <returns></returns>
      public static  Dictionary<string, string> GetTempConstantValueDic()
       {
           Dictionary<string, string> dic = new Dictionary<string, string>();
          
           dic["[!--news.url--]"] = "http://www.lenglian.org.cn/";


          return dic;
      }



   }
}
