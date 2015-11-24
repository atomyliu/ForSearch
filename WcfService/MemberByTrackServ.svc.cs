using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Model;
using DAL.Interface;
using DAL.Implement;
using common;

namespace WcfService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“MemberTrackServ”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 MemberTrackServ.svc 或 MemberTrackServ.svc.cs，然后开始调试。
    public class MemberByTrackServ : IMemberByTrackServ
    {
        private IMemberByTrackDal _dal = new MemberByTrackDal();

        public string GetList(MemberByTrackDal.SearchCondition sc, out int em)
        {
            return _dal.GetList(sc, out em);
        }
        /// <summary>
        /// 根据Track查询Member列表
        /// </summary>
        /// <param name="keyword">Track表查询关键字</param>
        /// <param name="field">Track查询字段，默认Memo</param>
        /// <param name="start">分页开始位置</param>
        /// <param name="size">分页大小</param>
        /// <param name="country">国家地区</param>
        /// <param name="province">省份</param>
        /// <param name="city">市</param>
        /// <param name="address">地址</param>
        /// <param name="memo">备注</param>
        /// <param name="classx">Class字段名，直接输入数字，string类型，如“1”</param>
        /// <param name="trackType">trackType字段</param>
        /// <param name="afterSales">afterSales字段</param>
        /// <param name="em">执行时间，单位毫秒</param>
        /// <returns></returns>
        public List<Member> GetList(string keyword, string field, int start, int size, string country, string province, string city, string address, string memo, string classx, string trackType, string afterSales,out int em)
        {
            return _dal.GetList(keyword, field, start, size, country, province, city, address, memo, classx, trackType, afterSales,out em);
        }
        /// <summary>
        /// 根据Track查询Member列表--压缩模式
        /// </summary>
        /// <param name="keyword">Track表查询关键字</param>
        /// <param name="field">Track查询字段，默认Memo</param>
        /// <param name="start">分页开始位置</param>
        /// <param name="size">分页大小</param>
        /// <param name="country">国家地区</param>
        /// <param name="province">省份</param>
        /// <param name="city">市</param>
        /// <param name="address">地址</param>
        /// <param name="memo">备注</param>
        /// <param name="classx">Class字段名，直接输入数字，string类型，如“1”</param>
        /// <param name="trackType">trackType字段</param>
        /// <param name="afterSales">afterSales字段</param>
        /// <param name="em">执行时间，单位毫秒</param>
        /// <returns></returns>
        //public byte[] GetListM(string keyword, string field, int start, int size, string country, string province, string city, string address, string memo, string classx, string trackType, string afterSales, out int em)
        //{
        //    return GZip.Compress(GZip.SerializeObject(_dal.GetList(keyword, field, start, size, country, province, city, address, memo, classx, trackType, afterSales, out em).ToList()));
        //}

        public int GetCount(string keyword, string field)
        {
            return _dal.GetCount(keyword,field.ToLower());
        }

        
    }
}
