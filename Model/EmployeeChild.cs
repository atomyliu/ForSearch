using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class EmployeeChild
    {
        private string _phonenum;
        private string _innernum;
        private string _empid;

        public string Phonenum
        {
            get
            {
                return _phonenum;
            }

            set
            {
                _phonenum = value;
            }
        }

        public string Innernum
        {
            get
            {
                return _innernum;
            }

            set
            {
                _innernum = value;
            }
        }

        public string Empid
        {
            get
            {
                return _empid;
            }

            set
            {
                _empid = value;
            }
        }
    }
}
