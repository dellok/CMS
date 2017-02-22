using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using Project.Common;
using System.Web.Caching;
using System.Reflection;
using System.IO;


namespace LL.Common.Cache
{


    public class CacheManager
    {
     
        //public static Dictionary<string, string> CacheMethods = new Dictionary<string, string>();

  


        //#region   会员角色



        ////新闻权限组
        //public static List<phome_enewsgroup> GetAllNewsGroupModel()
        //{
         

        //    SaveCacheMethods(PubConstant.Key_NewsGroup, "GetAllNewsGroupModel");


        //    if (GetCacheDataByKey(PubConstant.Key_NewsGroup) != null)
        //    {
        //        return (List<phome_enewsgroup>)GetCacheDataByKey(PubConstant.Key_NewsGroup);

        //    }
        //    else
        //    {
        //        BLL.Member.BLLPhomeENewsGroup bllGroup = new Member.BLLPhomeENewsGroup();
        //        List<phome_enewsgroup> arrGroup = bllGroup.GetAllList();
        //        //存入缓存
        //        SaveCache(PubConstant.Key_NewsGroup, arrGroup, "phome_enewsgroup");
        //        return arrGroup;
        //    }


        //}

        
        ///// <summary>
        ///// 会员角色
        ///// </summary>
        ///// <param name="gid"></param>
        ///// <returns></returns>
        //public static List<phome_enewsmembergroup> GetAllMemberGroup()
        //{
        //    SaveCacheMethods(PubConstant.Key_MemberGroup, "GetAllMemberGroup");


        //    if (GetCacheDataByKey(PubConstant.Key_MemberGroup) != null)
        //    {
        //        List<phome_enewsmembergroup> groups = (List<phome_enewsmembergroup>)GetCacheDataByKey(PubConstant.Key_MemberGroup);
        //        return groups;
        //    }
        //    else
        //    {
        //        BLL.Member.BLLPhomeENewsMemberGroup bllGroup = new Member.BLLPhomeENewsMemberGroup();
        //        List<phome_enewsmembergroup> arrGroup = bllGroup.GetAllList();
        //        //存入缓存
        //        SaveCache(PubConstant.Key_MemberGroup, arrGroup, "phome_enewsmembergroup");
        //        return arrGroup;
        //    }
        //}

        //#endregion

        ///// <summary>
        ///// 得到新闻分类全部数据
        ///// </summary>
        ///// <returns></returns>
        //public static List<CLB.LinqDB.phome_enewsclass> GetAllNewsClass()
        //{


        //    SaveCacheMethods(PubConstant.Key_NewsAllClass, "GetAllNewsClass");


        //    if (GetCacheDataByKey(PubConstant.Key_NewsAllClass) != null)
        //    {

        //        return (List<CLB.LinqDB.phome_enewsclass>)GetCacheDataByKey(PubConstant.Key_NewsAllClass);
        //    }
        //    else
        //    {
        //        Class.BLLNewsClass bll = new Class.BLLNewsClass();

        //        List<CLB.LinqDB.phome_enewsclass> classS = bll.GetListAll();

        //        SaveCache(PubConstant.Key_NewsAllClass, classS, "phome_enewsclass");
        //        return classS;

        //    }
        //}
       


        //#region admin人员集合,  权限角色


        ///// <summary>
        /////admin 角色集合
        ///// </summary>
        ///// <returns></returns>
        //public static List<AdminRole> GetAllAdminRole()
        //{

        //    SaveCacheMethods(PubConstant.Key_AdminRole, "GetAllAdminRole");


        //    if (GetCacheDataByKey(PubConstant.Key_AdminRole) != null)
        //    {
        //        return (List<AdminRole>)GetCacheDataByKey(PubConstant.Key_AdminRole);
        //    }
        //    else
        //    {
        //        Admin.BLLAdminRole bllRole = new Admin.BLLAdminRole();
        //        List<AdminRole> arrAdminRole = bllRole.GetAllModel();
        //        SaveCache(PubConstant.Key_AdminRole, arrAdminRole, "AdminRole");
        //        return arrAdminRole;
        //    }





        //}



        ///// <summary>
        /////admin 集合
        ///// </summary>
        ///// <returns></returns>
        //public static List<AdminUser> GetAllAdmin()
        //{
        //         SaveCacheMethods(PubConstant.Key_AdminList, "GetAllAdmin");
          

        //    if (GetCacheDataByKey(PubConstant.Key_AdminList) != null)
        //    {
        //        return (List<AdminUser>)GetCacheDataByKey(PubConstant.Key_AdminList);
        //    }
        //    else
        //    {
        //        Admin.BLLAdminUser bllAUser = new Admin.BLLAdminUser();
        //        List<AdminUser> arrAdmin = bllAUser.GetModelList();
        //        SaveCache(PubConstant.Key_AdminList, arrAdmin, "AdminUser");
        //        return arrAdmin;
        //    }
        //}

