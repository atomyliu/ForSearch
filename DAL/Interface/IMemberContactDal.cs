using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IMemberContactDal
    {
        /// <summary>
        /// 获取新闻列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="start"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        List<MemberContact> GetList(string keyword, int start, int size);
        List<MemberContact> GetList(string keyword, string field, int start, int size);
        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        int GetCount(string keyword);
        int GetCount(string keyword, string field);
    }
}
