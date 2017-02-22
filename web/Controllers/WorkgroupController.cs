using LL.BLL.News;
using LL.Common.Cache;
using LL.Model.News;
using Project.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using web.Models;

namespace web.Controllers
{
    public class WorkgroupController : Controller
    {
        //
        // GET: /Member/

        ArticlesController bllnews = new ArticlesController();
        private string defaultMemberCid = "423";

        public ActionResult Index(string cid, int? page)
        {




            BLLphome_ecms_news bllNews = new BLLphome_ecms_news();
            if (string.IsNullOrEmpty(cid))
            {

                cid = defaultMemberCid;
            }
            return View(bllNews.GetDataList(cid, page, "", "befrom"));

   


        }

        public ActionResult Details(int? id, int? page,string adminview )
        {

            return bllnews.Details(id, page, adminview);


        }


    }
}
