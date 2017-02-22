using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Collections;
using System.IO;
using System.Net;
namespace LL.Common.Cache
{




    public class DataCache
    {



        /// <summary>
        /// 生成静态页
        /// </summary>
        /// <param name="sourceurl">源aspx文件地址</param>
        /// <param name="url">目标html地址</param>
        public void CreateHTML(string sourceurl, string url)
        {
            System.Net.WebRequest myRequest = System.Net.WebRequest.Create(sourceurl);
            System.Net.WebResponse myResponse = myRequest.GetResponse();
            Stream stream = myResponse.GetResponseStream();
            StreamReader sr = new StreamReader(stream, Encoding.GetEncoding("gb2312"));
            StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath(url), false, System.Text.Encoding.Default);
            sw.WriteLine(sr.ReadToEnd());
            sw.Close();
        }

    }
}
