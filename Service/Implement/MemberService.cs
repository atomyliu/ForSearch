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
    public class MemberService : IMemberService
    {
        private IMemberDal _dal = new MemberDal();
        /// <summary>
        /// 根据关键字和分页条件查询
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="start"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public List<Member> GetList(string keyword, int start, int size)
        {
            return _dal.GetList(keyword, start, size);
        }

        public List<Member> GetList(string keyword,string type, int start, int size)
        {
            return _dal.GetList(keyword, type, start, size);
        }

        public List<Member> GetListByPrefix(string keyword, string type, int start, int size)
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

        public int GetCount(string keyword,string type)
        {
            return _dal.GetCount(keyword,type);
        }

        public int GetCountByPrefix(string keyword, string type)
        {
            return _dal.GetCountByPrefix(keyword, type);
        }
    }
}
