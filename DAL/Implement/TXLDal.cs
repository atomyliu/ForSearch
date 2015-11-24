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
    public class TXLDal : ITXLDal
    {
        public class SearchCondition
        {
            public string keyword { get; set; } //关键字
            public string field { get; set; } //模糊查询字段名,默认
            public string pattern { get; set; } //查询方式,空则模糊,0高级 1子表
            public int start { get; set; }
            public int size { get; set; }
            public string eid { get; set; } //工号
            public string r { get; set; }  //realname
            public string i { get; set; } //innernum
            public string e { get; set; } //emailaddress
            public string d { get; set; } //departmentstr
            public string dm { get; set; } //dutymemo
            public string p { get; set; } //Purview
            public string status { get; set; }
            public string pn { get; set; } //phonenum
            public string depid { get; set; } //department id
        }

        /// <summary>
        /// 搜索通讯录,通过判断keyword是字符串还是数字来确认是直接查询还是父子查询
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="field"></param>
        /// <param name="start"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public string Get(string keyword, string field, int start, int size)
        {
            string indexname = ConfigurationManager.AppSettings["TXLIndex"].ToString();
            string typename = ConfigurationManager.AppSettings["TXLType"].ToString();
            string ctype = ConfigurationManager.AppSettings["TXLChildType"].ToString();
            bool isNum = Regex.IsMatch(keyword, @"^([0-9])[0-9]*(\.\w*)?$");
            List<QueryContainer> shouldQueryP = new List<QueryContainer>();


                keyword = keyword.ToLower();
                QueryContainer shouldQueryCN = new WildcardQuery() { Field = string.IsNullOrEmpty(field) ? "fields_query" : field.ToLower(), Value = string.Format("*{0}*", keyword) };
                QueryContainer shouldQueryPY = new WildcardQuery() {Field = "fields_query.raw" , Value = string.Format("*{0}*", keyword) };

                shouldQueryP.Add(shouldQueryCN);
                shouldQueryP.Add(shouldQueryPY);

            QueryContainer boolQuery = new BoolQuery() { Should= shouldQueryP };
            
            ISearchResponse<Employee> searchResults = null;
                searchResults = Connect.GetSearchClient().Search<Employee>(s => s
                .Index(indexname)
                .Type(typename)
                .Query(boolQuery)
                .Sort(st => st.OnField(f => f.Lft).Order(SortOrder.Ascending))
                .Sort(st => st.OnField(f => f.Orderid).Order(SortOrder.Ascending))
                .From(start)
                .Size(size == 0 ? 10 : size)
                );

            List<Employee> eslist = new List<Employee>(searchResults.Documents);
            string json = Obj2Json<Employee>(eslist);
            json = Regex.Replace(json, "\\\"", "'");
            return json ;
        }
        /// <summary>
        /// 根据字段进行高级搜索
        /// </summary>
        /// <param name="sc"></param>
        /// <returns></returns>
        public string Get(SearchCondition sc)
        {
            string indexname = ConfigurationManager.AppSettings["TXLIndex"].ToString();
            string typename = ConfigurationManager.AppSettings["TXLType"].ToString();
            string ctype = ConfigurationManager.AppSettings["TXLChildType"].ToString();
            string department = ConfigurationManager.AppSettings["TXLDepartment"].ToString();

            string _lft = null;
            string _rgt = null;
            if (!string.IsNullOrEmpty(sc.depid))
            {
                var getRange = Connect.GetSearchClient().Search<Department>(s=>s
                    .Index(indexname)
                    .Type(department)
                    .Query(q=>q.Term(t=>t.OnField(f=>f.Id).Value(sc.depid)))
                    );
                List<Department> dlsit = new List<Department>(getRange.Documents);
                _lft = dlsit[0].Lft.ToString();
                _rgt = dlsit[0].Rgt.ToString();
            }

            var searchResults = Connect.GetSearchClient().Search<Employee>(s => s
                .Index(indexname)
                .Type(typename)
                .Query(q=>q
                    .Bool(b=>b
                        .Must(
                            ms =>ms.HasParent<Department>(hp=>hp.Type(department).Query(que=>que
                                        .Bool(boo=>boo.Must(
                                            mus=>mus.Range(r=>r.OnField(off=>off.Lft).GreaterOrEquals(_lft)),
                                            mus=>mus.Range(r=>r.OnField(off=>off.Rgt).LowerOrEquals(_rgt))
                                            ))
                                    )),
                            ms => ms.Wildcard(wc => wc.OnField(f => f.Eid).Value(Convert.ToString(string.IsNullOrEmpty(sc.eid) ? "" : string.Format(sc.eid)))),
                            ms => ms.Wildcard(wc => wc.OnField(f=>f.Departmentstr).Value(Convert.ToString(string.IsNullOrEmpty(sc.d) ? "" : string.Format("*{0}*", sc.d)))),
                            ms => ms.Wildcard(wc => wc.OnField(f=>f.Emailaddress).Value(Convert.ToString(string.IsNullOrEmpty(sc.e) ? "" : string.Format("*{0}*", sc.e)))),
                            ms => ms.Wildcard(wc => wc.OnField(f=>f.Purview).Value(Convert.ToString(string.IsNullOrEmpty(sc.p) ? "" : string.Format("*{0}*", sc.p)))),
                            ms => ms.Wildcard(wc => wc.OnField(f=>f.Realname).Value(Convert.ToString(string.IsNullOrEmpty(sc.r) ? "" : string.Format("*{0}*", sc.r)))),
                            ms => ms.Wildcard(wc => wc.OnField("dutymemo.lower").Value(Convert.ToString(string.IsNullOrEmpty(sc.dm) ? "" : string.Format("*{0}*", sc.dm.ToLower())))),
                            ms => ms.Wildcard(wc => wc.OnField(f=>f.Status).Value(Convert.ToString(string.IsNullOrEmpty(sc.status) ? "" : string.Format("*{0}*", sc.status)))),
                            ms => ms.Wildcard(wc => wc.OnField(f => f.Innernum).Value(Convert.ToString(string.IsNullOrEmpty(sc.i) ? "" : string.Format("*{0}*", sc.i)))),
                            ms => ms.Wildcard(wc => wc.OnField(f => f.Phonenum).Value(Convert.ToString(string.IsNullOrEmpty(sc.pn) ? "" : string.Format("*{0}*", sc.pn))))
                        ))
                        )
                .Sort(st => st.OnField(f => f.Lft).Order(SortOrder.Ascending))
                .Sort(st => st.OnField(f => f.Orderid).Order(SortOrder.Ascending))      
                .From(sc.start)
                .Size(sc.size == 0 ? 10 : sc.size)
            );

            List<Employee> eslist = new List<Employee>(searchResults.Documents);
            string json = Obj2Json<Employee>(eslist);
            json = Regex.Replace(json, "\\\"", "'");

            return json;
        }
        public string Get(string id)
        {
            string indexname = ConfigurationManager.AppSettings["TXLIndex"].ToString();
            string typename = ConfigurationManager.AppSettings["TXLType"].ToString();
            string ctype = ConfigurationManager.AppSettings["TXLChildType"].ToString();
            QueryContainer matchQuery = new MatchQuery() { Field = "empid", Query = id.ToString(), Operator = Operator.And };
            var searchResults = Connect.GetSearchClient().Search<EmployeeChild>(s => s
                .Index(indexname)
                .Type(ctype)
                .Query(matchQuery)
                .From(0)
                .Size(10)
            );
            List<EmployeeChild> eslist = new List<EmployeeChild>(searchResults.Documents);
            string json = Obj2Json<EmployeeChild>(eslist);
            json = Regex.Replace(json, "\\\"", "'");
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

        public int GetCount(string keyword, string field, int start, int size)
        {
            int count = 0;
            string indexname = ConfigurationManager.AppSettings["TXLIndex"].ToString();
            string typename = ConfigurationManager.AppSettings["TXLType"].ToString();
            string ctype = ConfigurationManager.AppSettings["TXLChildType"].ToString();
            bool isNum = Regex.IsMatch(keyword, @"^([0-9])[0-9]*(\.\w*)?$");

            List<QueryContainer> shouldQueryP = new List<QueryContainer>();
            keyword = keyword.ToLower();
            QueryContainer shouldQueryCN = new WildcardQuery() { Field = string.IsNullOrEmpty(field) ? "fields_query" : field.ToLower(), Value = string.Format("*{0}*", keyword) };
            QueryContainer shouldQueryPY = new WildcardQuery() { Field = "fields_query.raw", Value = string.Format("*{0}*", keyword) };
            shouldQueryP.Add(shouldQueryCN);
            shouldQueryP.Add(shouldQueryPY);
            QueryContainer boolQuery = new BoolQuery() { Should = shouldQueryP };

                var counts = Connect.GetSearchClient().Count<Employee>(s => s
                .Index(indexname)
                .Type(typename)
                .Query(boolQuery)
                );
                count = (int)counts.Count;
            return count;
        }

        public int GetCount(SearchCondition sc)
        {
            int count = 0;
            string indexname = ConfigurationManager.AppSettings["TXLIndex"].ToString();
            string typename = ConfigurationManager.AppSettings["TXLType"].ToString();
            string ctype = ConfigurationManager.AppSettings["TXLChildType"].ToString();
            string department = ConfigurationManager.AppSettings["TXLDepartment"].ToString();

            string _lft = null;
            string _rgt = null;
            if (!string.IsNullOrEmpty(sc.depid))
            {
                var getRange = Connect.GetSearchClient().Search<Department>(s => s
                    .Index(indexname)
                    .Type(department)
                    .Query(q => q.Term(t => t.OnField(f => f.Id).Value(sc.depid)))
                    );
                List<Department> dlsit = new List<Department>(getRange.Documents);
                _lft = dlsit[0].Lft.ToString();
                _rgt = dlsit[0].Rgt.ToString();
            }
            var searchResults = Connect.GetSearchClient().Count<Employee>(s => s
                .Index(indexname)
                .Type(typename)
                .Query(q => q
                    .Bool(b => b
                        .Must(
                            ms => ms.HasParent<Department>(hp => hp.Type(department).Query(que => que
                                           .Bool(boo => boo.Must(
                                               mus => mus.Range(r => r.OnField(off => off.Lft).GreaterOrEquals(_lft)),
                                               mus => mus.Range(r => r.OnField(off => off.Rgt).LowerOrEquals(_rgt))
                                               ))
                                     )),
                            ms => ms.Wildcard(wc => wc.OnField(f => f.Eid).Value(Convert.ToString(string.IsNullOrEmpty(sc.eid) ? "" : string.Format(sc.eid)))),
                            ms => ms.Wildcard(wc => wc.OnField(f => f.Departmentstr).Value(Convert.ToString(string.IsNullOrEmpty(sc.d) ? "" : string.Format("*{0}*", sc.d)))),
                            ms => ms.Wildcard(wc => wc.OnField(f => f.Emailaddress).Value(Convert.ToString(string.IsNullOrEmpty(sc.e) ? "" : string.Format("*{0}*", sc.e)))),
                            ms => ms.Wildcard(wc => wc.OnField(f => f.Purview).Value(Convert.ToString(string.IsNullOrEmpty(sc.p) ? "" : string.Format("*{0}*", sc.p)))),
                            ms => ms.Wildcard(wc => wc.OnField(f => f.Realname).Value(Convert.ToString(string.IsNullOrEmpty(sc.r) ? "" : string.Format("*{0}*", sc.r)))),
                            ms => ms.Wildcard(wc => wc.OnField("dutymemo.lower").Value(Convert.ToString(string.IsNullOrEmpty(sc.dm) ? "" : string.Format("*{0}*", sc.dm.ToLower())))),
                            ms => ms.Wildcard(wc => wc.OnField(f => f.Status).Value(Convert.ToString(string.IsNullOrEmpty(sc.status) ? "" : string.Format("*{0}*", sc.status)))),
                                                                ms => ms.Wildcard(wc => wc.OnField(f => f.Innernum).Value(Convert.ToString(string.IsNullOrEmpty(sc.i) ? "" : string.Format("*{0}*", sc.i)))),
                            ms => ms.Wildcard(wc => wc.OnField(f => f.Phonenum).Value(Convert.ToString(string.IsNullOrEmpty(sc.pn) ? "" : string.Format("*{0}*", sc.pn))))
                        ))
                ));
            count = (int)searchResults.Count;
            return count;
        }

        public int GetCount(string id)
        {
            int count = 0;
            string indexname = ConfigurationManager.AppSettings["TXLIndex"].ToString();
            string typename = ConfigurationManager.AppSettings["TXLType"].ToString();
            string ctype = ConfigurationManager.AppSettings["TXLChildType"].ToString();
            QueryContainer matchQuery = new MatchQuery() { Field = "empid", Query = id.ToString(), Operator = Operator.And };
            var searchResults = Connect.GetSearchClient().Count<EmployeeChild>(s => s
                .Index(indexname)
                .Type(ctype)
                .Query(matchQuery)
            );
            count = (int)searchResults.Count;
            return count;
        }

        
    }
}
