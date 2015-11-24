using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL.Interface;
using System.Configuration;
using Nest;
using Elasticsearch.Net.ConnectionPool;
using common;

namespace DAL.Implement
{
    public class NewsBaseDal : INewsBaseDal
    {
        /// <summary>
        /// 搜索NewsBase
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <param name="size">分页</param>
        /// <param name="srart">分页起始位置</param>
        /// <returns></returns>
        public List<NewsBase> GetList(string keyword, int start, int size)
        {
            List<NewsBase> eslist = GetList(keyword,"title",start,size);
            return eslist;
        }

        public List<NewsBase> GetList(string keyword, string field, int start, int size)
        {
            string indexname = ConfigurationManager.AppSettings["IndexName"].ToString();
            string typename = ConfigurationManager.AppSettings["TypeName"].ToString();
            if (string.IsNullOrEmpty(field))
            { field = "_all";}
            QueryContainer matchQuery = new MatchQuery() { Field = field, Query = keyword,Operator=Operator.And };
            //QueryContainer querystring = new QueryStringQuery() { Query = keyword, DefaultOperator = Operator.And };
            var searchResults = Connect.GetSearchClient().Search<NewsBase>(s => s
                .Index(indexname)
                .Type(typename)
                .Query(matchQuery)
                //.Fields("newsid")
                .Sort(st => st.OnField(f => f.Newsid).Order(SortOrder.Descending))  /*按ID排序，id为数字，排序正常*/
                .From(start)
                .Size(size)
                //.Highlight(h => h
                //     .OnFields(f => f
                //        .OnField("*")
                //        .PreTags("<b style='color:red'>")
                //        .PostTags("</b>")))
            );
            List<NewsBase> eslist = new List<NewsBase>(searchResults.Documents);
            return eslist;
        }


        /// <summary>
        /// 获取查询条件的总数量
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="start"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public int GetCount(string keyword)
        {
            int count = 0;
            count = GetCount(keyword,"title");
            return count;
        }
        public int GetCount(string keyword,string type )
        {
            int count = 0;

           
            string indexname = ConfigurationManager.AppSettings["IndexName"].ToString();
            string typename = ConfigurationManager.AppSettings["TypeName"].ToString();
            if (string.IsNullOrEmpty(type))
            {
                type = "_all";
            }
            QueryContainer matchQuery = new MatchQuery() { Field = type, Query = keyword, Operator = Operator.And };
            QueryContainer querystring = new QueryStringQuery() { Query = keyword, DefaultOperator = Operator.And };
            //调用仅取数量方法
            var counts = Connect.GetSearchClient().Count<NewsBase>(s => s
                .Index(indexname)
                .Type(typename)
                .Query(matchQuery)
            );
            count = (int)counts.Count;
            return count;
        }
    }
}
