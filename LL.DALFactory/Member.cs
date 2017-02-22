using System;
using System.Reflection;
using System.Configuration;
using LL.IDAL.Member;
namespace LL.DALFactory
{

    public sealed partial class DataAccess
    {


        public static Iphome_enewsmember Createphome_enewsmember()
        {

            string ClassNamespace = AssemblyPath + ".Member.DALphome_enewsmember";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Iphome_enewsmember)objType;
        }

        public static Iphome_enewsmemberadd Createphome_enewsmemberadd()
        {

            string ClassNamespace = AssemblyPath + ".Member.DALphome_enewsmemberadd";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Iphome_enewsmemberadd)objType;
        }


        public static Iphome_enewsmembergbook Createphome_enewsmembergbook()
        {

            string ClassNamespace = AssemblyPath + ".Member.DALphome_enewsmembergbook";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Iphome_enewsmembergbook)objType;
        }

        /// <summary>
        /// 会角色
        /// </summary>
        /// <returns></returns>
        public static Iphome_enewsmembergroup CreateMemberGroup()
        {

            string ClassNamespace = AssemblyPath + ".Member.DALphome_enewsmembergroup";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Iphome_enewsmembergroup)objType;
        }

        /// <summary>
        /// 站内信
        /// </summary>
        /// <returns></returns>
        public static IPhomeENewsQMsg CreateMemberMsg()
        {

            string ClassNamespace = AssemblyPath + ".Member.DALPhomeENewsQMsg";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IPhomeENewsQMsg)objType;
        }



        /// <summary>
        /// 好友分类
        /// </summary>
        public static Iphome_enewshyclass Createphome_enewshyclass()
        {

            string ClassNamespace = AssemblyPath + ".Member.DALphome_enewshyclass";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Iphome_enewshyclass)objType;
        }


        /// <summary>
        /// 我的好友
        /// </summary>
        public static Iphome_enewshy Createphome_enewshy()
        {

            string ClassNamespace = AssemblyPath + ".Member.DALphome_enewshy";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Iphome_enewshy)objType;
        }




        /// <summary>
        /// 会员空间样式
        /// </summary>
        public static Iphome_enewsspacestyle Createphome_enewsspacestyle()
        {

            string ClassNamespace = AssemblyPath + ".Member.DALphome_enewsspacestyle";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Iphome_enewsspacestyle)objType;
        }




        /// <summary>
        /// 反溃
        /// </summary>
        public static Iphome_enewsmemberfeedback Createphome_enewsmemberfeedback()
        {

            string ClassNamespace = AssemblyPath + ".Member.DALphome_enewsmemberfeedback";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Iphome_enewsmemberfeedback)objType;
        }


        /// <summary>
        /// 留言分类
        /// </summary>
        public static Iphome_enewsgbookclass Createphome_enewsgbookclass()
        {

            string ClassNamespace = AssemblyPath + ".Member.DALphome_enewsgbookclass";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Iphome_enewsgbookclass)objType;
        }


        /// <summary>
        /// 留言
        /// </summary>
        public static Iphome_enewsgbook Createphome_enewsgbook()
        {

            string ClassNamespace = AssemblyPath + ".Member.DALphome_enewsgbook";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Iphome_enewsgbook)objType;
        }


        /// <summary>
        /// 收藏夹分类
        /// </summary>
        public static LL.IDAL.Member.Iphome_enewsfavaclass Createphome_enewsfavaclass()
        {

            string ClassNamespace = AssemblyPath + ".Member.DALphome_enewsfavaclass";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (LL.IDAL.Member.Iphome_enewsfavaclass)objType;
        }

        /// <summary>
        ///收藏夹
        /// </summary>
        public static LL.IDAL.Member.Iphome_enewsfava Createphome_enewsfava()
        {

            string ClassNamespace = AssemblyPath + ".Member.DALphome_enewsfava";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (LL.IDAL.Member.Iphome_enewsfava)objType;
        }

        /// <summary>
        /// 友情连接
        /// </summary>
        /// <returns></returns>
        public static LL.IDAL.Member.IMemberWebSiteFriendLink  CreateMemberWebSiteFriendLink()
        {

            string ClassNamespace = AssemblyPath + ".Member.DALMemberWebSiteFriendLink";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (LL.IDAL.Member.IMemberWebSiteFriendLink)objType;
        }
    }
}
