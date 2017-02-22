using LL.BLL.News;
using LL.Model.News;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace web.Controllers
{
    public class ZhanHuiController : BaseController
    {

           [OutputCache(CacheProfile = "List")]
        public ActionResult Index()
        {
            List<List<phome_ecms_news>> arr = new List<List<phome_ecms_news>>();
            BLLphome_ecms_news bllNews = new BLLphome_ecms_news();
            DataSet ds = bllNews.GetIndexZhanHuiList();
            for (int i = 0; i < ds.Tables.Count; i++)
            {
                arr.Add(bllNews.GetModelListByDataTable(ds.Tables[i]));
            }


            return View("index", arr);
        }


    }
}
