using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class VCommonProduct
    {
        private string _pid;
        private string _typeName;
        private string _productName;
        private string _price;
        private string _siteName;
        private string _searchstr;

        public string Pid
        {
            get
            {
                return _pid;
            }

            set
            {
                _pid = value;
            }
        }

        public string TypeName
        {
            get
            {
                return _typeName;
            }

            set
            {
                _typeName = value;
            }
        }

        public string ProductName
        {
            get
            {
                return _productName;
            }

            set
            {
                _productName = value;
            }
        }

        public string Price
        {
            get
            {
                return _price;
            }

            set
            {
                _price = value;
            }
        }

        public string SiteName
        {
            get
            {
                return _siteName;
            }

            set
            {
                _siteName = value;
            }
        }

        public string Searchstr
        {
            get
            {
                return _searchstr;
            }

            set
            {
                _searchstr = value;
            }
        }
    }
}
