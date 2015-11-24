using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IMemberContactServ”。
    [ServiceContract]
    public interface IMemberContactServ
    {
        [OperationContract]
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <param name="type">类型：ID,MemberID,Linkman,Phone,Fax,Mobile,Email</param>
        /// <param name="start">开始位置</param>
        /// <param name="size">条数</param>
        /// <returns></returns>
        List<MemberContact> GetList(string keyword, string field, int start, int size);

        [OperationContract]
        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <param name="type">类型：ID,MemberID,Linkman,Phone,Fax,Mobile,Email</param>
        /// <returns></returns>
        int GetCount(string keyword, string field);
    }
}
