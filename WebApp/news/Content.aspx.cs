using Nest;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.news
{
    public partial class Content : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["_id"];
            //Response.Write(Server.UrlDecode(id));
            List<NewsBase> list = SearchList(id);

            dataRepeater.DataSource = list;
            dataRepeater.DataBind();
        }
        public class NewsBase
        {
            [ElasticProperty(AddSortField = true)]
            public string newsid { get; set; }
            public string title { get; set; }
            public string content { get; set; }
            public DateTime PubDate { get; set; }
            public string createon { get; set; }
        }
        public static List<NewsBase> SearchList(string nid)
        {
            string espath = ConfigurationManager.AppSettings["ESPath"].ToString();
            string indexname = ConfigurationManager.AppSettings["IndexName"].ToString();
            string typename = ConfigurationManager.AppSettings["TypeName"].ToString();
            var node = new Uri(espath);
            var settings = new ConnectionSettings(node);
            var client = new ElasticClient(settings);
            //keyword = String.Format("*{0}*", keyword);
            var searchResults = client.Search<NewsBase>(s => s
                .Index(indexname)
                .Type(typename)
                .Query(q => q.QueryString(qs => qs.Query(nid).DefaultOperator(Operator.And)))
                .Sort(st => st.OnField(f => f.newsid).Order(SortOrder.Descending))  /*按ID排序，id为数字，排序正常*/
                //.Sort(st=>st.OnField(f=>f.PubDate.Suffix("sort")).Descending())   /*按时间排序，时间格式，排序bug；中文字符串bug*/
                .From(0)
                .Size(1)
            );
            List<NewsBase> eslist = new List<NewsBase>(searchResults.Documents);
            //foreach (var data in searchResults.Documents)
            //{
            //    eslist.Add(data);
            //}
            return eslist;
        }
    }
}