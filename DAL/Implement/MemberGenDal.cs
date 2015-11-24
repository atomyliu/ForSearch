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
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;

namespace DAL.Implement
{
    public class MemberGenDal : IMemberGenDal
    {
        public int GetCount(string keyword)
        {
            return GetCount(keyword, "");
        }

        public int GetCount(string keyword, string field)
        {
            int count = 0;
            string indexname = ConfigurationManager.AppSettings["CRMIndex"].ToString();
            string typename = ConfigurationManager.AppSettings["CRMMemberType"].ToString();
            //QueryContainer query = new QueryStringQuery() { Query = keyword, DefaultOperator = Operator.Or, DefaultField = type };
            //QueryContainer termQuery = new TermQuery { Field = type, Value = keyword };
            //QueryContainer prefixQuery = new PrefixQuery { Field = type, Value = keyword };
            if (string.IsNullOrEmpty(field))
            { field = "_all"; }
            else { field = field.ToLower(); }
            QueryContainer matchQuery = new MatchQuery() { Field = field, Query = keyword, Operator = Operator.And };
            //调用仅取数量方法
            var counts = Connect.GetSearchClient().Count<Member>(s => s
                .Index(indexname)
                .Type(typename)
                .Query(matchQuery)
            );
            count = (int)counts.Count;
            return count;
        }

        public IEnumerable<string> GetIDs(string keyword, int start, int size)
        {
            return GetIDs(keyword,"", start, size);
        }

        public IEnumerable<string>  GetIDs(string keyword, string field, int start, int size)
        {
            string indexname = ConfigurationManager.AppSettings["CRMIndex"].ToString();
            string typename = ConfigurationManager.AppSettings["CRMMemberType"].ToString();
            //QueryContainer query = new QueryStringQuery() { Query = keyword, DefaultOperator = Operator.Or, DefaultField = type};
            //QueryContainer termQuery = new TermQuery { Field = type, Value = keyword };
            //QueryContainer prefixQuery = new PrefixQuery { Field = type, Value = keyword };
            if (string.IsNullOrEmpty(field))
            { field = "_all"; }
            else { field = field.ToLower(); }
            QueryContainer matchQuery = new MatchQuery() { Field = field, Query = keyword, Operator = Operator.And };
            var searchResults = Connect.GetSearchClient().Search<Member>(s => s
                .Index(indexname)
                .Type(typename)
                .Query(matchQuery)
                .Fields(f=>f.Id)
                //.Sort(st => st.OnField(f => f.newsid).Order(SortOrder.Descending))  /*按ID排序，id为数字，排序正常*/
                .From(start)
                .Size(size)
            );
            //List<Member> eslist = new List<Member>(searchResults.Documents);
            List<string> eslist = new List<string>();
            foreach (var hit in searchResults.Hits)
            {
                eslist.Add(hit.Id);
            }
            return eslist;
            //return eslist.Select(s=>s.Id);
        }
        public byte[] GetIDsM(string keyword, string field, int start, int size)
        {
            return GZip.Compress(GZip.SerializeObject(GetIDs(keyword, field, start, size).ToList()));
        }

    }
}
