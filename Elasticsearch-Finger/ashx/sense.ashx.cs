using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elasticsearch_Finger.ashx
{
    /// <summary>
    /// sense 的摘要说明
    /// </summary>
    public class sense : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("\\sense\\index.html");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}