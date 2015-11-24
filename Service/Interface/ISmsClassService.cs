using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ISmsClassService
    {
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="keyword">根据Title查询</param>
        /// <param name="start"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        List<SmsClass> GetList(string keyword, int start, int size);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="type">根据类型</param>
        /// <param name="start"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        List<SmsClass> GetList(string keyword, string type, int start, int size);

        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        int GetCount(string keyword);
        int GetCount(string keyword, string type);
    }
}
