using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public partial interface ITXLDal
    {
        string Get(string keyword,string field, int start, int size);
        string Get(Implement.TXLDal.SearchCondition tsc);
        //string Get(string id);

        int GetCount(string keyword, string field, int start, int size);
        int GetCount(Implement.TXLDal.SearchCondition tsc);
        //int GetCount(string id);
    }
}
