using System.Web.Optimization;

namespace WebApplication
{
    public class BundleConfig
    {
        //Дополнительные сведения об объединении см. по адресу: http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/jquery.validate.unobtrusive.min.js",
                        "~/Scripts/jquery.validate.unobtrusive.bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/autocomplete")
                        .Include("~/Scripts/jquery.easy-autocomplete.min.js")
                        .Include("~/Scripts/autocompleteProducts.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/PagedList.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/autocompleteCss")
                .Include("~/Content/easy-autocomplete.min.css")
                .Include("~/Content/easy-autocomplete.themes.min.css"));
        }
    }
}
