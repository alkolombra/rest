using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RestLoader
/// </summary>
public class RestLoader : System.Web.UI.Page
{
    internal RestLoader()
	{
		
	}

    internal bool RestRequest()
    {
        try
        {
            if (RouteData.DataTokens["id"].ToString().ToLower() == "rest" || RouteData.DataTokens["id"].ToString().ToLower() == "rest_command")
                return true;

            return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
}