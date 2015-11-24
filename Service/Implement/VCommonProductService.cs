using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL.Interface;
using DAL.Implement;

namespace Service.Implement
{
    public class VCommonProductService : IVCommonProductService
    {
        private IVCommonProductDal _dal = new VCommonProductDal();
        public int GetCount(string keyword)
        {
            return _dal.GetCount(keyword);
        }

        public int GetCount(string keyword, string type)
        {
            return _dal.GetCount(keyword, type);
        }

        public List<VCommonProduct> GetList(string keyword, int start, int size)
        {
            return _dal.GetList(keyword, start, size);
        }

        public List<VCommonProduct> GetList(string keyword, string type, int start, int size)
        {
            return _dal.GetList(keyword, type, start, size);
        }
    }
}
