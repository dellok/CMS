using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Data;
using System.Net;
using System.IO;
namespace Project.Common
{
    public class Util
    {
        /// <summary>
        /// 过滤字符串前后 ,号  
        /// </summary>
        /// <param name="str"></param> 
        /// <returns></returns>
        public static string SplitStartEndComma(string str)
        {

            str = str.StartsWith(",") ? str.Substring(1, str.Length - 1) : str;
            str = str.EndsWith(",") ? str.Substring(0, str.Length - 1) : str;

            return str;

        }

        public static string FilterStartAndEndSign(string str, string sign)
        {


            int len = str.Length - 1;
            len = len >= 0 ? len : 0;
            str = str.StartsWith(sign) ? str.Substring(1, len) : str;

            len = str.Length - 1;
            len = len >= 0 ? len : 0;

            str = str.EndsWith(sign) ? str.Substring(0, str.Length - 1) : str;

            return str;

        }


        public static string SplitComma(string str)
        {

            str = str.StartsWith(",") ? str.Substring(1, str.Length - 1) : str;
            str = str.EndsWith(",") ? str.Substring(0, str.Length - 1) : str;

            return str;

        }
        public static string getDateTime(string date)
        {
            string time = "";
            DateTime dt;
            try
            {
                dt = Convert.ToDateTime(date);
                time = dt.Year + "/" + dt.Month + "/" + dt.Day;
            }
            catch { }
            return time;
        }



        #region  过滤html ，字符串中 的看不见的\r\n

        /// <summary>
        /// input.Replace((char)10, ' ').Replace((char)13, ' ');
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string SplitHtmlEnterChar(string input)
        {


            return input.Replace((char)10, ' ').Replace((char)13, ' ');

        }


        #endregion

        #region  小点后位数

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strV">字符串长度</param>
        /// <param name="len">要保留的位数</param>
        /// <returns></returns>
        public static string CutDecimalDotAfterLength(string strV, int len)
        {

            int position = strV.IndexOf(".");
            if (position > -1)
            {
                string subStr = strV.Substring(position + 1);

                if (subStr.Length > len)
                {
                    strV = strV.Substring(0, position + len + 1);

                }
            }
            return strV;
        }


        #endregion



        public static string CutStringNoPoints(string stringToSub, int length)
        {
            return CutString(stringToSub, length, false);
        }



        public static string CutString(object stringToSub, int length, bool isHavePoint)
        {

            if (stringToSub != null)
            {


                Regex regex = new Regex("[\u4e00-\u9fa5]+", RegexOptions.Compiled);
                char[] stringChar = stringToSub.ToString().ToCharArray();
                StringBuilder sb = new StringBuilder();
                int nLength = 0;

                for (int i = 0; i < stringChar.Length; i++)
                {
                    if (regex.IsMatch((stringChar[i]).ToString()))
                    {
                        sb.Append(stringChar[i]);
                        nLength += 2;
                    }
                    else
                    {
                        sb.Append(stringChar[i]);
                        nLength = nLength + 1;
                    }

                    if (nLength >= length)
                    {
                        if (isHavePoint)
                        {
                            sb.Append("...");
                        }
                        break;
                    }

                }

                return sb.ToString();
            }
            else {

                return "";
            }
        }
        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="stringToSub"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string CutString(object stringToSub, int length)
        {
            return CutString(stringToSub, length, true);
        }


        /// <summary> 
        /// 检测输入的邮件地址strEmail是否合法，
        /// 非法则返回true。 
        ///</summary> 
        public static bool CheckEmail(string strEmail)
        {
            int i, j;
            string strTmp, strResult;
            string strWords = "abcdefghijklmnopqrstuvwxyz_-.0123456789"; //定义合法字符范围 
            bool blResult = false;
            strTmp = strEmail.Trim();
            //检测输入字符串是否为空，不为空时才执行代码。 
            if (!(strTmp == "" || strTmp.Length == 0))
            {
                //判断邮件地址中是否存在“@”号 
                if ((strTmp.IndexOf("@") < 0))
                {
                    blResult = true;
                    return blResult;
                }
                //以“@”号为分割符，把地址切分成两部分，分别进行验证。 
                string[] strChars = strTmp.Split(new char[] { '@' });
                foreach (string strChar in strChars)
                {
                    i = strChar.Length;
                    //“@”号前部分或后部分为空时。 
                    if (i == 0)
                    {
                        blResult = true;
                        return blResult;
                    }
                    //逐个字进行验证，如果超出所定义的字符范围strWords，则表示地址非法。 
                    for (j = 0; j < i; j++)
                    {
                        strResult = strChar.Substring(j, 1).ToLower();//逐个字符取出比较 
                        if (strWords.IndexOf(strResult) < 0)
                        {
                            blResult = true;
                            return blResult;
                        }
                    }
                }
            }
            return blResult;
        }

