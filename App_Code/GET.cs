using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using REST;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using System.IO;

/// <summary>
/// Summary description for GET
/// </summary>
public class GET : Modules.GET
{
	public GET()
	{
        foreach (Param param in Params)
        {
            Response.Write(param.Key + "=" + param.Value + "&");
        }

        //StringBuilder sb = new StringBuilder();
        //StringWriter sw = new StringWriter(sb);
        //JsonWriter jsonWriter = new JsonTextWriter(sw);

        //jsonWriter.Formatting = Formatting.Indented;
       
        //jsonWriter.WriteStartObject();
        //jsonWriter.WritePropertyName("Name");
        //jsonWriter.WriteValue("Allan");
        //jsonWriter.WritePropertyName("Email");
        //jsonWriter.WriteValue("Allan@");
        //jsonWriter.WriteEndObject();

        //jsonWriter.WriteStartObject();
        //jsonWriter.WritePropertyName("Name");
        //jsonWriter.WriteValue("Sahar");
        //jsonWriter.WriteEndObject();

        //string output = sw.ToString();
        //jsonWriter.Close();
        //sw.Close();

        //Response.Write(Session.SessionID);
        //Response.Write("this is a GET request for the REST (" + RpcType.ToString() + ")");
        Response.Write("OK");
	}
}