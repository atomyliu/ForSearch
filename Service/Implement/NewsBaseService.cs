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
    public class NewsBaseService : INewsBaseService
    {
        private INewsBaseDal _dal = new NewsBaseDal();
        /// <summary>
        /// 根据关键字和分页条件查询
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="start"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public List<NewsBase> GetList(string keyword, int start, int size) 
        {
            return _dal.GetList(keyword,start,size);
        }

        public List<NewsBase> GetList(string keyword,string field, int start, int size)
        {
            return _dal.GetList(keyword, field, start, size);
        }
        /// <summary>
        /// 通过关键字获取总数
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public int GetCount(string keyword)
        {
            return _dal.GetCount(keyword);
        }

        public int GetCount(string keyword,string field)
        {
            return _dal.GetCount(keyword, field);
        }

    }
}
