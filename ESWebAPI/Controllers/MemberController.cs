using DAL.Implement;
using DAL.Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;

namespace ESWebAPI.Controllers
{
    public class RequireHttpsAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.RequestUri.Scheme != Uri.UriSchemeHttps)
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden)
                {
                    ReasonPhrase = "HTTPS Required"
                };
            }
            else
            {
                base.OnAuthorization(actionContext);
            }
        }
    }
    [RoutePrefix("api/member")]
    public class MemberController : ApiController
    {
        private IMemberDal _dal = new MemberDal();
        #region SearchCondition 查询参数
        [ModelBinder]
        public class SearchCondition
        {
            #region 应用级别参数
            #region 子表查询字段，当只查询member时也使用
            public string flag { get; set; }
            public string keyword { get; set; }
            public string field { get; set; }
            #endregion
            #region 分页
            public int start { get; set; }
            public int size { get; set; }
            #endregion
            #region member表查询字段
            public string country { get; set; }
            public string province { get; set; }
            public string city { get; set; }
            public string address { get; set; }
            public string memo { get; set; }
            public string classx { get; set; }
            public string tracktype { get; set; }
            public string aftersales { get; set; }
            #endregion
            #endregion
            #region 系统级别参数
            #region 签名参数
            public string timestamp { get; set; }
            public string sign { get; set; }
            #endregion
            #endregion
        }
        #endregion
        [HttpGet]
        [Route("getm/{a}/{b}/{c}" )]
        public SearchCondition getm(string a, string b, string c)
        {
            return new SearchCondition { flag = a, keyword = b, field = c };
        }

        [HttpGet]
        //[RequireHttps]
        public HttpResponseMessage getme(SearchCondition model)
        {
            int em = 0;
            DAL.Implement.MemberDal.SearchCondition sc = new MemberDal.SearchCondition();
            sc.address = model.address;
            sc.aftersales = model.aftersales;
            sc.city = model.city;
            sc.classx = model.classx;
            sc.country = model.country;
            sc.field = model.field;
            sc.flag = model.flag;
            sc.keyword = model.keyword;
            sc.memo = model.memo;
            sc.province = model.province;
            sc.size = model.size < 30 ? model.size : 30;
            sc.start = model.start;
            sc.tracktype = model.tracktype;
            string[] kstr = model.keyword.ToString().Split(',');
            sc.keywords = kstr;
            string str = "[]";
            if (ValidateSign(Regex.Replace(model.keyword, ",", string.Empty), model.flag, model.field, Convert.ToDateTime(model.timestamp), model.sign))
            {
                str = _dal.GetList(sc, out em).Replace("\r", string.Empty).Replace("\n", string.Empty);
            }
            //str = _dal.GetList(sc, out em).Replace("\r", string.Empty).Replace("\n", string.Empty);
            //string str = _dal.GetList(sc, out em);
            HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
            return result;
        }
        [HttpGet]
        //[RequireHttps]
        public HttpResponseMessage getCount(SearchCondition model)
        {
            DAL.Implement.MemberDal.SearchCondition sc = new MemberDal.SearchCondition();
            sc.address = model.address;
            sc.aftersales = model.aftersales;
            sc.city = model.city;
            sc.classx = model.classx;
            sc.country = model.country;
            sc.field = model.field;
            sc.flag = model.flag;
            sc.keyword = model.keyword;
            sc.memo = model.memo;
            sc.province = model.province;
            sc.tracktype = model.tracktype;
            string[] kstr = model.keyword.ToString().Split(',');
            sc.keywords = kstr;
            int str = 0;
            if (ValidateSign(Regex.Replace(model.keyword, ",", string.Empty), model.flag, model.field,Convert.ToDateTime(model.timestamp),model.sign))
            {
                str = _dal.GetCount(sc);
            }
            //int str = _dal.GetCount(sc);
            HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str.ToString(), Encoding.GetEncoding("UTF-8"), "application/json") };
            return result;
        }

        private string CreateSignature(string keyword,string flag,string field,DateTime timestamp)
        {
            string sign = "";
            try
            {
                TimeSpan toNow = DateTime.Now.Subtract(timestamp);
                string nowTS = toNow.TotalSeconds.ToString();
                int ts = 0;
                if (toNow.TotalSeconds != 0)
                {
                    ts = int.Parse(nowTS.Substring(0, nowTS.IndexOf('.')));
                }
                if (Math.Abs(ts) < 120)
                {
                    sign = ("keyword=" + keyword + "&flag=" + flag + "&field=" + field + "&timestamp=" + timestamp.ToString("yyyy-MM-dd HH:mm:ss")).ToUpper();
                    sign = common.GetMD5.GetMD5HashFromStr(sign);
                }
            }
            catch (Exception)
            {
                sign = "";
            }
            return sign;
        }
        private bool ValidateSign(string keyword, string flag, string field, DateTime timestamp,string sign)
        {
            try
            {
                string str = CreateSignature(keyword, flag, field, timestamp);
                if (!string.IsNullOrEmpty(str))
                {
                    return str.Equals(sign);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

}
