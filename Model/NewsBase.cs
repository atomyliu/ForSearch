using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class NewsBase
    {
        private string _newsid;

        public string Newsid
        {
            get { return _newsid; }
            set { _newsid = value; }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        private string _content;

        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
        private DateTime _pubDate;

        public DateTime PubDate
        {
            get { return _pubDate; }
            set { _pubDate = value; }
        }
        private string _createon;

        public string Createon
        {
            get { return _createon; }
            set { _createon = value; }
        }


    }
}
