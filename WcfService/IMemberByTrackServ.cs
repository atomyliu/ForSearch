using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IMemberTrackServ”。
    [ServiceContract]
    public interface IMemberByTrackServ
    {
        [OperationContract(Name = "GetListByClass")]
        string GetList(DAL.Implement.MemberByTrackDal.SearchCondition sc, out int em);
        [OperationContract(Name = "GetList")]
        List<Member> GetList(string keyword, string field, int start, int size, string country, string province, string city, string address, string memo, string classx, string trackType, string afterSales,out int em);
        //[OperationContract]
        //byte[] GetListM(string keyword, string field, int start, int size, string country, string province, string city, string address, string memo, string classx, string trackType, string afterSales, out int em);
        [OperationContract]
        int GetCount(string keyword, string field);
    }
}
