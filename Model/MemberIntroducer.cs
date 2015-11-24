using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MemberIntroducer
    {
        private int _memberid;
        private string _introducermobile;
        private string _introducer;
        private int _introducermemberid;

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

        public string Introducermobile
        {
            get
            {
                return _introducermobile;
            }

            set
            {
                _introducermobile = value;
            }
        }

        public string Introducer
        {
            get
            {
                return _introducer;
            }

            set
            {
                _introducer = value;
            }
        }

        public int Introducermemberid
        {
            get
            {
                return _introducermemberid;
            }

            set
            {
                _introducermemberid = value;
            }
        }
    }
}
