using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace Project.Common
{
   public  class  Format
   {
      
       #region   json
       /// <summary>
       /// 把DataSet  转为json  ,
       /// ds中只能存在一个表,
       /// 成功返回字符串大于,否则还加空
       /// </summary>c
       /// <param name="ds"></param>
       /// <returns></returns>c

       public static  String DataSetToJson(DataSet ds)
       {
           StringBuilder json = new StringBuilder();

           if (ds.Tables.Count>0)
           {
               if (ds.Tables[0].Rows.Count>0)
               {

                   json.Append("[");

                   for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                   {
                       json.Append("{");
                       //得到列数
                       for (int c = 0; c < ds.Tables[0].Columns.Count; c++)
                       {

                           string colName = ds.Tables[0].Columns[c].ColumnName;
                           string rowColValue = ds.Tables[0].Rows[i][colName].ToString();

                           json.AppendFormat("\"{0}\":\"{1}\"",colName,rowColValue);
                           //列中的,
                           if (c != ds.Tables[0].Columns.Count-1) { json.AppendFormat(","); }
                       }
                        json.Append("}");
                        //下一列
                        if (i != ds.Tables[0].Rows.Count-1) { json.AppendFormat(","); }


                   }
                  
                   json.Append("]");
               }

           }


           return json.ToString();
       
       }

       /// <summary>
       /// 要求：
       /// 1.DataSet 必须包括两个table 
       /// 2.默认第一条记录为总行数
       /// 3. t0为数据
       /// 4.t1为数据条件的总行数
       /// </summary>
       /// <param name="ds"></param>
       /// <returns></returns>
       public string  DataSetToJSONAndCount(string jsonName,DataSet ds)
       {
           StringBuilder jsonStr = new StringBuilder();
           jsonStr.AppendFormat("{");

           if (ds.Tables.Count==2)
           {
               //得到记录总数

               int Count=0;
               string Key_Field="Count";

               if (ds.Tables[1].Rows.Count > 0)
               {

                   try
                   {
                   Count=Convert.ToInt16(ds.Tables[1].Rows[0][0]);
                   }
                   catch {}
                  
               }


               jsonStr.AppendFormat("[\"{0}\":{1}]",Key_Field,Count);

               //返回数据列的行数
               int dataRows = ds.Tables[0].Rows.Count;

               //把数把格式json字符串
               if (dataRows > 0)
               {
                   for (int i = 0; i < dataRows; i++)
                   {
                       jsonStr.AppendFormat("[");
                       //得到列表
                       for (int c = 0; c <ds.Tables[0].Columns.Count; c++)
                       {
                           //得到列名
                           string colName = ds.Tables[0].Columns[0].ColumnName;

                           jsonStr.AppendFormat("\"{0}\":\"{1}\",",colName,ds.Tables[0].Rows[i][colName].ToString());

                        }
                       jsonStr.AppendFormat("]");
                       if (i!=dataRows-1)
                       {
                           jsonStr.AppendFormat(",");   
                       }

                   }
               }
           }
           jsonStr.AppendFormat("}");

           return jsonStr.ToString();
       
       
       }

       /// <summary>
       /// 要求：
       /// 1.DataSet 必须包括两个table 
       /// 2.默认第一条记录为总行数
       /// 3. t0为数据
       /// 4.t1为数据条件的总行数
       /// </summary>
       /// <param name="ds"></param>
       /// <returns></returns>
       public string DataSetToJqueryJSONAndCount(DataSet ds)
       {
           StringBuilder jsonStr = new StringBuilder();
           jsonStr.AppendFormat("{");

           if (ds.Tables.Count == 2)
           {
               //得到记录总数

               int Count = 0;
               string Key_Field = "Count";

               if (ds.Tables[1].Rows.Count > 0)
               {

                   try
                   {
                       Count = Convert.ToInt16(ds.Tables[1].Rows[0][0]);
                   }
                   catch { }

               }

               jsonStr.AppendFormat("[\"{0}\":{1}]", Key_Field, Count);
               //返回数据列的行数
               int dataRows = ds.Tables[0].Rows.Count;

               //把数把格式json字符串
               if (dataRows > 0)
               {
                   for (int i = 0; i < dataRows; i++)
                   {
                       jsonStr.AppendFormat("[");
                       //得到列表
                       for (int c = 0; c < ds.Tables[0].Columns.Count; c++)
                       {
                           //得到列名
                           string colName = ds.Tables[0].Columns[0].ColumnName;

                           jsonStr.AppendFormat("\"{0}\":\"{1}\",", colName, ds.Tables[0].Rows[i][colName].ToString());

                       }
                       jsonStr.AppendFormat("]");
                       if (i != dataRows - 1)
                       {
                           jsonStr.AppendFormat(",");
                       }

                   }
               }
           }
           jsonStr.AppendFormat("}");

           return jsonStr.ToString();


       }

       #endregion


       #region  Request
      /// <summary>
      /// 从request 中取得值,格式化为string 类型
      /// </summary>
      /// <param name="key"></param>
      /// <returns></returns>
       public static  string RequestToString(string key)
       {
            System.Web.HttpRequest req = System.Web.HttpContext.Current.Request;
           if (req[key] != null)
           {
               return req[key].ToString();

           }
           else
           {
              return "";
           }
         
         
       }

       #endregion

       #region  得到DataRow中列值

       public static object GetColumnValue(DataRow row,string colName)
       {


           return row.Table.Columns.Contains(colName) ? row[colName] : "";
       
       }
       #endregion

       #region DataFormat
       /// <summary>
       /// 格式化成int型
       /// </summary>
       /// <param name="v"></param>
       /// <returns></returns>
      public static  int   DataConvertToInt(object  v)
       {

           int defalutV = 0;
           if (v!=null && !string.IsNullOrEmpty(v.ToString()))
           {

               try
               {
                   defalutV = Convert.ToInt32(v);

               }

               catch { }
           }
           return defalutV;
     
      }



      /// <summary>
      /// 格式化成bool
      /// </summary>
      /// <param name="p"></param>
      /// <returns></returns>

      public static bool DataConvertToBool(object p)
      {
    
          bool b = false;
          if (p!=null && !string.IsNullOrEmpty(p.ToString()))
          {

              try
              {

                  b = bool.Parse(p.ToString());


              }
              catch { }
          }
          return b;

      }


       /// <summary>
       /// 格式化数据为string ,异常返空string.Empty
       /// </summary>
       /// <param name="v"></param>
       /// <returns></returns>
      public static string DataConvertToString(object v)
      {

          string returnV = string.Empty;

          try
          {

              returnV = Convert.ToString(v);


          }  catch    {  }

          return returnV;
      }

      /// <summary>
      /// 得到时间,异常返回 当前时间
      /// </summary>
      /// <param name="strPostTime"></param>
      /// <returns></returns>
      public static DateTime DataConvertToDateTime(object strPostTime)
      {
          if ( strPostTime!=null && !string.IsNullOrEmpty(strPostTime.ToString()))
          {

              try
              {
                  return DateTime.Parse(strPostTime.ToString());
              }
              catch (Exception)
              {

                  return DateTime.Now;
              }
          }
          else
          {
              return DateTime.Now;
          }
      }
#endregion


       #region unix时间戳


       //unix时间戳 从1970-1-1 零点开始， .net中的DateTime.Ticks从0001-1-1零点开始
        /// <summary>
        /// datetime 转成Unix时间戳
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static  string DateTimeToUnixTimeStamp(DateTime dt)
        {

            string time = "0";

            try
            {
                DateTime unixStartTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
                TimeSpan timeSpan = dt.Subtract(unixStartTime);
                string timeStamp = timeSpan.Ticks.ToString();
                time= timeStamp.Substring(0, timeStamp.Length - 7);
            }
            catch { }

            return time;
        }

        
       /// <summary>
       /// 把Unix 时间戳转换成标准时间
       /// </summary>
       /// <param name="timeStamp"></param>
       /// <returns></returns>
        public static DateTime UnixTimeStampToDateTime(string timeStamp)
        {
            //---unix时间戳转换成标准时间---// 
              DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970,1,1));
              long lTime = long.Parse(timeStamp + "0000000");
              TimeSpan toNow = new TimeSpan(lTime);
              DateTime dtResult = dtStart.Add(toNow);
              return dtResult;
           
        }
       /// <summary>
       /// 剩余天数,unixTime 距 当前时间 天数
       /// </summary>
       /// <param name="timestamp"></param>
       /// <returns></returns>

        public static int DifUnixTimeStampLeaveDays(string timestamp)
        {
            int ldays = 0;

            if (!string.IsNullOrEmpty(timestamp))
            {
                try
                {
                    DateTime dt = UnixTimeStampToDateTime(timestamp);
                    TimeSpan span = dt - DateTime.Now;
                    ldays= span.Days;
                }
                catch   { }
               
            }
            return ldays;


            
        
        }
       #endregion





   }
}
