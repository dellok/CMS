using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

          
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.RouteExistingFiles = true;
            /* routes.MapRoute(
             name: "ArticlesDetails2",
             url: "Articles/{id}.html/{page}",
             defaults: new { controller = "Articles", action = "Details", page = UrlParameter.Optional }
             );*/

            routes.MapRoute(
                name: "ArticlesDetails",
                url: "Articles/{id}/{page}",
                defaults: new { controller = "Articles", action = "Details",page=UrlParameter.Optional}
                );

            routes.MapRoute(
            name: "about",
            url: "us/about",
            defaults: new { controller = "Us", action = "About", page = UrlParameter.Optional }
            );

            routes.MapRoute(
         name: "law",
         url: "us/law",
         defaults: new { controller = "Us", action = "Law", page = UrlParameter.Optional }
         );

            routes.MapRoute(
         name: "contact",
         url: "us/contact",
         defaults: new { controller = "Us", action = "Contact", page = UrlParameter.Optional }
         );
            routes.MapRoute(
name: "link",
url: "us/link",
defaults: new { controller = "Us", action = "Link", page = UrlParameter.Optional }
);


            routes.MapRoute(
                name: "zh",
                url: "ZhanHui/",

                defaults: new { controller = "ZhanHui",action="Index" }


                );

            //培训 

            routes.MapRoute(
                name:"peixun",
                url:"PeiXun/{id}",
                defaults:new { controller="PeiXun",action="Detail"}
                
                );

            routes.MapRoute(
           name: "ErrorPage",
           url: "ErrorPage/{code}/{msg}",
           defaults: new { controller = "ErrorPage", action = "Index", code = UrlParameter.Optional, msg = UrlParameter.Optional }

           );

            routes.MapRoute(

                name: "ArticlesList",
                url: "{cname}-{classid}/{page}",
                defaults: new { controller = "Articles", action = "List", p = UrlParameter.Optional, page = UrlParameter.Optional }


                );
            routes.MapRoute(
                name: "sk",
                url: "search/{keyword}/{page}",
                defaults: new { controller = "Articles", action = "List",page=UrlParameter.Optional }
                
                );






            routes.MapRoute(
                name: "list",
                url: "Member/List/{cid}/{page}",
                defaults: new { controller = "Member", action = "List", page = UrlParameter.Optional }

            );



            routes.MapRoute(
                name: "Demmmt",
                url: "Member/Index/{cid}/{page}",
                defaults: new { controller = "Member", action = "Index", page= UrlParameter.Optional ,cid="413"}
             
            );




            routes.MapRoute(
           "workgroup",
     "Workgroup/{cid}/{page}",
           new { controller = "Workgroup", action = "Index", page = UrlParameter.Optional, cid = "423" },
          new { cid= @"\d{1,10}" }


      );   

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

           


        }
    }
}