        ///// <summary>
        ///// 所有权限功能
        ///// </summary>
        ///// <returns></returns>
        //public static List<PopedomFun> GetAllPopedomFun()
        //{

        //    SaveCacheMethods(PubConstant.Key_PopedomFun, "GetAllPopedomFun");

        //    if (GetCacheDataByKey(PubConstant.Key_PopedomFun) != null)
        //    {
        //        return (List<PopedomFun>)GetCacheDataByKey(PubConstant.Key_PopedomFun);
        //    }
        //    else
        //    {
        //        Popedom.BLLPopedomFun bllFun = new Popedom.BLLPopedomFun();

        //        List<PopedomFun> arrFun = bllFun.GetModelAll();

        //        SaveCache(PubConstant.Key_PopedomFun, arrFun, "PopedomFun");
        //        return arrFun;
        //    }
        //}

        ///// <summary>
        ///// 所有权限组
        ///// </summary>
        ///// <returns></returns>
        //internal static List<PopedomGroup> GetAllPopedomGroup()
        //{
        //    SaveCacheMethods(PubConstant.Key_PopedomGroup, "GetAllPopedomGroup");

        //    if (GetCacheDataByKey(PubConstant.Key_PopedomGroup) != null)
        //    {
        //        return (List<PopedomGroup>)GetCacheDataByKey(PubConstant.Key_PopedomGroup);
        //    }
        //    else
        //    {
        //        Popedom.BLLPopedomFunGroup bllFunGroup = new Popedom.BLLPopedomFunGroup();
        //        List<PopedomGroup> arrFunGroup = bllFunGroup.GetModelAll();
        //        SaveCache(PubConstant.Key_PopedomGroup, arrFunGroup, "PopedomGroup");
        //        return arrFunGroup;
        //    }
        //}

        ///// <summary>
        ///// 所有会员角色权限信息
        ///// </summary>
        ///// <returns></returns>
        //public static List<PopedomFunInAdminRole> GetAllPopedomFunInAdminRole()
        //{

        //    SaveCacheMethods(PubConstant.Key_PopedomFunInAdminRole, "GetAllPopedomFunInAdminRole");


        //    if (GetCacheDataByKey(PubConstant.Key_PopedomFunInAdminRole) != null)
        //    {
        //        return (List<PopedomFunInAdminRole>)GetCacheDataByKey(PubConstant.Key_PopedomFunInAdminRole);
        //    }
        //    else
        //    {
        //        Popedom.BLLPopedomFunInAdminRole bllFRole = new Popedom.BLLPopedomFunInAdminRole();
        //        List<PopedomFunInAdminRole> arrFunInRole = bllFRole.GetModelAll();
        //        SaveCache(PubConstant.Key_PopedomFunInAdminRole, arrFunInRole, "PopedomFunInAdminRole");
        //        return arrFunInRole;
        //    }
        //}

        //#endregion

        //#region  广告列表
        ///// <summary>
        ///// 广告审核能过的广告
        ///// </summary>
        ///// <returns></returns>
        //public static List<ADList> GetAllCheckedAdList()
        //{

        //    SaveCacheMethods(PubConstant.Key_ADList, "GetAllCheckedAdList");

        //    if (GetCacheDataByKey(PubConstant.Key_ADList) != null)
        //    {

        //        return (List<ADList>)GetCacheDataByKey(PubConstant.Key_ADList);
        //    }
        //    else
        //    {
        //        AD.BLLADList bllAD = new AD.BLLADList();

        //        List<ADList> arrAD = bllAD.GetAllADList(false);
        //        SaveCache(PubConstant.Key_ADList, arrAD, "ADList");
        //        return arrAD;

        //    }
        //}
        //#endregion

        #region 缓存函数 ，添加，更新删除
        /// <summary>
        /// 得到缓存对像
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object GetCache(string key)
        {
          
                try
                {
                    if (HttpRuntime.Cache.Get(key) != null)
                    {
                        return HttpRuntime.Cache.Get(key);
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception)
                {

                    return null;
                }
           
        }
        #region 存储
        /// <summary>
        /// 存储到cache中,默认为存储1天
        /// </summary>
        public static void SaveCache(string key, object v)
        {
         SaveCache(key, v,  DateTime.Now.AddDays(1));
        }

        #region  文件缓存依赖项
        public static void SaveCache(string key, object v,  DateTime expireDate)
        {
            HttpRuntime.Cache.Insert(key, v, null, expireDate, System.Web.Caching.Cache.NoSlidingExpiration);
          }


    #endregion

        #endregion


        #region 册除缓存
        /// <summary>
        /// 更新缓存,同时更改依赖项
        /// </summary>
        /// <param name="p"></param>
        /// 

        public static void Remove(string Key)
        {
           HttpRuntime.Cache.Remove(Key);
     
        }

      

        #endregion
        #endregion














    }
}
