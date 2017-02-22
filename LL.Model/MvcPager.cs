using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LL.Model.News;

namespace LL.Model
{
    /// <summary>
    /// 分页类型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MvcPager
    {
        private int pindex=1;
        private int psize=20;
        private int maxpagesize = 100;

        public int PageIndex { 
            get{ return pindex;} 
            set { if (value >0) { pindex=value; } }
        
        }
        public int PageSize { get{return psize; }
            set { if (value > 0 && value < maxpagesize) { psize = value; } }
        }

        public ArrayList  NewsCollection { get; set; }
        public string KeyWord { get;set;}
        public int TotalRecords { get; set; }
        public string OrderBy { get; set; }
        public string Where { get; set; }
        public string  ClassID { get; set; }
 
    }
}