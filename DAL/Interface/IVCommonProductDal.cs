using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public partial interface IVCommonProductDal
    {
        List<VCommonProduct> GetList(string keyword, int start, int size);
        List<VCommonProduct> GetList(string keyword, string field, int start, int size);
        int GetCount(string keyword);
        int GetCount(string keyword, string field);
    }

}
