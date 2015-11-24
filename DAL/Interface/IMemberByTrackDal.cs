using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public partial interface IMemberByTrackDal
    {
        string GetList(Implement.MemberByTrackDal.SearchCondition sc,out int em);
        List<Member> GetList(string keyword, string field, int start, int size, string country, string province, string city, string address, string memo, string classx, string trackType, string afterSales, out int em);
        int GetCount(string keyword, string field);
    }
}
