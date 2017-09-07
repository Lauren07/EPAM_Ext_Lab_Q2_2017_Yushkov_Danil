using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FileStorage.Helpers
{
    public static class HtmlExtension
    {
        private static Dictionary<string, string[]> ActionRoles;

        static HtmlExtension()
        {
            ActionRoles = new Dictionary<string, string[]>();
            ActionRoles["ConfirmDelete"] = new[] {"Admin"};
            ActionRoles["EditFile"] = new[] {"Admin", "Moderator"};
        }

        public static MvcHtmlString ActionLinkInnerHtml(this HtmlHelper helper, string actionName, string controllerName, object routeValues = null, object htmlAttributes = null, string innerHtml = null, string outerTag = null)
        {
            if (!UserHasAccess(actionName))
            {
                return MvcHtmlString.Empty;
            }

            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            var url = urlHelper.Action(actionName: actionName, controllerName: controllerName, routeValues: routeValues);

            var builder = new TagBuilder("a");
            builder.InnerHtml = innerHtml;
            builder.MergeAttribute(key: "href", value: url);

            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes), replaceExisting: true);

            if (outerTag != null)
            {
                var newInnerHtml = builder.ToString();
                builder = new TagBuilder(outerTag);
                builder.InnerHtml = newInnerHtml;
            }

            var mvcHtmlString = MvcHtmlString.Create(builder.ToString());
            return mvcHtmlString;
        }

        public static MvcHtmlString LinkInnerHtml(this HtmlHelper helper, string source, object htmlAttributes = null, string innerHtml = null, string outerTag = null)
        {
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);

            var builder = new TagBuilder("a");
            builder.InnerHtml = innerHtml;
            builder.MergeAttribute(key: "href", value: source);

            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes), replaceExisting: true);

            if (outerTag != null)
            {
                var newInnerHtml = builder.ToString();
                builder = new TagBuilder(outerTag);
                builder.InnerHtml = newInnerHtml;
            }

            var mvcHtmlString = MvcHtmlString.Create(builder.ToString());
            return mvcHtmlString;
        }

        private static bool UserHasAccess(string actionName)
        {
            return !ActionRoles.ContainsKey(actionName) || ActionRoles[actionName].Any(role => HttpContext.Current.User.IsInRole(role));
        }
    }
}