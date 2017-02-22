using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;


  public   class Filter
    {

       private HttpRequest request;
       // private const string StrKeyWord = @"select|insert|delete|from|count(|drop table|update|truncate|asc(|mid(|char(|xp_cmdshell|exec master|netlocalgroup administrators|:|net user|""|or|and";


    private const string StrKeyWord = @"select|insert|delete|from|count(|drop table|update|truncate|asc(|mid(|char(|xp_cmdshell|exec master|netlocalgroup administrators|:|net user|""|and";
     
      private const string StrRegex = @"[-|;|,|/|(|)|[|]|}|{|%|@|*|!|']";
    private   static   string[] sqlChar = StrKeyWord.Split(new char[]{'|'});


        public Filter(System.Web.HttpRequest _request)
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            this.request = _request;
        }

        /**//**//**//// <summary>
        /// 只读属性 SQL关键字
        /// </summary>
        public static string SqlKeyWord
        {
            get
            {
                return StrKeyWord;
            }
        }
        /**//**//**//// <summary>
        /// 只读属性过滤特殊字符
        /// </summary>
        public static string RegexString
        {
            get
            {
                return StrRegex;
            }
        }
        /**//**//**//// <summary>
        /// 检查URL参数中是否带有SQL注入可能关键字。
        /// </summary>
        /// <param name="_request">当前HttpRequest对象</param>
        /// <returns>存在SQL注入关键字true存在，false不存在</returns>
        public bool CheckRequestQuery()
        {
            if (request.QueryString.Count != 0)
            {
                //若URL中参数存在，逐个比较参数。
                for (int i = 0; i < request.QueryString.Count; i++)
                {
                    // 检查参数值是否合法。
                    if (CheckSqlKeyWord(request.QueryString[i].ToString()))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /**//**//**//// <summary>
        /// 检查提交表单中是否存在SQL注入可能关键字
        /// </summary>
        /// <param name="_request">当前HttpRequest对象</param>
        /// <returns>存在SQL注入关键字true存在，false不存在</returns>
        public bool CheckRequestForm()
        {
            if (request.Form.Count > 0)
            {
                //获取提交的表单项不为0 逐个比较参数
                for (int i = 0; i < request.Form.Count; i++)
                {
                    //检查参数值是否合法
                    if (CheckSqlKeyWord(request.Form[i]))
                    {
                        //存在SQL关键字
                        return true;

                    }
                }
            }
            return false;
        }
      /// <summary>
      /// 替换关键字
      /// </summary>
      /// <param name="input"></param>
     private  static string  ReplaceSqlKeyWord(string input)
     {
         string[]  arrKW=StrKeyWord.Split('|');
         for (int i = 0; i < arrKW.Length; i++)
			{
                  input.Replace(arrKW[i]," ");
			}
         return input;
     }
      /// <summary>
      /// 过滤特殊字符,替换成中文
      /// </summary>
      /// <param name="input"></param>
      /// <returns></returns>
     public   static string  ReplaceSqlECharToCChar(string input)
     {
            input=input.Replace("-","—");
            input=input.Replace(";","；");
            input=input.Replace(",","，");
            input=input.Replace("/","／");
            input=input.Replace("(","（");
            input=input.Replace(")","）");
            input = input.Replace("[", "【");
            input = input.Replace("]", "】");
            input=input.Replace("}","｝");
            input=input.Replace("{","｛");
            input=input.Replace("%","％");
            input=input.Replace("@","＠");
            input=input.Replace("*","×");
            input=input.Replace("!","！");
            input=input.Replace("'","’");

         return input;
     }
      /// <summary>
      /// rep
      /// </summary>
      /// <param name="input"></param>
      /// <returns></returns>
     public static string ReplacCCharToEChar(string input)
     {
         input = input.Replace("—", "-");
         input = input.Replace("；",";");
         input = input.Replace("，",",");
         input = input.Replace("／","/");
         input = input.Replace("（","(");
         input = input.Replace("）",")");
         input = input.Replace("【","[");
         input = input.Replace("】","]");
         input = input.Replace("｝","}");
         input = input.Replace("｛","{");
         input = input.Replace("％","%");
         input = input.Replace("＠","@");
         input = input.Replace("×","*");
         input = input.Replace("！","!");
         input = input.Replace("’","'");

         return input;
     }





     public static  System.Collections.Hashtable  ECharKeyHash()
     {

         System.Collections.Hashtable ht = new System.Collections.Hashtable();

         ht.Add("-", "—");
         ht.Add(";", "；");
         ht.Add(",", "，");
         ht.Add("/", "／");
         ht.Add("(", "（");
         ht.Add(")", "）");
         ht.Add("[", "【");
         ht.Add("]", "】");
         ht.Add("}", "｝");
         ht.Add("{", "｛");
         ht.Add("%", "％");
         ht.Add("@", "＠");
         ht.Add("*", "×");
         ht.Add("!", "！");
         ht.Add("'", "’");

     
         return ht;
    
     }


     public static System.Collections.Hashtable CCharKeyHash()
     {

      
         System.Collections.Hashtable ht = new System.Collections.Hashtable();
         ht.Add("—", "-");
         ht.Add("；", ";");
         ht.Add("，", ",");
         ht.Add("／", "/");
         ht.Add("（", "(");
         ht.Add("）", ")");
         ht.Add("【", "[");
         ht.Add("】", "]");
         ht.Add("｝", "}");
         ht.Add("｛", "{");
         ht.Add("％", "%");
         ht.Add("＠", "@");
         ht.Add("×", "*");
         ht.Add("！", "!");
         ht.Add("’", "'");

         return ht;
     }

     public static string FilterHtmlTag(string input)
     {
         return Regex.Replace(input, "<[^>]+>", "");
     }



     public static string FilterSqlAndHtml(string input)
     { 
         input =Regex.Replace(input,"<[^>]+>" ,"");

         input = ReplaceSqlECharToCChar(input);

         return input;
     }

     public static string FilterSqlInput(string input)
     {
         foreach (string regex in sqlChar)
         {
             input = input.Replace(regex, "");
         }
         return input;
     }
      /// <summary>
      /// 过滤掉sql不安全因素
      /// </summary>
      /// <param name="input"></param>
      /// <returns></returns>
     //public static string ReplaceSql(string input)
     //{
     //    return ReplaceSqlChar(ReplaceSqlKeyWord(input));
     //}
        /**//**//**//// <summary>
        /// 静态方法，检查_sword是否包涵SQL关键字
        /// </summary>
        /// <param name="_sWord">被检查的字符串</param>
        /// <returns>存在SQL关键字返回true，不存在返回false</returns>
        public static bool CheckSqlKeyWord(string _sWord)
        {
            if (Regex.IsMatch(_sWord, StrKeyWord, RegexOptions.IgnoreCase) || Regex.IsMatch(_sWord, StrRegex))
                return true;
            return false;
        }

        /**//**//**//// <summary>
        /// 反SQL注入:返回1无注入信息，否则返回错误处理
        /// </summary>
        /// <returns>返回1无注入信息，否则返回错误处理</returns>
        public string CheckMessage()
        {
            string msg = "1";
            //if (CheckRequestQuery()) //CheckRequestQuery() || CheckRequestForm()
            //{
            //    msg = "<span style='font-size:24px;'>非法操作！<br>";
            //    msg += "操作IP：" + request.ServerVariables["REMOTE_ADDR"] + "<br>";
            //    msg += "操作时间：" + DateTime.Now + "<br>";
            //    msg += "页面：" + request.ServerVariables["URL"].ToLower() + "<br>";
            //    msg += "<a href="#" onclick="history.back()">返回上一页</a></span>";
            //}
            return msg.ToString();
        }

 
    
  
  
  }




