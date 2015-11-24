using DAL.Implement;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“MemberGenServ”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 MemberGenServ.svc 或 MemberGenServ.svc.cs，然后开始调试。
    public class MemberGenServ : IMemberGenServ
    {
        private IMemberGenDal _dal = new MemberGenDal();
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="field">类型：Enterprise,Products,Memo,Address,AdminName,WebName</param>
        /// <param name="start"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public IEnumerable<string> GetIDs(string keyword, string field, int start, int size)
        {
            return _dal.GetIDs(keyword, field, start, size);
        }

        public IEnumerable<string> GetIDs(string keyword, int start, int size)
        {
            return _dal.GetIDs(keyword, start, size);
        }
        public byte[] GetIDsM(string keyword, string field, int start, int size)
        {
            return _dal.GetIDsM(keyword, field, start, size);
        }
        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <param name="type">类型：Enterprise,Products,Memo,Address,AdminName,WebName</param>
        /// <returns></returns>
        public int GetCount(string keyword, string field)
        {
            return _dal.GetCount(keyword, field);
        }
    }
}
