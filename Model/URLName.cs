using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class URLName
    {
        private string _urlid;

        public string Urlid
        {
            get { return _urlid; }
            set { _urlid = value; }
        }
        private string _namepath;

        public string Namepath
        {
            get { return _namepath; }
            set { _namepath = value; }
        }
        private string _urlname;

        public string Urlname
        {
            get { return _urlname; }
            set { _urlname = value; }
        }
        private string _NewsURL;

        public string NewsURL
        {
            get { return _NewsURL; }
            set { _NewsURL = value; }
        }
    }
}
