using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class KeyWords
    {
        private string _tagId;

        public string TagId
        {
            get { return _tagId; }
            set { _tagId = value; }
        }
        private string _kwname;

        public string Kwname
        {
            get { return _kwname; }
            set { _kwname = value; }
        }

    }
}
