using common;
using DAL.Interface;
using Model;
using Nest;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL.Implement
{
    public class CommProductDal : ICommProductDal
    {
        public class SearchCondition
        {
            public string[] keywords { get; set; }
            public string[] typenames { get; set; }
            public int start { get; set; }
            public int size { get; set; }
        }
        /// <summary>
        /// 1 
        /// </summary>
        /// <param name="sc"></param>
        /// <returns></returns>
        public string Get(SearchCondition sc)
        {
            string indexname = ConfigurationManager.AppSettings["CRMIndex"].ToString();
            string typename = ConfigurationManager.AppSettings["CRMCommProductType"].ToString();

            //bool
            QueryContainer boolQuery = new BoolQuery() { };
            //must
            List<QueryContainer> mustquerys = new List<QueryContainer>(); 
            //should
            List<QueryContainer> shouldquerys = new List<QueryContainer>();

            foreach (string keyword in sc.keywords)
            {
                #region 拼音 或 中文查询
                string  kw = string.IsNullOrEmpty(keyword) ? "": keyword.ToLower();
                QueryContainer shouldQueryCN = new WildcardQuery() { Field = "fields_query.raw", Value = string.Format("*{0}*", kw) };
                QueryContainer shouldQueryPY = new WildcardQuery() { Field = "fields_query", Value = string.Format("*{0}*", kw) };
                List<QueryContainer> shouldQueryP = new List<QueryContainer>();
                shouldQueryP.Add(shouldQueryCN);
                shouldQueryP.Add(shouldQueryPY);
                QueryContainer bQuery = new BoolQuery() {  Should= shouldQueryP };
                #endregion
                //QueryContainer query = new WildcardQuery() { Field = "fields_query", Value = string.Format("*{0}*", keyword) };  //通配符模糊查询
                mustquerys.Add(bQuery);
            }
            
            if (sc.typenames==null)
            {
                boolQuery = new BoolQuery() { Must = mustquerys };
            }
            else
            {
                QueryContainer booltQuery = new BoolQuery() { };
                foreach (string _typename in sc.typenames)
                {
                    QueryContainer squyers = new TermQuery() { Field = "typename", Value = _typename };
                    shouldquerys.Add(squyers);
                    //QueryContainer mquery = new TermQuery() { Field = "typename", Value = _typename };
                    //mustquerys.Add(mquery);
                }
                booltQuery = new BoolQuery() { Should = shouldquerys };
                mustquerys.Add(booltQuery);
                boolQuery = new BoolQuery() { Must = mustquerys };
            }
                var searchResults = Connect.GetSearchClient().Search<CommProduct>(s => s
                .Index(indexname)
                .Type(typename)
                .Query(boolQuery)
                .Sort(st=>st.OnField(f=>f.Pid))
                .From(sc.start)
                .Size(sc.size == 0 ? 10 : sc.size)
                );
            List<CommProduct> eslist = new List<CommProduct>(searchResults.Documents);
            string json = Obj2Json<CommProduct>(eslist);
            json = Regex.Replace(json, "\\\"", "'").Replace("\\/","/");
            return json;
        }


        private static string Obj2Json<T>(List<T> data)
        {
            try
            {
                System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(data.GetType());
                using (MemoryStream ms = new MemoryStream())
                {
                    serializer.WriteObject(ms, data);
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
