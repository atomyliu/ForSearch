using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public partial interface ISmsClassDal
    {
        List<SmsClass> GetList(string keyword, int start, int size);
        List<SmsClass> GetList(string keyword, string type, int start, int size);
        int GetCount(string keyword);
        int GetCount(string keyword, string type);
    }
}
