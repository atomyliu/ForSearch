using DAL.Implement;
using DAL.Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“AutoKeyWordServ”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 AutoKeyWordServ.svc 或 AutoKeyWordServ.svc.cs，然后开始调试。
    public class AutoKeyWordServ : IAutoKeyWordServ
    {
        private IKeyWordsDal _dal = new KeyWordsDal();
        public List<KeyWords> GetList(string keyword, int start, int size)
        {
            return _dal.GetList(keyword, start, size);
        }
        public int GetCount(string keyword)
        {
            return _dal.GetCount(keyword);
        }
    }
}
