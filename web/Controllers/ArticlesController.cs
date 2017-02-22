using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using LL.BLL.News;
using LL.Common;
using LL.Model.News;
using Project.Common;
using web.Models;
using LL.Model;
using LL.Common.Cache;
using System.Text.RegularExpressions;
namespace web.Controllers
{
    public class ArticlesController : BaseController
    {

        public ActionResult Index()
        {
            return View();
        }


        #region  新闻列表
        [OutputCache(CacheProfile="List")]
        public ActionResult List(string classid, int? page,string  keyword)
        {
            BLLphome_ecms_news bllNews = new BLLphome_ecms_news();

            return View(bllNews.GetDataList(classid, page, keyword, ""));

        }





        #endregion
              [OutputCache(CacheProfile = "Detail")]
        public ActionResult Print(int id)
        {
            return Details(id, -99, "");
        }

        //
        // GET: /Articles/
        //    /Articles/

              [OutputCache(CacheProfile = "Detail")]
        public ActionResult Details(int? id, int? page, string adminview)
        {

            int id2 = Format.DataConvertToInt(id);
            BLLphome_ecms_news bllNews = new BLLphome_ecms_news();
            phome_ecms_news model = bllNews.GetModel(id2);


            if (model != null)
            {

                if (!string.IsNullOrEmpty(adminview))
                {
                    if (model != null)
                    {
                        model.@checked = 1;
                    }
                }


                if (model.@checked > 0)
                {

                    string content = model.newstext;

          
                    string pagestr = "";
                    page = page!=null ? page : -1;
                    if (page != -99)
                    {
                        FckeditorPage.ArticlePage(id2, Format.DataConvertToInt(page), ref content, ref pagestr, false);
                    }

                    model.newstext = content;
                    model.ztid = pagestr;
                    //临时解决方案

                    BuilderMeta(model.title, model.keyboard, model.smalltext);


                }
                else
                {



                    model.newstext = model.title = "信息还没有通过审核！";

                }

               
            }


            else
            {
                model = new phome_ecms_news();
                model.newstext = model.title = "信息不存在！";


            }
            //  return RedirectPermanent("/Articles/Lost");

            return View(model);
        }





    //   [ChildActionOnly]
      //  [OutputCache(CacheProfile = "PartialList")]
        public PartialViewResult ArticlesBlock(int classid, int top, string orderby)
        {

            BLLphome_ecms_news bllNews = new BLLphome_ecms_news();
            DataSet ds = bllNews.GetTopTitleByClassID(top, classid.ToString(), orderby);
            List<phome_ecms_news> arr = bllNews.GetModelListByDataTable(ds.Tables[0]);
            return PartialView(arr);
        }


      

    }
}
