using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
namespace LL.Common.Cache
{
    public class ConfigManager
    {


        /// <summary>
        /// 有网站管理功能的会员权限
        /// </summary>
        public static string WebSiteGroupIDList
        {

            get
            {
                return GetConfigSettingsValue("VipWebSiteGroupIDList");
            }
        }
        #region 得到config 值

        /// <summary>
        /// 得到appSettings中的value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConfigSettingsValue(string key)
        {


            if (ConfigurationManager.AppSettings[key] != null)
            {
                return ConfigurationManager.AppSettings[key].ToString();


            }
            else
            {

                return string.Empty;

            }


        }



        #endregion


        /// <summary>
        /// 有网站的会员组
        /// </summary>
        public static string WebSiteGroupID
        {
            get
            {

                return GetConfigSettingsValue("WebSiteGroupID");

            }
        }


        public static string ConnectionString
        {
            get
            {

                return GetConfigSettingsValue("ConnectionString");

            }
        }

        public static string DataBase
        {
            get
            {

                return GetConfigSettingsValue("DataBase");

            }
        }







        public static string GetCachePhyPath
        {
            get
            {

                return GetConfigSettingsValue("CachePhyPath");

            }
        }


        #region 与广告相关
    
        public static string DirJsAD
        {
            get
            {

                return GetConfigSettingsValue("DirJsAD");

            }
        }
        public static string PhyDir_JsAD
        {
            get
            {

                return GetConfigSettingsValue("PhyDir_JsAD");

            }
        }


        public static string Url_AdminLogin
        {
            get
            {

                return GetConfigSettingsValue("Url_AdminLogin");

            }
        }

        
        #endregion



        #region 域名地址

        /// <summary>
        /// 得到主域名
        /// </summary>
        public static string MainDomain  {    get {    return GetConfigSettingsValue("MainDomain");}  }
        /// <summary>
        /// 主域名所在的根目录
        /// </summary>
        public static string DirMainDomainRoot { get { return GetConfigSettingsValue("DirMainDomainRoot"); } }
        #region 图片站 
        /// <summary>
        /// 图片站
        /// admin config中配置
        /// </summary>
        public static string ImgDomin   {  get {     return GetConfigSettingsValue("ImgDomain");    }   }
        /// <summary>
        /// 图片站根路径
        /// </summary>
        public static string ImgDomainRootPath
        {
            get
            {
                return GetConfigSettingsValue("ImgDomainRootPath");
            }

        }
        /// <summary>
        /// 上传到服务器充许的文件类型
        /// </summary>
        public static string UploadImgExtension
        {
            get  {return GetConfigSettingsValue("UploadImgExtension");   }
        }
        /// <summary>
        /// 上传到服务器充许的文件类型
        /// </summary>
        public static string UploadFlashExtension
        {
            get    {   return GetConfigSettingsValue("UploadFlashExtension");  }
        }
        /// <summary>
        /// 上传到服务器充许的文件类型
        /// </summary>
        public static string UploadMediaExtension
        {  get   {  return GetConfigSettingsValue("UploadMediaExtension");  }   }


        /// <summary>
        /// 上传到服务器充许的文件类型
        /// </summary>
        public static string UploadOtherExtension
        {
            get {      return GetConfigSettingsValue("UploadOtherExtesion");   }
        }
        /// <summary>
        /// 上传到服务器充许的文件类型
        /// </summary>
        public static string UploadDisabledExtension
        {
            get {    return GetConfigSettingsValue("UploadDisabledExtension");  }
        }

        /// <summary>
        ///DifServerCacheLink
        /// </summary>
        public static string DifServerCacheHref
        {
            get {  return GetConfigSettingsValue("DifServerCacheHref"); }
        }
        #endregion

    
      // 资讯频道（News）
        public static string SubDomain_News   {  get    { return GetConfigSettingsValue("SubDomain_News"); } }

        //商用车频道（Commercial  vehicle）CV
        public static string SubDomain_CV { get { return GetConfigSettingsValue("SubDomain_CV"); } }

        //物流装备频道（Logistics equipment）LE
        public static string SubDomain_LE { get { return GetConfigSettingsValue("SubDomain_LE"); } }

        //会员频道--http://VIP.clb.org.cn/ 
        public static string SubDomain_VIP { get { return GetConfigSettingsValue("SubDomain_VIP"); } }
        
        //行业频道（Industry logistics）IL
        public static string SubDomain_IL { get { return GetConfigSettingsValue("SubDomain_IL"); } }

        //园区频道（Logistics park）LP
        public static string SubDomain_LP { get { return GetConfigSettingsValue("SubDomain_LP"); } }

        //人才频道（Human resources）HR
        public static string SubDomain_HR { get { return GetConfigSettingsValue("SubDomain_HR"); } }

        //展会频道（Conference & Exhibition）CE
        public static string SubDomain_CE { get { return GetConfigSettingsValue("SubDomain_CE"); } }

        //公司库频道gsk
        public static string SubDomain_Gsk{ get { return GetConfigSettingsValue("SubDomain_Gsk"); } }


        #endregion









  
    }
}
