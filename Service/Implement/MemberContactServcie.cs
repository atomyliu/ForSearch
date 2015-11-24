using DAL.Implement;
using DAL.Interface;
using Model;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implement
{
    public class MemberContactServcie : IMemberContactServcie
    {
        private IMemberContactDal _dal = new MemberContactDal();
        /// <summary>
        /// 根据关键字和分页条件查询
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="start"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public List<MemberContact> GetList(string keyword, int start, int size)
        {
            return _dal.GetList(keyword, start, size);
        }

        public List<MemberContact> GetList(string keyword, string type, int start, int size)
        {
            return _dal.GetList(keyword, type, start, size);
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

        public int GetCount(string keyword, string type)
        {
            return _dal.GetCount(keyword, type);
        }
    }
}
