using LL.BLL.News;
using LL.Common.Cache;
using LL.Model;
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
    public class MemberController : Controller
    {
        //
        // GET: /Member/

        ArticlesController bllnews = new ArticlesController();
        private string defaultMemberCid = "413";

        public ActionResult Index(string cid, int? page)
        {



            BLLphome_ecms_news bllNews = new BLLphome_ecms_news();

            if (string.IsNullOrEmpty(cid))
            {

                cid = defaultMemberCid;
            }
            return View(bllNews.GetDataList(cid, page, "", ""));

   


        }
        public ActionResult List(string cid, int? page)
        {



            cid = string.IsNullOrEmpty(cid) ? "409" : cid;


            string ps = ConfigManager.GetConfigSettingsValue("pagesize");
            MvcPager pager = new MvcPager();
            int PageSize = string.IsNullOrEmpty(ps) ? 20 : Format.DataConvertToInt(ps);
            int PageIndex = Format.DataConvertToInt(page);

            PageIndex = PageIndex > 0 ? PageIndex : 1;
            PageSize = PageSize > 0 ? PageSize : 10;


            BLLphome_ecms_news bllNews = new BLLphome_ecms_news();

            StringBuilder where = new StringBuilder();

            where.Append(" checked=1 ");
            //是否是父分类

            string strclassid = Format.DataConvertToString(cid);
            if (!string.IsNullOrEmpty(strclassid))
            {
                //判断是否是父分类
                bool isSonClass = Util.IsNumeric(strclassid);


                if (isSonClass)
                {
                    where.AppendFormat("and  classid={0}", strclassid);


                }
                else
                {
                    Regex reg = new Regex(@"[0-9]+");
                    MatchCollection mc = reg.Matches(strclassid);
                    strclassid = mc[0].Value;
                    if (Format.DataConvertToInt(strclassid) > 0)
                    {
                        where.AppendFormat("and  classid in(select classid from phome_enewsclass where bclassid={0})", strclassid);
                    }
                }






                DataSet ds = bllNews.GetTitleList(PageIndex, PageSize, where.ToString(), "");

                int TotalRecords = 0;
                if (ds.Tables[1].Rows.Count > 0)
                {
                    TotalRecords = Format.DataConvertToInt(ds.Tables[1].Rows[0][0]);
                }

                List<phome_ecms_news> arr = bllNews.GetModelListByDataTable(ds.Tables[0]);
                ArrayList a = new ArrayList();
                a.Add(arr);

                pager.PageIndex = PageIndex;
                pager.PageSize = PageSize;
                pager.TotalRecords = TotalRecords;
                pager.NewsCollection = a;
                pager.ClassID = cid;
                pager.KeyWord = "";



            } return View(pager);
        }

        public ActionResult Details(int? id, int? page,string adminview )
        {





            return bllnews.Details(id, page, adminview);


        }


        public IView pager { get; set; }
    }
}
