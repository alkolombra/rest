using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
using REST;

public class RestEngine : System.Web.UI.Page
{
    internal HttpApplicationState Application;
    internal HttpRequest Request;
    internal HttpResponse Response;
    internal HttpSessionState Session;

    internal Method HttpMethod = Method.GET;
    internal RpcType RpcType;

    private List<Param> _Params;
    internal List<Param> Params
    {
        get
        {
            return _Params;
        }
    }

    public RestEngine()
    {
        this.Application = HttpContext.Current.Application;
        this.Request = HttpContext.Current.Request;
        this.Response = HttpContext.Current.Response;
        this.Session = HttpContext.Current.Session;

        HttpMethod = GetMethod();

        RpcType = Routing.GetType(Request);

        CollectParametersData();       
    }

    private void CollectParametersData()
    {
        _Params = new List<Param>();
        System.Collections.Specialized.NameObjectCollectionBase.KeysCollection keys = HttpMethod == Method.GET ? this.Request.QueryString.Keys : this.Request.Form.Keys;

        Param param;
        foreach (string key in keys)
        {
            param = new Param();
            param.Key = key;
            param.Value = Request[key].ToString();
            _Params.Add(param);
        }
    }

    private Method GetMethod()
    {
        try
        {
            return (Method)Enum.Parse(typeof(Method), Request["HTTP_X_HTTP_METHOD_OVERRIDE"].ToUpper());
        }
        catch (NullReferenceException)
        {
            return (Method)Enum.Parse(typeof(Method), Request.HttpMethod.ToUpper());
        }
    }
}
