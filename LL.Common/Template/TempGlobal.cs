using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LL.Common.Template
{
  public   class TempGlobal
    {


        public static string Regular_Loop = @"\[e:loop={(.*)}\](.*[^\[\/e:loop\]].*)";
        public static string Regular_Info = @"\[info\](.*)\[\/info\]";
        public static string Regular_News = @"\[news\](.*)\[\/news\]";




      Dictionary<string, string> dic = new Dictionary<string, string>();

      public Dictionary<string, string> GetGlobalDic()
      {
          dic["[!--news.url--]"] = "http://www.lenglian.org.cn/";
          return dic;
      }




    public string    ELoop()
    {



        return "";
    }


        /*   
         *   "[!--info.vote--]"  顶一下
             "[!--page.url--]"   分页
         * [e:loop={264,2,0,1}]
        <a href="<?=$bqsr[titleurl]?>" target="_blank"><img src="<?=$bqr[titlepic]?>" alt="<?=$bqr[title]?>" width="120" height="170" border="0" /></a>
        [/e:loop]
        */

    }
}
