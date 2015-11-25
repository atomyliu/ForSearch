using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Factory
{
    public class DataCache
    {
        public DataCache()
        { }
        /// <summary>
        /// 获得缓存对象
        /// </summary>
        /// <param name="CacheKey">键</param>
        /// <returns>缓存对象</returns>
        public static object GetCache(string CacheKey)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            return objCache[CacheKey];
        }
        /// <summary>
        /// 设置缓存对象
        /// </summary>
        /// <param name="CacheKey">键</param>
        /// <param name="objObject">要被缓存的对象</param>
        public static void SetCache(string CacheKey, object objObject)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject);
        }
    }
    
}