        /// 截取字符串(1个汉字算2个字符)
        /// </summary>
        /// <param name="str">要截取的字符串</param>
        /// <param name="Length">需要保留的长度</param>
        /// <returns>截取后的字符串</returns>
        public static string GetSubStr(string str, int Length)
        {

            return GetSubStr(str, Length, true);

        }

        public static string GetSubStr(string str, int Length, bool isPoint)
        {
    
            if (!string.IsNullOrEmpty(str)) 
            {

                if (str.Length > Length)
                {

                    str = str.Substring(0, Length);
                    if (isPoint)
                    {
                        str += "...";
                    }
                }
  
            
            }
            return str;
        }

        public static string RegPicture(string ss)
        {
            ss = System.Text.RegularExpressions.Regex.Replace(ss, "src[^>]*[^/].(?:jpg|bmp|gif)(?:\"|\')", "");
            //@"^<img\s+[^>]*>";
            return ss;
        }
        public static string NoHTML(string TempContent)
        {
            //TempContent =  System.Text.RegularExpressions.Regex.Replace(TempContent,"<[^>]+>",""); //任意多个
            TempContent = System.Text.RegularExpressions.Regex.Replace(TempContent, @"<[^>|^<img\s+[^>]*>]*>", ""); //匹配一个
            return TempContent;
        }

        /**/
        /// <summary>
        /// 删除文件文件或图片
        /// </summary>
        /// <param name="path">当前文件的路径</param>
        /// <returns>是否删除成功</returns>
        public static bool FilePicDelete(string path)
        {
            bool ret = false;
            System.IO.FileInfo file = new System.IO.FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
                ret = true;
            }
            return ret;
        }

        public static string subStringHTML(string param, int length, string end)
        {
            string Pattern = null;
            MatchCollection m = null;
            StringBuilder result = new StringBuilder();
            int n = 0;
            char temp;
            bool isCode = false; //是不是HTML代码
            bool isHTML = false; //是不是HTML特殊字符,如&nbsp;
            char[] pchar = param.ToCharArray();
            for (int i = 0; i < pchar.Length; i++)
            {
                temp = pchar[i];
                if (temp == '<')
                {
                    isCode = true;
                }
                else if (temp == '&')
                {
                    isHTML = true;
                }
                else if (temp == '>' && isCode)
                {
                    n = n - 1;
                    isCode = false;
                }
                else if (temp == ';' && isHTML)
                {
                    isHTML = false;
                }

                if (!isCode && !isHTML)
                {
                    n = n + 1;
                    //UNICODE码字符占两个字节
                    if (System.Text.Encoding.Default.GetBytes(temp + "").Length > 1)
                    {
                        n = n + 1;
                    }
                }

                result.Append(temp);
                if (n >= length)
                {
                    break;
                }
            }
            result.Append(end);
            //取出截取字符串中的HTML标记
            string temp_result = result.ToString().Replace(@"(>)[^<>]*(<?)", "$1$2");
            //去掉不需要结素标记的HTML标记
            temp_result = temp_result.Replace(@"</?(AREA|BASE|BASEFONT|BODY|BR|COL|COLGROUP|DD|DT|FRAME|HEAD|HR|HTML|IMG|INPUT|ISINDEX|LI|LINK|META|OPTION|P|PARAM|TBODY|TD|TFOOT|TH|THEAD|TR|area|base|basefont|body|br|col|colgroup|dd|dt|frame|head|hr|html|img|input|isindex|li|link|meta|option|p|param|tbody|td|tfoot|th|thead|tr)[^<>]*/?>",
             "");
            //去掉成对的HTML标记
            temp_result = temp_result.Replace(@"<([a-zA-Z]+)[^<>]*>(.*?)</\1>", "$2");
            //用正则表达式取出标记
            Pattern = ("<([a-zA-Z]+)[^<>]*>");
            m = Regex.Matches(temp_result, Pattern);

            ArrayList endHTML = new ArrayList();

            foreach (Match mt in m)
            {
                endHTML.Add(mt.Result("$1"));
            }
            //补全不成对的HTML标记
            for (int i = endHTML.Count - 1; i >= 0; i--)
            {
                result.Append("</");
                result.Append(endHTML[i]);
                result.Append(">");
            }

            return result.ToString();
        }

