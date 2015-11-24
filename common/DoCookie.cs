using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace common
{
    public class DoCookie
    {
        /// <summary>
        /// 获取cook HttpUtility.UrlEncode写入
        /// </summary>
        /// <param name="var"></param>
        /// <param name="key"></param>
        public static void doCook(string var, string key)
        {
            key = HttpUtility.UrlEncode(key);
            try
            {
                HttpContext.Current.Response.Cookies.Add(new HttpCookie(var, key));
            }
            catch
            {
                throw;
            }
        }
    }
}
