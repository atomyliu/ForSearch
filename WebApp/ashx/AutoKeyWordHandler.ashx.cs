using Model;
using Service.Implement;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using WebApp.AutoKeyWordServ;
using WebApp.NewsBaseServ;

namespace WebApp.ashx
{
    /// <summary>
    /// AutoKeyWordHandler 的摘要说明
    /// </summary>
    public class AutoKeyWordHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string query = context.Request.QueryString["term"];
            //AutoKeyWordServClient aksc = new AutoKeyWordServClient();
            IKeyWordsService ikws = new KeyWordsService();
            //NewsBaseServClient nbsc = new NewsBaseServClient();
            INewsBaseService inbs = new NewsBaseService();
            int size = 10;
            string type = "kwname";
            List<KeyWords> list = ikws.GetList(query, type, 0, size);
            int count = list.Count();
            StringBuilder builder = new StringBuilder();
            builder.Append("[");
            for (int i = 0; i < count; i++)
            {
                builder.Append("{\"value\":\"");
                builder.Append(list[i].Kwname);
                builder.Append("\",\"label\":\"");
                builder.Append("<div style='float:left;'>");
                builder.Append(list[i].Kwname);
                builder.Append("</div>");
                builder.Append("<div style='float:right;'>");
                builder.Append(inbs.GetCount(list[i].Kwname));
                builder.Append("条1</div>");
                builder.Append("\"},");
            }
            if (builder.Length > 1)
                builder.Length = builder.Length - 1;
            builder.Append("]");

            context.Response.ContentType = "text/javascript";
            context.Response.Write(builder.ToString());
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