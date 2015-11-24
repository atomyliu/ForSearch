using DAL.Implement;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace ESWebAPI.Controllers
{
    [RoutePrefix("api/cp")]
    public class CommProductController : ApiController
    {
        [ModelBinder]
        public class SearchCondition
        {
            public string keywords { get; set; }
            public string typenames { get; set; }
            public int start { get; set; }
            public int size { get; set; }
        }
        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        private ICommProductDal _dal = new CommProductDal();
        // GET api/<controller>/5
        [HttpGet]
        public HttpResponseMessage Get(SearchCondition sc)
        {
            CommProductDal.SearchCondition csc = new CommProductDal.SearchCondition();
            string[] kstr = { };
            if (!string.IsNullOrEmpty(sc.keywords))
            {
                kstr = sc.keywords.ToString().Split(',');
            }
            if (!string.IsNullOrEmpty(sc.typenames))
            {
                string[] tstr = sc.typenames.ToString().Split(',');
                csc.typenames = tstr;
            }
            csc.keywords = kstr;
            csc.size = sc.size;
            csc.start = sc.start;
            
            string json = _dal.Get(csc);
            HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(json, Encoding.GetEncoding("UTF-8"), "application/json") };
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