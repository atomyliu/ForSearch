using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IMemberServ”。
    [ServiceContract]
    public interface IMemberServ
    {
        [OperationContract]
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <param name="field">类型：Enterprise,Products,Memo,Address,AdminName,WebName</param>
        /// <param name="start">开始位置</param>
        /// <param name="size">条数</param>
        /// <returns></returns>
        List<Member> GetList(string keyword, string field, int start, int size);

        [OperationContract]
        List<Member> GetListByPrefix(string keyword, string field, int start, int size);

        [OperationContract(Name = "GetListByTrack")]
        List<Member> GetListByTrack(string keyword, string field, int start, int size, string country, string province, string city, string address, string memo, string classx, string trackType, string afterSales, out int em);

        [OperationContract(Name = "GetJsonByTrack")]
        string GetListByTrack(DAL.Implement.MemberDal.SearchCondition sc, out int em);

        [OperationContract(Name = "GetJsonByChild")]
        string GetList(DAL.Implement.MemberDal.SearchCondition sc, out int em);

        [OperationContract]
        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <param name="field">类型：Enterprise,Products,Memo,Address,AdminName,WebName</param>
        /// <returns></returns>
        int GetCount(string keyword, string field);

        [OperationContract]
        int GetCountByPrefix(string keyword, string field);
        [OperationContract(Name = "GetCountByChild")]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sc"></param>
        /// <returns></returns>
        int GetCount(DAL.Implement.MemberDal.SearchCondition sc);
    }
}
