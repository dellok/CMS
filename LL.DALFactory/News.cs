using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LL.IDAL.News;
using LL.IDAL.Upload;
namespace LL.DALFactory
{
    public sealed partial class DataAccess
    {
        public static LL.IDAL.News.Iphome_ecms_gsk Createphome_ecms_gsk()
        {

            string ClassNamespace = AssemblyPath + ".News.DALphome_ecms_gsk";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (LL.IDAL.News.Iphome_ecms_gsk)objType;
        }


        /// <summary>
        /// 创建phome_ecms_news数据层接口。
        /// </summary>
        public static Iphome_ecms_news Createphome_ecms_news()
        {

            string ClassNamespace = AssemblyPath + ".News.DALphomeecmsnews";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Iphome_ecms_news)objType;
        }


        /// <summary>
        /// 创建phome_enewsclass数据层接口。
        /// </summary>
        public static LL.IDAL.News.Iphome_enewsclass Createphome_enewsclass()
        {

            string ClassNamespace = AssemblyPath + ".News.DALphome_enewsclass";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (LL.IDAL.News.Iphome_enewsclass)objType;
        }

        /// <summary>
        /// 新闻反馈
        /// </summary>
        /// <returns></returns>
        public static LL.IDAL.News.INewsFeedback CreateNewsFeedback()
        {
            string ClassNamespace = AssemblyPath + ".News.DALNewsFeedback";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (INewsFeedback)objType;
        }

      


    }
}
