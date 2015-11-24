using DAL.Implement;
using DAL.Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;

namespace WcfService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“MemberContactServ”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 MemberContactServ.svc 或 MemberContactServ.svc.cs，然后开始调试。
    public class MemberContactServ : IMemberContactServ
    {
        private IMemberContactDal _dal = new MemberContactDal();
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="field">类型：ID,MemberID,Linkman,Phone,Fax,Mobile,Email</param>
        /// <param name="start"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public List<MemberContact> GetList(string keyword, string field, int start, int size)
        {
            return _dal.GetList(keyword, field, start, size);
        }
        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <param name="type">类型：ID,MemberID,Linkman,Phone,Fax,Mobile,Email</param>
        /// <returns></returns>
        public int GetCount(string keyword, string field)
        {
            return _dal.GetCount(keyword, field);
        }
    }
}
