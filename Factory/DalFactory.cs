using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class DalFactory
    {
        /// <summary>
        /// 通过反射机制，实例化接口对象
        /// </summary>
        private static string _path = ConfigurationManager.AppSettings["Dal"].ToString();

        /// <summary>
        /// 通过反射机制，实例化接口对象
        /// </summary>
        /// <param name="CacheKey">接口对象名称(键)</param>
        ///<returns>接口对象/returns>
        private static object GetInstance(string CacheKey)
        {
            object objType = DataCache.GetCache(CacheKey);
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(DalFactory._path).CreateInstance(CacheKey);
                    DataCache.SetCache(CacheKey, objType);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return objType;
        }
        /// <summary>
        /// 实现删除接口对象
        /// </summary>
        /// <returns></returns>
        public static IDELETEDal DeleteDalInstance()
        {
            string CacheKey = DalFactory._path + ".Implement.DELETEDal";
            object objType = DalFactory.GetInstance(CacheKey);
            return (IDELETEDal)objType;
        }
    }
}
