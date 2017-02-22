using System;
using System.Data;
using System.Web;
using System.Web.Security;
using Project.Common;
using System.Runtime.CompilerServices;
namespace LL.Common.Cache

{
    /// <summary>
    /// CookieManager 的摘要说明
    /// </summary>
    public class CookieManager
    {  
        /// <summary>
        /// 域名称
        /// </summary>
        public static string DomainName = System.Configuration.ConfigurationManager.AppSettings["DomainName"];
        
        public  const  string Key_CookieUserID = "UserID";
        public  const string Key_CookieUserName = "UserName";
        public  const string Key_CookieUserType = "UserType";
        public const string Key_CookieName = "CookieName";
        public  const string Key_CookiePassword = "UserPassword";

        
        /// <summary>
        /// cookie传输路径
        /// </summary>
        private static string CookiePath = FormsAuthentication.FormsCookiePath;

        /// <summary>
        /// 隐藏构造函数
        /// </summary>

        private CookieManager()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
          
        }

        /// <summary>
        /// 写cookies
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="cookieName"></param>
        public static void SetCookie(string key, string value, string cookieName)
        {
            HttpCookie commonCookie;
            if (HttpContext.Current.Request.Cookies[cookieName] != null)
            {
                commonCookie = HttpContext.Current.Request.Cookies[cookieName];
               // HttpContext.Current.Response.Cookies.Add(commonCookie);
            }
            else
            {
                commonCookie = new HttpCookie(cookieName);
                commonCookie.Path = "/";
                if (IsUseDomain()) commonCookie.Domain = DomainName;
            }
            commonCookie.Values[key] = value;
            commonCookie.Expires = System.DateTime.Now.AddDays(30);
            HttpContext.Current.Response.Cookies.Add(commonCookie);
        }


        public static void SetCookie(string key, string value, string cookieName,DateTime  expires)
        {
            HttpCookie commonCookie;
            if (HttpContext.Current.Request.Cookies[cookieName] != null)
            {
                commonCookie = HttpContext.Current.Request.Cookies[cookieName];
                // HttpContext.Current.Response.Cookies.Add(commonCookie);
            }
            else
            {
                commonCookie = new HttpCookie(cookieName);
                commonCookie.Path = "/";
                if (IsUseDomain()) commonCookie.Domain = DomainName;
            }
            commonCookie.Values[key] = value;
            commonCookie.Expires = expires;
            HttpContext.Current.Response.Cookies.Add(commonCookie);
        }

        /// <summary>
        /// 读取cookies
        /// </summary>
        /// <param name="key"></param>
        /// <param name="cookieName"></param>
        /// <returns></returns>
        public static string GetCookie(string key, string cookieName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (cookie == null) return "";

            string cookieValue = cookie.Values[key];
            if (cookieValue == null) return "";
            return cookieValue;
        }



