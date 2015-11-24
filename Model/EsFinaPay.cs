using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class EsFinaPay
    {
        private int _id;
        private int _memberid;
        private int _fid;
        private int _payid;
        private string _productname;

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public int Memberid
        {
            get
            {
                return _memberid;
            }

            set
            {
                _memberid = value;
            }
        }

        public int Fid
        {
            get
            {
                return _fid;
            }

            set
            {
                _fid = value;
            }
        }

        public int Payid
        {
            get
            {
                return _payid;
            }

            set
            {
                _payid = value;
            }
        }

        public string Productname
        {
            get
            {
                return _productname;
            }

            set
            {
                _productname = value;
            }
        }
    }
}
