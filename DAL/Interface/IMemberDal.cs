using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL.Interface
{
    public partial interface IMemberDal
    {
        List<Member> GetList(string keyword, int start, int size);
        List<Member> GetList(string keyword,string field, int start, int size);
        List<Member> GetListByPrefix(string keyword, string field, int start, int size);
        List<Member> GetListByTrack(string keyword, string field, int start, int size, string country, string province, string city, string address, string memo, string classx, string trackType, string afterSales, out int em);
        string GetListByTrack(Implement.MemberDal.SearchCondition sc, out int em);
        string GetList(Implement.MemberDal.SearchCondition sc, out int em);

        int GetCount(string keyword);
        int GetCount(string keyword,string field);
        int GetCountByPrefix(string keyword, string field);

        int GetCount(DAL.Implement.MemberDal.SearchCondition sc);
    }
}
