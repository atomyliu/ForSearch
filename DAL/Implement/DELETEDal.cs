using common;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implement
{
    public class DELETEDal : IDELETEDal
    {
        public class DeleteCondition
        {
            public string index { get; set; }
            public string type { get; set; }
            //public string field { get; set; }
            //public string query { get; set; }
            public string id { get; set; }
        }
        public bool DELETE(DeleteCondition dc)
        {
            return ESHelper.Delete(dc.index,dc.type,dc.id);
        }
    }
}
