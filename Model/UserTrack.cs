using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class UserTrack
    {
        private int _id;
        private string _username;
        private string _password;
        private string _ip;
        private string _loginTime;
        private string _keywordID;
        private int _operation;

        public UserTrack(string _username, string _password, string _ip, string _keywordID,int _operation)
        {
            this._username = _username;
            this._password = _password;
            this._ip = _ip;
            this._keywordID = _keywordID;
            this._operation = _operation;
        }

        public string Username
        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }

        public string Ip
        {
            get
            {
                return _ip;
            }

            set
            {
                _ip = value;
            }
        }

        public string KeywordID
        {
            get
            {
                return _keywordID;
            }

            set
            {
                _keywordID = value;
            }
        }

        public int Operation
        {
            get
            {
                return _operation;
            }

            set
            {
                _operation = value;
            }
        }

        public string LoginTime
        {
            get
            {
                return _loginTime;
            }

            set
            {
                _loginTime = value;
            }
        }

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
    }
}
