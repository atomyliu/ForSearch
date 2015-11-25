
using DAL.Implement;
using DAL.Interface;
using Factory;
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
    public class DeleteController : ApiController
    {
        [ModelBinder]
        public class DeleteCondition
        {
            public string index { get; set; }
            public string type { get; set; }
            //public string field { get; set; }
            //public string query { get; set; }
            public string id { get; set; }
            public string sign { get; set; }
        }

        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        // PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}
        private IDELETEDal _dal = DalFactory.DeleteDalInstance();
        // DELETE api/<controller>/5
        [HttpGet]
        public HttpResponseMessage Delete(DeleteCondition dc)
        {
            DELETEDal.DeleteCondition dddc = new DELETEDal.DeleteCondition();
            
            dddc.index = dc.index;
            dddc.type = dc.type;
            dddc.id = dc.id;
            bool results = false;
            if (dc.sign.Equals("confirm"))
            {
                results = _dal.DELETE(dddc);
            }
            string str = results.ToString();
            HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
            return result;

        }
    }
}