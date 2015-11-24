using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IVSmsClassServ”。
    [ServiceContract]
    public interface IVSmsClassServ
    {
        [OperationContract(Name = "GetList")]
        List<VSmsClass> GetList(string keyword, int start, int size);
        [OperationContract(Name = "GetListWithType")]
        List<VSmsClass> GetList(string keyword, string field, int start, int size);
        [OperationContract(Name = "GetCount")]
        int GetCount(string keyword);
        [OperationContract(Name = "GetCountWithType")]
        int GetCount(string keyword, string field);
    }
}
