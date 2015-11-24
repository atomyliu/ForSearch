using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Service.Interface;
using DAL.Interface;
using DAL.Implement;

namespace Service.Implement
{
    public class URLNameService : IURLNameService
    {
        private IURLNameDal _dal = new URLNameDal();
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="start"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public List<URLName> GetList(string keyword, int start, int size)
        {
            return _dal.GetList(keyword, start, size);
        }

        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public int GetCount(string keyword)
        {
            return _dal.GetCount(keyword);
        }
    }
}
