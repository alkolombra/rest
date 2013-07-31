using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST
{
    public enum Method
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    public enum RpcType
    {
        UrlParams,
        Xml,
        Json
    }

    public struct Param
    {
        public string Key;
        public string Value;
    }
}