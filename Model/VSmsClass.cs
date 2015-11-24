using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class VSmsClass
    {
        private string _id;
        private string _title;
        private string _sendFreq;
        private string _searchstr;

        public string Id
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

        public string SendFreq
        {
            get
            {
                return _sendFreq;
            }

            set
            {
                _sendFreq = value;
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
