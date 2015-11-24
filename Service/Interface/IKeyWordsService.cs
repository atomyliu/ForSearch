using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IKeyWordsService
    {
        List<KeyWords> GetList(string keyword, int start, int size);

        List<KeyWords> GetList(string keyword,string type, int start, int size);

        int GetCount(string keyword);

        int GetCount(string keyword,string type);
    }
}
