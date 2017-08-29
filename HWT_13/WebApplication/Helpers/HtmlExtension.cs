using System.Web.Mvc;
using System.Web.Routing;


namespace HWT_13.Helpers
{
    public static class HtmlExtension
    {
        public static MvcHtmlString ActionLinkInnerHtml(this HtmlHelper helper, string actionName, string controllerName, object routeValues = null, object htmlAttributes = null, string innerHtml = null)
        {
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            var url = urlHelper.Action(actionName: actionName, controllerName: controllerName, routeValues: routeValues);

            var builder = new TagBuilder("a");
            builder.InnerHtml = innerHtml;
            builder.MergeAttribute(key: "href", value: url);

            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes), replaceExisting: true);

            var mvcHtmlString = MvcHtmlString.Create(builder.ToString());
            return mvcHtmlString;
        }
    }
}