using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IDELETEDal
    {
        bool DELETE(Implement.DELETEDal.DeleteCondition dc);
    }
}
