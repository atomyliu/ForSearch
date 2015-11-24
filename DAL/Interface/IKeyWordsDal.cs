using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL.Interface
{
    public interface IKeyWordsDal
    {
        List<KeyWords> GetList(string keyword, int start, int size);

        List<KeyWords> GetList(string keyword,string field, int start, int size);

        int GetCount(string keyword);

        int GetCount(string keyword,string field);
    }
}
