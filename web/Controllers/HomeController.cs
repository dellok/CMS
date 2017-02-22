using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LL.BLL.News;
using LL.Model.News;
namespace web.Controllers
{
    public class HomeController : BaseController
    {

        [OutputCache(CacheProfile="Index")]
        public ActionResult Index()
        {
            List<List<phome_ecms_news>> arr = new List<List<phome_ecms_news>>();
            BLLphome_ecms_news bllNews = new BLLphome_ecms_news();
            DataSet ds = bllNews.GetIndexTitleList();
            for (int i = 0; i < ds.Tables.Count; i++)
            {
                arr.Add(bllNews.GetModelListByDataTable(ds.Tables[i]));
            }
      

            return View("Index", arr);
        }




    }
}
