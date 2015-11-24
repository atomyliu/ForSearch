using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Nest;
using Model;
using DAL.Interface;
using common;

namespace DAL.Implement
{
    public class URLNameDal : IURLNameDal
    {
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <param name="start">起始位置</param>
        /// <param name="size">分页大小</param>
        /// <returns>list</returns>
        public List<URLName> GetList(string keyword, int start, int size)
        {
            string indexname = ConfigurationManager.AppSettings["CCodeIndex"].ToString();
            string typename = ConfigurationManager.AppSettings["CCodeType"].ToString();
            keyword = String.Format("urlname:{0}", keyword);
            var searchResults = Connect.GetSearchClient().Search<URLName>(s => s
                .Index(indexname)
                .Type(typename)
                .Query(q => q.QueryString(qs => qs.Query(keyword).DefaultOperator(Operator.And)))
                .From(start)
                .Size(size)
                .Highlight(h=>h
                    .OnFields(f => f
                        .OnField(e => e.Urlname)
                        .PreTags("<em>")
                        .PostTags("</em>"))
                        )
            );
            var hllist = searchResults.Highlights; //高亮部分的list，还不知道怎么用
            List<URLName> eslist = new List<URLName>(searchResults.Documents);
            return eslist;
        }
        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <returns>总数</returns>
        public int GetCount(string keyword)
        {
            int count = 0;
            string indexname = ConfigurationManager.AppSettings["CCodeIndex"].ToString();
            string typename = ConfigurationManager.AppSettings["CCodeType"].ToString();
            keyword = String.Format("urlname:{0}", keyword);
            //调用仅取数量方法
            var counts = Connect.GetSearchClient().Count<URLName>(s => s
                .Index(indexname)
                .Type(typename)
                .Query(q => q.QueryString(qs => qs.Query(keyword).DefaultOperator(Operator.And)))
            );
            count = (int)counts.Count;
            return count;
        }
    }
}
