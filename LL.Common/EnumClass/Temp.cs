using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LL.Common.EnumClass
{
    public class Temp
    {

        public enum TempType
        { 
              首页=0,
              封面模板=1,
              列表模板=2,
              内容模板=3
              
        
        }


        /// <summary>
        /// 对就数据中tmpename =tempid
        /// </summary>
        public enum TempListName
        {
            默认新闻列表模板 = 1,
            默认下载列表模板 = 2,
            默认图片列表模板 = 3,
            默认FLASH列表模板 = 4,
            默认电影列表模板 = 5,
            默认商城列表模板 = 6,
            默认文章列表模板 = 7,
            分类信息默认列表模板 = 8,
            冷链首页 = 9,
            列表模板news = 10,
            公司库列表模板 = 11
        }



        public enum TempleteType
        {

            模板变量,
            分类模板,
            内容模板,
            封面模板,

        }


        /// <summary>
        /// 系统模型
        /// </summary>
        public enum TempSys
        { 
        新闻系统=1,
        公司系统=9
        
        }
    }
}
