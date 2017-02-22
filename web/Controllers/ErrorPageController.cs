using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace web.Controllers
{
    public class ErrorPageController : Controller
    {
        //
        // GET: /ErrorPage/
      
      

      
        public ActionResult Index(int  code=0,string  msg="")
        {
            Response.StatusCode =  code;
            ViewBag.Msg = msg;
            return View();
        }

    }
}
