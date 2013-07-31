using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using REST;

    /// <summary>
    /// Summary description for BootLoader
    /// </summary>
public class BootLoader : System.Web.HttpApplication, IHttpModule, IRequiresSessionState 
{
    internal static Routing Routing;

    protected void Application_Start(object sender, EventArgs e)
    {
        Routing = new Routing(System.Web.Routing.RouteTable.Routes);
    }

    protected void Application_BeginRequest(object sender, EventArgs e)
    {
        // IE9 + Facebook fix
        //HttpContext.Current.Response.AddHeader("P3P", "CP=\"DSP LAW NID CURa ADMa DEVa PSAa PSDa OUR IND PUR COM NAV INT CNT LOC\"");

        // Fix for $.ajax jquery posts
        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
    }

    protected void Application_PreRequestHandlerExecute(object sender, EventArgs e)
    {
        RestLoader rl = new RestLoader();
  
        if (rl.RestRequest())
        {
            switch (GetMethod())
            {
                case Method.GET:
                    new GET();
                    break;
                case Method.POST:
                    new POST();
                    break;
                case Method.PUT:
                    new PUT();
                    break;
                case Method.DELETE:
                    new DELETE();
                    break;
                default:
                    Response.Write("ERROR");
                    break;
            }
        }
    }

    protected Method GetMethod()
    {
        try
        {
            return (Method)Enum.Parse(typeof(Method), Request["HTTP_X_HTTP_METHOD_OVERRIDE"].ToUpper());
        }
        catch (NullReferenceException)
        {
            try
            {
                return (Method)Enum.Parse(typeof(Method), Request.Headers["Access-Control-Request-Method"].ToUpper());
            }
            catch (Exception)
            {
                return (Method)Enum.Parse(typeof(Method), Request.HttpMethod.ToUpper());
            }            
        }
    }

    protected void Application_PostRequestHandlerExecute(object sender, EventArgs e)
    {

    }

    protected void Application_EndRequest(object sender, EventArgs e)
    {
        
    }

    protected void Application_End(object sender, EventArgs e)
    {

    }

    protected void Application_Error(object sender, EventArgs e)
    {

    }

    protected void Session_Start(object sender, EventArgs e)
    {
        //Log.Write("session " + Session.SessionID +" started.");
    }

    protected void Session_End(object sender, EventArgs e)
    {
        //Log.Write("session " + Session.SessionID + " ended.");
    }

    public void Init(HttpApplication application)
    {

    }
}