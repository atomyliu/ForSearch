using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SmsClass
    {
        private string _id;
        private string _productID;
        private string _title;
        private string _content;

        public string Id
        {
            get {return _id;}
            set { _id = value;}
        }

        public string ProductID
        {
            get
            {
                return _productID;
            }

            set
            {
                _productID = value;
            }
        }

        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                _title = value;
            }
        }

        public string Content
        {
            get
            {
                return _content;
            }

            set
            {
                _content = value;
            }
        }
    }
}
