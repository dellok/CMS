using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Web.Security;
namespace Project.Common
{
    /// <summary>
    /// 加密解密
    /// </summary>
    public class WebSecurity
    {


        private static string _QueryStringKey = "clborgcn"; //URL传输参数加密Key
        private static string _PassWordKey = "lenglian";　//PassWord加密Key

        public WebSecurity()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        #region 加密,解密 URL传输的字符串

        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="QueryString"></param>
        /// <returns></returns>
        public static string EncryptQueryString(string QueryString)
        {
            string strEncrypt = Encrypt(QueryString, _QueryStringKey);

            return System.Web.HttpContext.Current.Server.UrlEncode(strEncrypt);

        }

        /// <summary>
        /// 解密字符串
        /// </summary>
        /// <param name="QueryString"></param>
        /// <returns></returns>
        public static string DecryptQueryString(string QueryString)
        {

            string strDecrypt = System.Web.HttpContext.Current.Server.UrlDecode(QueryString);
            return Decrypt(strDecrypt, _QueryStringKey);
        }

        #endregion
        #region  帐号加密解密
        ///
        /// 加密帐号口令
        ///
        public static string EncryptPassWord(string PassWord)
        {
            return Encrypt(PassWord, _PassWordKey);
        }

        ///
        /// 解密帐号口令
        ///
        public static string DecryptPassWord(string PassWord)
        {
            return Decrypt(PassWord, _PassWordKey);
        }
        #endregion

        #region  md5不可逆加密密码
        /// <summary>
        /// md5不可逆加密密码
        /// </summary>
        /// <param name="strPwd"></param>
        /// <returns></returns>
        public static string EncryptPasswordMD5(string strPwd)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(strPwd, "MD5");
        }

        /// <summary>
        /// 双重md5加密 
        /// </summary>
        /// <param name="strPwd"></param>
        /// <returns></returns>
        public static string EncryptPasswordDualMD5(string strPwd)
        {

            return EncryptPasswordMD5(EncryptPasswordMD5(strPwd));
        }


        public static string PHPMD5(string pwd)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] bytesSrc = encoding.GetBytes(pwd);
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(bytesSrc);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
                sb.AppendFormat("{0:x2}", result[i]);
            string s1 = sb.ToString();
            byte[] bytesmd5 = encoding.GetBytes(s1);
            string keymd5 = Convert.ToBase64String(bytesmd5);

            return keymd5;
        }


        #endregion

       
        #region DEC加密函数
        ///
        /// DEC 加密过程
        ///
        private static string Encrypt(string pToEncrypt, string sKey)
        {

            if (string.IsNullOrEmpty(pToEncrypt))
            {
                return string.Empty;
            }


            DESCryptoServiceProvider des = new DESCryptoServiceProvider();　//把字符串放到byte数组中

            byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
            //byte[]　inputByteArray=Encoding.Unicode.GetBytes(pToEncrypt);

            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);　//建立加密对象的密钥和偏移量
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);　 //原文使用ASCIIEncoding.ASCII方法的GetBytes方法
            MemoryStream ms = new MemoryStream();　　 //使得输入密码必须输入英文文本
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            ret.ToString();
            return ret.ToString();
        }

        ///
        /// DEC 解密过程
        ///
        private static string Decrypt(string pToDecrypt, string sKey)
        {
            if (string.IsNullOrEmpty(pToDecrypt))
            {
                return string.Empty;
            }

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
            for (int x = 0; x < pToDecrypt.Length / 2; x++)
            {
                int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }

            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);　//建立加密对象的密钥和偏移量，此值重要，不能修改
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);

            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            StringBuilder ret = new StringBuilder();　//建立StringBuild对象，CreateDecrypt使用的是流对象，必须把解密后的文本变成流对象

            return System.Text.Encoding.Default.GetString(ms.ToArray());
        }
        #endregion
        #region 对比验证

        ///
        /// 检查己加密的字符串是否与原文相同
        ///
        private static bool ValidateString(string EnString, string FoString, int Mode)
        {
            bool IsSame = false;
            switch (Mode)
            {

                case 1:
                    if (Decrypt(EnString, _QueryStringKey) == FoString.ToString())
                    {
                        IsSame = true;
                    }
                    break;
                case 2:
                    if (Decrypt(EnString, _PassWordKey) == FoString.ToString())
                    {
                        IsSame = true;
                    }
                    break;

            }
            return IsSame;
        }

        /// <summary>
        /// 验证URL 字符串
        /// </summary>
        /// <param name="EnString"></param>
        /// <param name="FoString"></param>
        /// <returns></returns>
        public static bool ValidateURL(string EnString, string FoString)
        {
            EnString = EnString.Trim();
            FoString = FoString.Trim();

            if (EncryptQueryString(EnString.Trim()) == FoString)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        /// <summary>
        /// 验证密码
        /// </summary>
        /// <param name="EnString"></param>
        /// <param name="FoString"></param>
        /// <returns></returns>
        public static bool ValidatePassword(string EnString, string FoString)
        {

            EnString = EnString.Trim();
            FoString = FoString.Trim();
            if (EncryptPassWord(EnString.Trim()) == FoString)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        #endregion

        private static char[] constant = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        /// <summary>
        /// 随机生成位数
        /// </summary>
        /// <param name="strLength"></param>
        /// <returns></returns>
        public  static string   GetRandomStrByLen(int strLength)
        {
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder();
            Random rd = new Random();

            for (int i = 0; i < strLength; i++)
            {
                newRandom.Append(constant[rd.Next(0, constant.Length)]);
                System.Threading.Thread.Sleep(1);
            }
            return newRandom.ToString();
        } 


    }


}

