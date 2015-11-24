using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Configuration;
using Nest;
using common;

namespace DAL.Implement
{
    public class KeyWordsDal : IKeyWordsDal
    {
        public List<KeyWords> GetList(string keyword, int start, int size)
        {
            string indexname = ConfigurationManager.AppSettings["TagIndex"].ToString();
            string typename = ConfigurationManager.AppSettings["TagType"].ToString();
            keyword = String.Format("kwname:{0}", keyword);
            var searchResults = Connect.GetSearchClient().Search<KeyWords>(s => s
                .Index(indexname)
                .Type(typename)
                .Query(q => q.QueryString(qs => qs.Query(keyword).DefaultOperator(Operator.And)))
                //.Sort(st => st.Order(SortOrder.Ascending))  /*排序*/
                .From(start)
                .Size(size)
            );
            List<KeyWords> eslist = new List<KeyWords>(searchResults.Documents);
            return eslist;
        }
        /// <summary>
        /// PrefixQuery查询
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="field"></param>
        /// <param name="start"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public List<KeyWords> GetList(string keyword, string field, int start, int size)
        {

            string indexname = ConfigurationManager.AppSettings["TagIndex"].ToString();
            string typename = ConfigurationManager.AppSettings["TagType"].ToString();
            QueryContainer query = new PrefixQuery() { Field = field, Value = keyword };
            var searchResults = Connect.GetSearchClient().Search<KeyWords>(s => s
                .Index(indexname)
                .Type(typename)
                .Query(query)
                .From(start)
                .Size(size)
            );
            List<KeyWords> eslist = new List<KeyWords>(searchResults.Documents);
            return eslist;
        }

        public int GetCount(string keyword)
        {
            int count = 0;
            string indexname = ConfigurationManager.AppSettings["TagIndex"].ToString();
            string typename = ConfigurationManager.AppSettings["TagType"].ToString();
            //调用仅取数量方法
            var counts = Connect.GetSearchClient().Count<KeyWords>(s => s
                .Index(indexname)
                .Type(typename)
                .Query(q => q.QueryString(qs => qs.Query(keyword).DefaultOperator(Operator.And)))
            );
            count = (int)counts.Count;
            return count;
        }
        /// <summary>
        /// PrefixQuery  count
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public int GetCount(string keyword,string field)
        {
            int count = 0;
            string indexname = ConfigurationManager.AppSettings["TagIndex"].ToString();
            string typename = ConfigurationManager.AppSettings["TagType"].ToString();
            QueryContainer query = new PrefixQuery() { Field = field, Value = keyword };
            //调用仅取数量方法
            var counts = Connect.GetSearchClient().Count<KeyWords>(s => s
                .Index(indexname)
                .Type(typename)
                .Query(query)
            );
            count = (int)counts.Count;
            return count;
        }
    }
}
