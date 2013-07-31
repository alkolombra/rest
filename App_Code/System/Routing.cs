using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

    /// <summary>
    /// Summary description for Routing
    /// </summary>
public class Routing
{
    internal System.Web.Routing.RouteCollection Routes;

    public Routing(RouteCollection routes)
    {
        Routes = routes;
        Routes.Ignore("{resource}.axd/{*pathInfo}");

        Route route;

        route = Routes.MapPageRoute("rest", "rest", "~/Rest.aspx");
        route.DataTokens = new RouteValueDictionary();
        route.DataTokens.Add("id", "rest");
        route.DataTokens.Add("action", "rest");

        route = Routes.MapPageRoute("rest_command", "rest/{command}", "~/Rest.aspx");
        route.DataTokens = new RouteValueDictionary();
        route.DataTokens.Add("id", "rest_command");
        route.DataTokens.Add("action", "rest_command");
    }

    internal static REST.RpcType GetType(HttpRequest Request)
    {
        try
        {
            if (Request["output"].ToString().ToLower() == "xml")
            {
                return REST.RpcType.Xml;
            }
            else
            if (Request["output"].ToString().ToLower() == "json")
            {
                return REST.RpcType.Json;
            }
            else
            {
                return REST.RpcType.UrlParams;
            }
        }
        catch (Exception)
        {
            return REST.RpcType.UrlParams;
        }
    }
}