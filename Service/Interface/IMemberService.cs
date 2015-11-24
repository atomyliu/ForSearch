using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Service.Interface
{
    public interface IMemberService
    {
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="start"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        List<Member> GetList(string keyword, int start, int size);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="type">三种类型：enterprise,products,memo</param>
        /// <param name="start"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        List<Member> GetList(string keyword,string type, int start, int size);


        List<Member> GetListByPrefix(string keyword, string type, int start, int size);
        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        int GetCount(string keyword);
        int GetCount(string keyword,string type);
        int GetCountByPrefix(string keyword, string type);
    }
}
