using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

/// <summary>
/// Summary description for Log
/// </summary>
public class Log
{
	public Log()
	{

	}

    public static void Write(string str)
    {
        StreamWriter sw = new StreamWriter(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + "log.txt", true);
        sw.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - " + str);
        sw.Dispose();
        sw.Close();
    }
}