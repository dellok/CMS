using System;
using System.Reflection;
using System.Configuration;
using LL.IDAL;
using System.Web;
using LL.IDAL.Upload;
namespace LL.DALFactory
{
	public  partial class DataAccess
	{

    
        private static readonly string AssemblyPath ="LL.DAL";// ConfigurationManager.AppSettings["LL.DAL"];

     
		public DataAccess()
		{ }

        
        public static object CreateObject(string AssemblyPath, string ClassNamespace)
        {

            return CreateObject(ClassNamespace);
        }


        private static object CreateObject(string ClassNamespace)
        {
            object objType = GetCache(ClassNamespace);//从缓存读取
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(AssemblyPath).CreateInstance(ClassNamespace);//反射创建
                    SetCache(ClassNamespace, objType);// 写入缓存
                }
                catch
                { }
            }
            return objType;
        }


        public static object GetCache(string CacheKey)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            return objCache[CacheKey];
        }

        /// <summary>
        /// 设置当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <param name="objObject"></param>
        public static void SetCache(string CacheKey, object objObject)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject);
        }





    }
}
