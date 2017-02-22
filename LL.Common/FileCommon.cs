using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace LL.Common
{
  public   class FileCommon
    {
      /// <summary>
      /// 判断目录，如果没有则生成
      /// </summary>
      /// <param name="dir"></param>
      public static bool  ExistsDirAndCreateDir(string dir)
      {
          return ExistsDir(dir,true);
      }
      public static bool ExistsDir(string dir)
      {
          return ExistsDir(dir, false);

      }
      public static bool  ExistsDir(string dir, bool isCreateDir)
      {
          bool isHave = Directory.Exists(dir);
          if (isCreateDir)
          {
              Directory.CreateDirectory(dir);
          }
          return isHave;
      }


      /// <summary>
      /// 写文件，
      /// FileMode.OpenOrCreate
      /// </summary>
      /// <param name="fileNamePath"></param>
      /// <param name="text"></param>
      public static string  CreateFile(string fileNamePath, string text)
      {

          string msg = "生成成功!";
          try
          {
              FileStream fs = new FileStream(fileNamePath, FileMode.Create);

           
              
              StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding("gb2312"));

              
              sw.Write(text);
              sw.Close();
              sw.Dispose();
              fs.Close();
              

          }
          catch (Exception ee)
          {

              msg = string.Format("生成文件:【{0}】错误,原因:【Source:{1},Message:{2}】",fileNamePath,ee.Source,ee.Message);
          }
          return msg;
      }

      public static string DelFile(string fileNamePath)
      {

          string msg = "删除成功!";
          try
          {

              FileInfo f = new FileInfo(fileNamePath);

         
              if (f.Exists)
              {
                  f.Delete();
              }


          }
          catch (Exception ee)
          {

              msg = string.Format("删除文件:【{0}】错误,原因:【Source:{1},Message:{2}】", fileNamePath, ee.Source, ee.Message);
          }
          return msg;
      }



   

    }
}
