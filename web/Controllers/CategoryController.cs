using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LL.BLL.News;
using LL.Model.News;
namespace web.Controllers
{
    public class CategoryController : Controller
    {



        [ChildActionOnly]  
        public PartialViewResult CategoryName(int classid)
        {

            BLLphome_enewsclass bll = new BLLphome_enewsclass();
            phome_enewsclass  model  = bll.GetModelByCache(classid);
           return  PartialView(model);
        
        }

        [ChildActionOnly]
        public PartialViewResult CategoryUrlPath(int classid)
        {
            BLLphome_enewsclass bll = new BLLphome_enewsclass();
            List<phome_enewsclass> nodes = bll.GetClassNodePath(classid);
            return PartialView(nodes);
        
        }

        //
        // GET: /Category/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Category/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Category/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Category/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Category/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Category/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Category/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Category/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