        public static void ClearCookie(string cookieName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (cookie != null)
            {
                
                cookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
 
 

         

        #region -------------登录

        /// <summary>
        /// 记录用户信息
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="uName"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static void SetLogin(string uid, string uName,string type)
        {
            HttpCookie userCookie;
            //不存在Cookies 创建，否则读取。。。
            if (HttpContext.Current.Request.Cookies[Key_CookieName] != null)
            {
                userCookie = HttpContext.Current.Request.Cookies[Key_CookieName];
            }
            else
            {
                userCookie = new HttpCookie(Key_CookieName);
            }
            userCookie.Expires = System.DateTime.Now.AddDays(30);
            userCookie.Path = "/";
            if (IsUseDomain()) userCookie.Domain = DomainName;
            userCookie.Values[Key_CookieUserID] = uid;

            userCookie.Values[Key_CookieUserName] = HttpUtility.UrlEncode(uName, System.Text.Encoding.GetEncoding("GB2312"));
            userCookie.Values[Key_CookieUserType] = HttpUtility.UrlEncode(type, System.Text.Encoding.GetEncoding("GB2312"));
            HttpContext.Current.Response.Cookies.Add(userCookie);

        }


        /// <summary>
        /// 存储用户名，密码
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="cookieName"></param>
        /// <param name="loginName"></param>
        /// <param name="loginPwd"></param>
        /// <param name="type"></param>
        /// <param name="expiresHourse"></param>

        public static void SetLogin(string userID, string cookieName,string loginName, string loginPwd, string type, int expiresHourse)
        {

            HttpCookie loginCookie;

            //存在重新设置
            if (HttpContext.Current.Request.Cookies[cookieName] != null)
            {
                loginCookie = HttpContext.Current.Request.Cookies[cookieName];
            }
            else
            {
                loginCookie = new HttpCookie(cookieName);
            }

            if (IsUseDomain()) loginCookie.Domain = DomainName;
            loginCookie.Expires = System.DateTime.Now.AddHours(expiresHourse);
            loginCookie.Path = "/";
            loginCookie.Values[Key_CookieUserID] = userID;
            loginCookie.Values[Key_CookieUserName] = HttpUtility.UrlDecode(loginName, System.Text.Encoding.GetEncoding("GB2312"));
            loginCookie.Values[Key_CookiePassword] = HttpUtility.UrlDecode(loginPwd,System.Text.Encoding.GetEncoding("GB2312"));
            loginCookie.Values[Key_CookieUserType] = HttpUtility.UrlEncode(type, System.Text.Encoding.GetEncoding("GB2312"));
            HttpContext.Current.Response.Cookies.Add(loginCookie);
        
        }

     

        /// <summary>
        /// 记录用户信息
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="uName"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static void SetLogin(string uid, string cookiesname,string uName, string type, int expiresHourse)
        {
            HttpCookie userCookie;
            //不存在Cookies 创建，否则读取。。。
            if (HttpContext.Current.Request.Cookies[cookiesname] != null)
            {
                userCookie = HttpContext.Current.Request.Cookies[cookiesname];
         
            }
            else
            {
                userCookie = new HttpCookie(cookiesname);
            }
            userCookie.Expires = System.DateTime.Now.AddHours(expiresHourse);
        
            userCookie.Path = "/";
           // if (IsUseDomain()) userCookie.Domain = DomainName;
            userCookie.Values[Key_CookieUserID] = uid;
            userCookie.Values[Key_CookieUserName] = HttpUtility.UrlEncode(uName, System.Text.Encoding.GetEncoding("GB2312"));
            userCookie.Values[Key_CookieUserType] = HttpUtility.UrlEncode(type, System.Text.Encoding.GetEncoding("GB2312"));
            HttpContext.Current.Response.Cookies.Add(userCookie);
        }


        ///// <summary>
        ///// 得到登录用户信息，返回匿名对像
        ///// new {UserID = loginID, UserName = loginName, UserPassword = loginPwd}
        ///// </summary>
        ///// <param name="cookieName"></param>
        ///// <returns></returns>
        public static LoginNameAndPwd GetLoginUser(string cookieName)
        {

            LoginNameAndPwd newLoginInfo = null;
            if (HttpContext.Current.Request.Cookies[cookieName] != null)
            {

                HttpCookie loginCookie = HttpContext.Current.Request.Cookies[cookieName];
                string loginName = loginCookie[Key_CookieName];
                string loginPwd = loginCookie[Key_CookiePassword];
                string loginID = loginCookie[Key_CookieUserID];

                newLoginInfo = new LoginNameAndPwd();

                newLoginInfo.LoginName = loginName;
                newLoginInfo.LoginPwd = loginPwd;
                newLoginInfo.LoginID = loginID;
            }
            return newLoginInfo;
        }

   
        /// <summary>
        /// 得到用户id
        /// </summary>
        /// <param name="cName"></param>
        /// <returns></returns>
        public static int GetLoginUserID(string cName)
        {
            if (HttpContext.Current.Request.Cookies[cName] != null)
            {
                HttpCookie cookies = HttpContext.Current.Request.Cookies[cName];
                try
                {
                return   Format.DataConvertToInt(cookies.Values[Key_CookieUserID]);
                }
                catch (Exception)
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
   
       
        #endregion
        /// <summary>
        /// 是否跨域
        /// </summary>
        internal static bool IsUseDomain()
        {
            return (DomainName == null || DomainName == "") ? false : true;
        }



    
    }

 
}