        #region  过滤html 及危险html
        public static string checkStr(string html)
        {
            System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex(@"<script[sS]+</script *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex2 = new System.Text.RegularExpressions.Regex(@" href*= *[sS]*script *:", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex3 = new System.Text.RegularExpressions.Regex(@" no[sS]*=", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex4 = new System.Text.RegularExpressions.Regex(@"<iframe[sS]+</iframe *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex5 = new System.Text.RegularExpressions.Regex(@"<frameset[sS]+</frameset *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex6 = new System.Text.RegularExpressions.Regex(@"<img[^>]+>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex7 = new System.Text.RegularExpressions.Regex(@"</p>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex8 = new System.Text.RegularExpressions.Regex(@"<p>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex9 = new System.Text.RegularExpressions.Regex(@"<[^>]*>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            html = regex1.Replace(html, ""); //过滤<script></script>标记 
            //  html = regex2.Replace(html, ""); //过滤href=javascript: (<A>) 属性 
            html = regex3.Replace(html, " _disibledevent="); //过滤其它控件的on...事件 
            html = regex4.Replace(html, ""); //过滤iframe 
            html = regex5.Replace(html, ""); //过滤frameset 
            //  html = regex6.Replace(html, ""); //过滤frameset 
            html = regex7.Replace(html, ""); //过滤frameset 
            html = regex8.Replace(html, ""); //过滤frameset 
            html = regex9.Replace(html, "");
            html = html.Replace(@" ", "");
            html = html.Replace(@"</strong>", "");
            html = html.Replace(@"<strong>", "");
            return html;
        }

        /*  1. <script>标记中包含的代码 
  2. <a href=javascript:...中的代码 
  3. 其它基本控件的 on...事件中的代码 
  4. iframe 和 frameset 中载入其它页面造成的攻击 
  有了这些资料后，事情就简单多了，写一个简单的方法，用正则表达式把以上符合几点的代码替换掉: 
         * */
        public static string HtmlSplit(string html)
        {

            System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex(@"<script[\s\s]+</script *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex2 = new System.Text.RegularExpressions.Regex(@"<script[^>]*?>.*? </script>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            // System.Text.RegularExpressions.Regex regex8 = new System.Text.RegularExpressions.Regex(@"href", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex3 = new System.Text.RegularExpressions.Regex(@"href*= *[\s\s]*script *:", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex4 = new System.Text.RegularExpressions.Regex(@"on[\s\s]*=", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex5 = new System.Text.RegularExpressions.Regex(@"<iframe[\s\s]+</iframe *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex6 = new System.Text.RegularExpressions.Regex(@"<frameset[\s\s]+</frameset *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex7 = new System.Text.RegularExpressions.Regex(@"<iframe[^>]*?>.*? </iframe>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex8 = new System.Text.RegularExpressions.Regex(@"<frameset[^>]*?>.*? </frameset>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            html = regex1.Replace(html, ""); //过滤<script></script>标记 
            html = regex2.Replace(html, ""); //过滤href=javascript: (<a>) 属性 
            html = regex3.Replace(html, " _disibledevent="); //过滤其它控件的on...事件 
            html = regex4.Replace(html, ""); //过滤iframe 
            html = regex5.Replace(html, ""); //过滤frameset 
            html = regex6.Replace(html, "");
            html = regex7.Replace(html, "");
            html = regex8.Replace(html, "");



            return html;
        }




        public static string HtmlSplitToTradeageTag(string html, string toNewStr)
        {
            List<string> htmlEvent = HtmlEvent();

            foreach (string item in htmlEvent)
            {

                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"" + item + "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                html = regex.Replace(html, toNewStr);
            }
            System.Text.RegularExpressions.Regex regex2 = new System.Text.RegularExpressions.Regex(@"<iframe", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            html = regex2.Replace(html, "<tradeage");

            System.Text.RegularExpressions.Regex regex22 = new System.Text.RegularExpressions.Regex(@"</iframe", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            html = regex22.Replace(html, "</tradeage");

            System.Text.RegularExpressions.Regex regex3 = new System.Text.RegularExpressions.Regex(@"<script", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            html = regex3.Replace(html, "<tradeage");
            System.Text.RegularExpressions.Regex regex33 = new System.Text.RegularExpressions.Regex(@"</script", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            html = regex33.Replace(html, "</tradeage");
            System.Text.RegularExpressions.Regex regex4 = new System.Text.RegularExpressions.Regex(@"<frameset", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            html = regex4.Replace(html, "<tradeage");
            System.Text.RegularExpressions.Regex regex44 = new System.Text.RegularExpressions.Regex(@"</frameset", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            html = regex44.Replace(html, "</tradeage");




            return html;

        }







        private static List<string> HtmlEvent()
        {
            List<string> htmlEvent = new List<string>();
            htmlEvent.Add("href");
            htmlEvent.Add("onClick");
            htmlEvent.Add("onDblClick");

            htmlEvent.Add("onMouseDown");

            htmlEvent.Add("onMouseUp");

            htmlEvent.Add("onMouseOver");

            htmlEvent.Add("onMouseMove");

            htmlEvent.Add("onMouseOut");

            htmlEvent.Add("onKeyPress");

            htmlEvent.Add("onKeyDown");

            htmlEvent.Add("onKeyUp");


            htmlEvent.Add("onAbort");

            htmlEvent.Add("onBeforeUnload");

            htmlEvent.Add("onError");

            htmlEvent.Add("onLoad");

            htmlEvent.Add("onMove");

            htmlEvent.Add("onResize");

            htmlEvent.Add("onScroll");

            htmlEvent.Add("onStop");

            htmlEvent.Add("onUnload");

            htmlEvent.Add("onBlur");

            htmlEvent.Add("onChange");

            htmlEvent.Add("onFocus");

            htmlEvent.Add("onReset");

            htmlEvent.Add("onSubmit");


            htmlEvent.Add("onBounce");

            htmlEvent.Add("onFinish");

            htmlEvent.Add("onStart");

            htmlEvent.Add("onBeforeCopy");

            htmlEvent.Add("onBeforeCut");

            htmlEvent.Add("onBeforeEditFocus");

            htmlEvent.Add("onBeforePaste");

            htmlEvent.Add("onBeforeUpdate");

            htmlEvent.Add("onContextMenu");

            htmlEvent.Add("onCopy");

            htmlEvent.Add("onCut");

            htmlEvent.Add("onDrag");

            htmlEvent.Add("onDragDrop");

            htmlEvent.Add("onDragEnd");

            htmlEvent.Add("onDragEnter");

            htmlEvent.Add("onDragLeave");

            htmlEvent.Add("onDragOver");

            htmlEvent.Add("onDragStart");

            htmlEvent.Add("onDrop");

            htmlEvent.Add("onLoseCapture");

            htmlEvent.Add("onPaste");

            htmlEvent.Add("onSelect");

            htmlEvent.Add("onSelectStart");

            htmlEvent.Add("onAfterUpdate");

            htmlEvent.Add("onCellChange");

            htmlEvent.Add("onDataAvailable");

            htmlEvent.Add("onDatasetChanged");

            htmlEvent.Add("onDatasetComplete");

            htmlEvent.Add("onErrorUpdate");

            htmlEvent.Add("onRowEnter");

            htmlEvent.Add("onRowExit");

            htmlEvent.Add("onRowsDelete");

            htmlEvent.Add("onRowsInserted");

            htmlEvent.Add("onAfterPrint");

            htmlEvent.Add("onBeforePrint");

            htmlEvent.Add("onFilterChange");
            htmlEvent.Add("onHelp");
            htmlEvent.Add("onPropertyChange");
            htmlEvent.Add("onReadyStateChange");

            return htmlEvent;
        }







        #endregion
        /// <summary>
        /// 判断是否是数字
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsNumeric(string str)
        {
            if (str == null || str.Length == 0)
                return false;
            System.Text.ASCIIEncoding ascii = new System.Text.ASCIIEncoding();
            byte[] bytestr = ascii.GetBytes(str);
            foreach (byte c in bytestr)
            {
                if (c < 48 || c > 57)
                {
                    return false;
                }
            }
            return true;
        }

        #region 分页函数
        /// <summary>
        /// 分页函数（字符串）
        /// </summary>
        /// <param name="pageID">当前页</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="total">总记录数</param>
        /// <param name="sb">返回的最终分页字符串</param>
        /// <param name="paramStr">具体参数字符串,格式:a=1&b=2</param>
        public static void Pager(int pageID, int pageSize, int total, ref System.Text.StringBuilder sb, string paramStr)
        {

            if (total <= pageSize)
            {
                sb.Append("");
                return;
            }

            //分页控件
            int IDint = Convert.ToInt32(pageID);
            int Sizeint = Convert.ToInt32(pageSize);
            int totalPage = (int)Math.Ceiling((decimal)total / Sizeint);
            int currentEnd = 0, currentBegin = 0;


            //几种情况
            //1.当前页第一页
            if (IDint == 1)
            {
                sb.Append("<div class=\"view_b\"><ul>");
                currentEnd = totalPage >= 5 ? 5 : totalPage;
                sb.AppendFormat("<li><strong>Page {0}</strong> - <strong>{1}</strong> of <strong>{2}</strong></li>", 1, currentEnd, totalPage);
                sb.Append("<li class=\"v_alink\">");


                for (int j = 0; j < currentEnd; j++)
                {
                    if (j + 1 == IDint)
                    {
                        //当前页    
                        sb.AppendFormat("<a href=\"?{3}&fenye=true&pageIndex={0}&pageSize={1}\" class=\"v_ahover\">{2}</a>", j + 1, Sizeint, j + 1, paramStr);
                    }
                    else
                    {
                        sb.AppendFormat("<a href=\"?{3}&fenye=true&pageIndex={0}&pageSize={1}\">{2}</a>", j + 1, Sizeint, j + 1, paramStr);
                    }
                }
                if (IDint < totalPage)
                {
                    sb.AppendFormat("<a href=\"?{2}&fenye=true&pageIndex={0}&pageSize={1}\"  class=\"prev\">Next</a>", IDint + 1, Sizeint, paramStr);
                }

                sb.Append("</li></ul></div>");
            }
            //2。当前最后一页
            else if (IDint == totalPage)
            {
                sb.Append("<div class=\"view_b\"><ul>");
                currentBegin = totalPage - 5 > 0 ? totalPage - 5 : 1;

                sb.AppendFormat("<li><strong>Page {0}</strong> - <strong>{1}</strong> of <strong>{2}</strong></li>", currentBegin, totalPage, totalPage);

                sb.Append("<li class=\"v_alink\">");
                if (IDint > 1)
                {
                    //加一个prev按钮
                    sb.AppendFormat("<a href=\"?{2}&fenye=true&pageIndex={0}&pageSize={1}\"  class=\"prev\">Prev</a>", IDint - 1, Sizeint, paramStr);
                }
                for (int j = currentBegin; j <= totalPage; j++)
                {
                    if (j == IDint)
                    {
                        //当前页    
                        sb.AppendFormat("<a href=\"?{3}&fenye=true&pageIndex={0}&pageSize={1}\" class=\"v_ahover\">{2}</a>", j, Sizeint, j, paramStr);
                    }
                    else
                    {
                        sb.AppendFormat("<a href=\"?{3}&fenye=true&pageIndex={0}&pageSize={1}\">{2}</a>", j, Sizeint, j, paramStr);
                    }

                }

                sb.Append("</li></ul></div>");
            }
            // 3.中间
            else
            {
                //如果总页数小于等于五页则全部显示
                if (totalPage <= 5)
                {
                    currentBegin = 0;
                    sb.Append("<div class=\"view_b\"><ul>");

                    sb.AppendFormat("<li><strong>Page {0}</strong> - <strong>{1}</strong> of <strong>{2}</strong></li>", 1, totalPage, totalPage);

                    sb.Append("<li class=\"v_alink\">");


                    for (int j = currentBegin; j < totalPage; j++)
                    {
                        if (j + 1 == IDint)
                        {
                            //当前页    
                            sb.AppendFormat("<a href=\"?{3}&fenye=true&pageIndex={0}&pageSize={1}\" class=\"v_ahover\">{2}</a>", j + 1, Sizeint, j + 1, paramStr);
                        }
                        else
                        {
                            sb.AppendFormat("<a href=\"?{3}&fenye=true&pageIndex={0}&pageSize={1}\">{2}</a>", j + 1, Sizeint, j + 1, paramStr);
                        }

                    }
                    sb.Append("</li></ul></div>");
                }
                else if (totalPage > 5)   //如果记录总数大于5
                {
                    if (IDint - 2 >= 1) currentBegin = IDint - 2;
                    else currentBegin = 1;
                    if (IDint + 2 <= totalPage) currentEnd = IDint + 2;
                    else currentEnd = totalPage;

                    sb.Append("<div class=\"view_b\"><ul>");

                    sb.AppendFormat("<li><strong>Page {0}</strong> - <strong>{1}</strong> of <strong>{2}</strong></li>", currentBegin, currentEnd, totalPage);

                    sb.Append("<li class=\"v_alink\">");

                    if (IDint > 1)
                    {
                        sb.AppendFormat("<a href=\"?{2}&fenye=true&pageIndex={0}&pageSize={1}\" class=\"prev\">Prev</a>", IDint - 1, Sizeint, paramStr);
                    }

                    for (int j = currentBegin; j <= currentEnd; j++)
                    {
                        if (j == IDint)
                        {
                            //当前页    
                            sb.AppendFormat("<a href=\"?{3}&fenye=true&pageIndex={0}&pageSize={1}\" class=\"v_ahover\">{2}</a>", j, Sizeint, j, paramStr);
                        }
                        else
                        {
                            sb.AppendFormat("<a href=\"?{3}&fenye=true&pageIndex={0}&pageSize={1}\">{2}</a>", j, Sizeint, j, paramStr);
                        }
                    }

                    //添加一个向前或者向后按钮
                    if (IDint < totalPage)
                    {
                        sb.AppendFormat("<a href=\"?{2}&fenye=true&pageIndex={0}&pageSize={1}\"  class=\"prev\">Next</a>", IDint + 1, Sizeint, paramStr);
                    }
                    sb.Append("</li></ul></div>");


                }

            }
        }
        #endregion

        /// <summary>
        /// 过滤html标记
        /// </summary>
        /// <param name="strHtml"></param>
        /// <returns></returns>
        public static string SplitHTML(string strHtml)
        {
            if (!string.IsNullOrEmpty(strHtml))
            {
                Regex regex = new Regex(@"<[^>]+>|]+>");

                return regex.Replace(strHtml, "");
            }
            else
            {
                return string.Empty;
            }

        }




        #region 验证函数

        /// <summary>
        /// true  是Email
        /// false 不是email
        /// </summary>
        /// <param name="strEmail"></param>
        /// <returns></returns>
        public static bool ValidateEmail(string strEmail)
        {
            string strReg = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";


            Regex reg = new Regex(strReg, RegexOptions.IgnoreCase);

            return reg.IsMatch(strEmail);



        }
        /// <summary>
        /// true  是Email
        /// false 不是email
        /// </summary>
        /// <param name="strEmail"></param>
        /// <returns></returns>
        public static bool IsEmail(string strEmail)
        {
            string strReg = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";


            Regex reg = new Regex(strReg, RegexOptions.IgnoreCase);

            return reg.IsMatch(strEmail);



        }

        #endregion

        public static string HtmlStrNewLine(string str, int intNewLineWords, int intMaxLen)
        {
            int len = str.Length;

            if (len > intMaxLen)
            {
                str = str.Substring(0, intMaxLen);
                len = intMaxLen;
            }


            int insertCount = len / intNewLineWords;
            if (len > intNewLineWords)
            {
                for (int k = 0; k < insertCount; k++)
                {

                    int insertStartIndex = (k + 1) * intNewLineWords;
                    str = str.Insert(insertStartIndex + k, "<br>");

                }
            }
            return str;
        }

        public static string HtmlToBreakLine(string str, int intNewLineWords)
        {
            int len = str.Length;


            int insertCount = len / intNewLineWords;
            if (len > intNewLineWords)
            {
                for (int k = 0; k < insertCount; k++)
                {

                    int insertStartIndex = (k + 1) * intNewLineWords;
                    str = str.Insert(insertStartIndex + k, "<br>");

                }
            }
            return str;
        }






        #region    CuteEditor replace html  格式

        static string[] CuteEditorHtmlFormat = { "#0", "#1", "#2", "#3", "#4", "#5", "#6", "#7", "#8", "#9", "#a", "\x3C", "\x3E", "\x26", "*", "o", "O", "s", "S", "e", "E", "#", "LEGENT", "FIELDSET", "TEXTAREA", "INPUT", "SELECT", "OBJECT", "APPLET", "IMAGE", "DIV", "TABLE", "form", "parentNode", "tagName", "FORM", "returnValue", "_IsCuteEditor", "True", "imageinitliazed", "oncontextmenu", "onmouseout", "onmousedown", "onmouseup", "unselectable", "on", "isout", "className", "CuteEditorButtonOver", "srcElement", "CuteEditorButton", "button", "CuteEditorButtonDown", "IsCommandDisabled", "CuteEditorButtonDisabled", "IsCommandActive", "CuteEditorButtonActive", "value", "readOnly", "null", "", "selectedIndex", "event.returnValue=false", "CuteEditor_ColorPicker_ButtonOut(this)", "CuteEditor_ColorPicker_ButtonDown(this)", "cssText", "style", "runtimeStyle", "border:1px solid #0A246A; background-color:#b6bdd2;padding:1px;cursor:hand;", "padding:2px;cursor:hand;", "border:1px inset;" };

        /// <summary>
        /// CuteEditor_Decode解码(html格式)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>

        public static string CuteEditor_Decode(string str)
        {
            str = str.Replace(@"#1", CuteEditorHtmlFormat[11]); str = str.Replace(@"#2", CuteEditorHtmlFormat[12]); str = str.Replace(@"#3", CuteEditorHtmlFormat[13]); str = str.Replace(@"#4", CuteEditorHtmlFormat[14]); str = str.Replace(@"#5", CuteEditorHtmlFormat[15]); str = str.Replace(@"#6", CuteEditorHtmlFormat[16]); str = str.Replace(@"#7", CuteEditorHtmlFormat[17]); str = str.Replace(@"#8", CuteEditorHtmlFormat[18]); str = str.Replace(@"#9", CuteEditorHtmlFormat[19]); str = str.Replace(@"#a", CuteEditorHtmlFormat[20]); str = str.Replace(@"#0", CuteEditorHtmlFormat[21]);
            return str;

        }


        #endregion


        #region  CreateHtmlPage
        public static bool ReqHtmlPage(string url)
        {

            bool isOk = true;
            System.Net.WebRequest myRequest = System.Net.WebRequest.Create(url);
            //请求过期为3000毫秒
            myRequest.Timeout = 3000;
            try
            {
                System.Net.WebResponse myResponse = myRequest.GetResponse();
                myResponse.Close();
            }
            catch
            {
                return false;

            }
            return isOk;

        }
        /// <summary>
        /// 请求url 得到请求值
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string ReqPage(string url)
        {
            // Create a request for the URL. 		
            WebRequest request = WebRequest.Create(url);
            // If required by the server, set the credentials.
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Display the status.
            //Response.Write(response.StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            string content = responseFromServer;
            // Response.Write(responseFromServer);
            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            response.Close();

            return content;

        }
        #endregion
        public static string IPHideLast(string ip)
        {
            ip = Regex.Replace(ip, @"((\d{1,3}\.){3,})(\d{1,3})", "$1" + "***");
            return ip;

        }
        public static string SubStrNoPoint(object str, int len)
        {

            if (str != null)
            {
                return str.ToString().Length > len ? str.ToString().Substring(0, len) : str.ToString();
            }

            else
            {

                return "";
            }
        }










    }
}
