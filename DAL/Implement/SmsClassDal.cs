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
    public class SmsClassDal : ISmsClassDal
    {
        public int GetCount(string keyword)
        {
            int count = 0;
            string indexname = ConfigurationManager.AppSettings["CRMIndex"].ToString();
            string typename = ConfigurationManager.AppSettings["SmsClassType"].ToString();
            keyword = String.Format("{0}:{1}", "Title", keyword);
            //调用仅取数量方法
            var counts = Connect.GetSearchClient().Count<SmsClass>(s => s
                .Index(indexname)
                .Type(typename)
                .Query(q => q.QueryString(qs => qs.Query(keyword).DefaultOperator(Operator.And)))
            );
            count = (int)counts.Count;
            return count;
        }

        public int GetCount(string keyword, string type)
        {
            int count = 0;
            string indexname = ConfigurationManager.AppSettings["CRMIndex"].ToString();
            string typename = ConfigurationManager.AppSettings["SmsClassType"].ToString();
            if (!string.IsNullOrEmpty(type))
            { keyword = String.Format("{0}:{1}", type, keyword); }
            //调用仅取数量方法
            var counts = Connect.GetSearchClient().Count<SmsClass>(s => s
                .Index(indexname)
                .Type(typename)
                .Query(q => q.QueryString(qs => qs.Query(keyword).DefaultOperator(Operator.And)))
            );
            count = (int)counts.Count;
            return count;
        }

        public List<SmsClass> GetList(string keyword, int start, int size)
        {
            string indexname = ConfigurationManager.AppSettings["CRMIndex"].ToString();
            string typename = ConfigurationManager.AppSettings["SmsClassType"].ToString();
            keyword = String.Format("{0}:{1}", "Title", keyword);
            var searchResults = Connect.GetSearchClient().Search<SmsClass>(s => s
                .Index(indexname)
                .Type(typename)
                .Query(q => q.QueryString(qs => qs.Query(keyword).DefaultOperator(Operator.And)))
                //.Sort(st => st.OnField(f => f.newsid).Order(SortOrder.Descending))  /*按ID排序，id为数字，排序正常*/
                .From(start)
                .Size(size)
            );
            List<SmsClass> eslist = new List<SmsClass>(searchResults.Documents);
            return eslist;
        }

        public List<SmsClass> GetList(string keyword, string type, int start, int size)
        {
            string indexname = ConfigurationManager.AppSettings["CRMIndex"].ToString();
            string typename = ConfigurationManager.AppSettings["SmsClassType"].ToString();
            if (!string.IsNullOrEmpty(type))
            { keyword = String.Format("{0}:{1}", type, keyword); }

            var searchResults = Connect.GetSearchClient().Search<SmsClass>(s => s
                .Index(indexname)
                .Type(typename)
                .Query(q => q.QueryString(qs => qs.Query(keyword).DefaultOperator(Operator.And)))
                //.Sort(st => st.OnField(f => f.newsid).Order(SortOrder.Descending))  /*按ID排序，id为数字，排序正常*/
                .From(start)
                .Size(size)
            );
            List<SmsClass> eslist = new List<SmsClass>(searchResults.Documents);
            return eslist;
        }
    }
}
