using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace LL.Common.Cache
{
    /**用于session 管理**/
    public static class SessionManager
    {

        

        #region session 管理
        /// <summary>
        /// 存储session 值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="v"></param>
        public static void SetSession(string key, object v)
        {

            
            HttpContext.Current.Session[key] = v;
        }
      
        /// <summary>
        /// 取sessin中的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object GetSession(string key)
        {
            if (HttpContext.Current.Session[key] != null)
            {

                return HttpContext.Current.Session[key];
            }
            else
            {
                return null;
            }
        }
        public static void DestorySession(string key)
        {

            HttpContext.Current.Session[key] = "";
            HttpContext.Current.Session.Remove(key);
        }
        #endregion

        #region session 单点登录


     




        //public class SessionLogin
        //{

        //    public int UserID { get; set; }
        //    public string UserName { get; set;}
        //    public string UserPassword { get; set;}
        //}

        #endregion



    }
}


