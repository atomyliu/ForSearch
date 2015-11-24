using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“INewsBaseServ”。
    [ServiceContract]
    public interface INewsBaseServ
    {
        [OperationContract(Name = "GetList")]
        List<NewsBase> GetList(string keyword, int start, int size);
        [OperationContract(Name = "GetContent")]
        List<NewsBase> GetList(string keyword,string field, int start, int size);

        [OperationContract]
        int GetCount(string keyword);

    }
}
