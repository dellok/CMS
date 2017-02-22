using System.Web;
using System.Web.Optimization;

namespace web
{
    public class BundleConfig
    {
        private static bool  DEBUGE=true;
        // 有关 Bundling 的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {


            if (!DEBUGE)
            {
                BundleTable.EnableOptimizations = true;
            }



            bundles.Add(new StyleBundle("~/css").Include("~/content/slide.css","~/content/site.css","~/content/pager.css"));
            bundles.Add(new StyleBundle("~/css/peixun").Include("~/content/peixun.css"));


            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery/jquery-{version}.js"));

           // bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include("~/Scripts/jquery/jquery-ui-{version}.js"));

           // bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include( "~/Scripts/jquery/jquery.unobtrusive*","~/Scripts/jquery/jquery.validate*"));


            bundles.Add(new ScriptBundle("~/bootstrap/css").Include("~/plugin/bootstrap/3.3.7/bootstrap.css"));
            bundles.Add(new ScriptBundle("~/bootstrap/script").Include("~/plugin/bootstrap/3.3.7/bootstrap.js"));


            bundles.Add(new ScriptBundle("~/jquery/1.9.1").Include("~/Scripts/jquery/jquery-1.9.1.js"));
            bundles.Add(new ScriptBundle("~/jquery/1.7.1").Include("~/Scripts/jquery/jquery-1.7.1.js"));



            /**首页要用的js**/
            bundles.Add(new ScriptBundle("~/common/script").Include("~/scripts/common.js"));



            bundles.Add(new ScriptBundle("~/scripts/index").
                Include(
                "~/Scripts/jquery/jquery-1.9.1.js",
                "~/Scripts/jquery/jquery.SuperSlide.js",
                "~/scripts/common.js" ));

        

            // 使用 Modernizr 的开发版本进行开发和了解信息。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            





        }

       
    }
}