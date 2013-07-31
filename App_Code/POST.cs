using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using REST;

/// <summary>
/// Summary description for POST
/// </summary>
public class POST : Modules.POST
{
	public POST()
	{
        foreach (Param param in Params)
        {
            Log.Write(param.Key + "=" + param.Value);
        }
	}
}