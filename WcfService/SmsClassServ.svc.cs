using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Model;
using DAL.Implement;

namespace WcfService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“SmsClassServ”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 SmsClassServ.svc 或 SmsClassServ.svc.cs，然后开始调试。
    public class SmsClassServ : ISmsClassServ
    {
        private ISmsClassDal _dal = new SmsClassDal();

        public int GetCount(string keyword)
        {
            return _dal.GetCount(keyword);
        }

        public int GetCount(string keyword,string field)
        {
            return _dal.GetCount(keyword, field);
        }

        public List<SmsClass> GetList(string keyword, int start, int size)
        {
            return _dal.GetList(keyword, start, size);
        }

        public List<SmsClass> GetList(string keyword,string field, int start, int size)
        {
            return _dal.GetList(keyword, field, start, size);
        }
    }
}
