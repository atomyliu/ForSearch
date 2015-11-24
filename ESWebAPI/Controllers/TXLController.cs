using DAL.Implement;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Text;

namespace ESWebAPI.Controllers
{
    [RoutePrefix("api/txl")]
    public class TXLController : ApiController
    {
        [ModelBinder]
        public class SearchCondition
        {
            public string keyword { get; set; } //关键字
            public string field { get; set; } //模糊查询字段名,默认
            public string pattern { get; set; } //查询方式,空则模糊,0高级 1子表
            public int start { get; set; }
            public int size { get; set; }
            public string r { get; set; }  //realname
            public string i { get; set; } //innernum
            public string e { get; set; } //emailaddress
            public string d { get; set; } //departmentstr
            public string dm { get; set; } //dutymemo
            public string p { get; set; } //Purview
            public string eid { get; set; } //工号
            public string status { get; set; }
            public string id { get; set; }
            public string pn { get; set; } //phonenum
            public string depid { get; set; } // department id
        }
        private ITXLDal _dal = new TXLDal();
        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<controller>/5
        [HttpGet]
        public HttpResponseMessage Get(SearchCondition sc)
        {
            string json = "[]";
            switch (sc.pattern)
            {
                case "0":
                    TXLDal.SearchCondition tsc = new TXLDal.SearchCondition();
                    tsc.keyword = sc.keyword;
                    tsc.size = sc.size;
                    tsc.start = sc.start;
                    tsc.status = sc.status;
                    tsc.d = sc.d;
                    tsc.e = sc.e;
                    tsc.dm = sc.dm;
                    tsc.i = sc.i;
                    tsc.p = sc.p;
                    tsc.r = sc.r;
                    tsc.eid = sc.eid;
                    tsc.pn = sc.pn;
                    tsc.depid = sc.depid;
                    json = _dal.Get(tsc).Replace("\r", string.Empty).Replace("\n", string.Empty); 
                    break;
                //case "1":
                //    json = _dal.Get(sc.id).Replace("\r", string.Empty).Replace("\n", string.Empty); 
                //    break;
                default:
                    json = _dal.Get(sc.keyword, sc.field, sc.start, sc.size).Replace("\r", string.Empty).Replace("\n", string.Empty); 
                    break;
            }
            HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(json, Encoding.GetEncoding("UTF-8"), "application/json") };
            return result;
        }

        public HttpResponseMessage GetCount(SearchCondition sc)
        {
            int count = 0;
            switch (sc.pattern)
            {
                case "0":
                    TXLDal.SearchCondition tsc = new TXLDal.SearchCondition();
                    tsc.keyword = sc.keyword;
                    tsc.size = sc.size;
                    tsc.start = sc.start;
                    tsc.status = sc.status;
                    tsc.d = sc.d;
                    tsc.dm = sc.dm;
                    tsc.e = sc.e;
                    tsc.i = sc.i;
                    tsc.p = sc.p;
                    tsc.r = sc.r;
                    tsc.eid = sc.eid;
                    tsc.pn = sc.pn;
                    tsc.depid = sc.depid;
                    count = _dal.GetCount(tsc);
                    break;
                //case "1":
                //    count = _dal.GetCount(sc.id);
                //    break;
                default:
                    count = _dal.GetCount(sc.keyword, sc.field, sc.start, sc.size) ;
                    break;
            }
            HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(count.ToString(), Encoding.GetEncoding("UTF-8"), "application/json") };
            return result;
        }
        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}