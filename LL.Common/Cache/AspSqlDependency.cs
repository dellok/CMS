using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Caching;
using System.Web;

namespace LL.Common.Cache
{
 public    class AspSqlDependency
    {


     /// <summary>
        /// 增加数据库表缓存依赖项
     /// </summary>
     /// <param name="constr"></param>c
     /// <param name="database"></param>
     /// <param name="tablename"></param>
     /// <param name="cacheKey"></param>
     /// <param name="cacheValue"></param>
     /// <param name="cacheTime"></param>
     public static void   InsertCache(string constr, string database, string tablename, string cacheKey, object  cacheValue, DateTime cacheTime)
     {

         SqlCacheDependencyAdmin.EnableNotifications(constr);
         SqlCacheDependencyAdmin.EnableTableForNotifications(constr, tablename);
         AggregateCacheDependency cd = GetDependency(constr, database, tablename);
        HttpRuntime.Cache.Add(cacheKey,cacheValue, cd,cacheTime, System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, null);
        }

        public static AggregateCacheDependency GetDependency(string constr,string database ,string tablename)
        {
            AggregateCacheDependency dependency = new AggregateCacheDependency();
            System.Web.Caching.SqlCacheDependencyAdmin.EnableTableForNotifications(constr,tablename);
            try
            {
                dependency.Add(new SqlCacheDependency(database,tablename));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dependency;
        }

    }
}
