using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SmsProduct
    {
        private string _iD;
        private string _className;
        private string _rootID;
        private string _parentID;
        private string _ParentPath;
        private string _deepth;
        private string _orderID;
        private string _memo;

        public string ID
        {
            get
            {
                return _iD;
            }

            set
            {
                _iD = value;
            }
        }

        public string ClassName
        {
            get
            {
                return _className;
            }

            set
            {
                _className = value;
            }
        }

        public string RootID
        {
            get
            {
                return _rootID;
            }

            set
            {
                _rootID = value;
            }
        }

        public string ParentID
        {
            get
            {
                return _parentID;
            }

            set
            {
                _parentID = value;
            }
        }

        public string ParentPath
        {
            get
            {
                return _ParentPath;
            }

            set
            {
                _ParentPath = value;
            }
        }

        public string Deepth
        {
            get
            {
                return _deepth;
            }

            set
            {
                _deepth = value;
            }
        }

        public string OrderID
        {
            get
            {
                return _orderID;
            }

            set
            {
                _orderID = value;
            }
        }

        public string Memo
        {
            get
            {
                return _memo;
            }

            set
            {
                _memo = value;
            }
        }
    }
}
