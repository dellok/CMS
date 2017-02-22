using LL.BLL.News;
using LL.Model.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace web.Controllers
{
    public class UsController : BaseController
    {
        #region 关于我们

        [OutputCache(CacheProfile="AboutUS")]
        public ActionResult GetUsDetail(int classid)
        {


            BLLphome_ecms_news bllNews = new BLLphome_ecms_news();

            phome_ecms_news model = bllNews.GetUsDetail(classid);


            if (model != null)
            {
                BuilderMeta(model.title, model.keyboard, model.smalltext);
            }
            else
            {
                model = new phome_ecms_news();
                model.newstext = model.title = "信息不存在！";
            }
            return View(model);

        }
            [OutputCache(CacheProfile = "AboutUS")]
        public ActionResult About()
        {

            int cid = (int)LL.Common.EnumClass.ContactUs.关于我们;
            return this.GetUsDetail(cid);

        }
            [OutputCache(CacheProfile = "AboutUS")]
        public ActionResult Law()
        {

            int cid = (int)LL.Common.EnumClass.ContactUs.法律声明;

            return this.GetUsDetail(cid);

        }
            [OutputCache(CacheProfile = "AboutUS")]
        public ActionResult Contact()
        {

            int cid = (int)LL.Common.EnumClass.ContactUs.联系我们;
            return this.GetUsDetail(cid);

        }
            [OutputCache(CacheProfile = "AboutUS")]
        public ActionResult Link()
        {

            int cid = (int)LL.Common.EnumClass.ContactUs.友情链接;
            return this.GetUsDetail(cid);

        }
        #endregion

    }
}
