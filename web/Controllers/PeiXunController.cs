using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LL.BLL.News;
using System.Data;
using LL.Common.Cache;
using LL.Model.News;
namespace web.Controllers
{
    public class PeiXunController : Controller
    {

        [OutputCache(CacheProfile ="Index")]
        public ActionResult Index()
        {
            List<List<phome_ecms_news>> arr = new List<List<phome_ecms_news>>();
            BLLphome_ecms_news bllNews = new BLLphome_ecms_news();
            DataSet ds = bllNews.GetDataBySpName(ConfigManager.GetConfigSettingsValue("SP_PeiXun_Index"));

            if (ds.Tables.Count>0 &&  ds.Tables.Count==5)
            {
                arr = new List<List<phome_ecms_news>>();
                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    arr.Add(bllNews.GetModelListByDataTable(ds.Tables[i]));
                }

            }

            if (arr.Count>0)
            {
                return View(arr);
            }
            else
            {
                return RedirectToAction("Index", "ErrorPage",new { code=500,msg="培训首页数据为空！"});

            }
            

            
        }
    }
}
