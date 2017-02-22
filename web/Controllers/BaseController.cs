using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace web.Controllers
{
    public class BaseController : Controller
    {
        public  void BuilderMeta(string title, string keyword, string description)
        {

            ViewBag.Title = title;
            ViewBag.Keyword = string.IsNullOrEmpty(keyword) ? title : keyword;
            ViewBag.Description = description;

        }


    }
}
