using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApiClient
{
    public partial class TXL : System.Web.UI.Page
    {
        public class Employee
        {
            private string _purview;
            private string _jobname;
            private string _purviewid;
            private string _spellch;
            private string _orderid;
            private string _deptid;
            private string _jobtitle;
            private string _jobnameid;
            private string _status;
            private string _privatephone;
            private string _dutymemo;
            private string _empnumber;
            private string _eid;
            private string _penname;
            private string _mobilphone;
            private string _companyid;
            private string _sex;
            private string _entertime;
            private string _realname;
            private string _emailaddress;
            private string _isusing;
            private string _jobtitleid;
            private string _departmentstr;
            private string _memo;
            private string _lft;

            public string Purview
            {
                get
                {
                    return _purview;
                }

                set
                {
                    _purview = value;
                }
            }

            public string Jobname
            {
                get
                {
                    return _jobname;
                }

                set
                {
                    _jobname = value;
                }
            }

            public string Purviewid
            {
                get
                {
                    return _purviewid;
                }

                set
                {
                    _purviewid = value;
                }
            }

            public string Spellch
            {
                get
                {
                    return _spellch;
                }

                set
                {
                    _spellch = value;
                }
            }

            public string Orderid
            {
                get
                {
                    return _orderid;
                }

                set
                {
                    _orderid = value;
                }
            }

            public string Deptid
            {
                get
                {
                    return _deptid;
                }

                set
                {
                    _deptid = value;
                }
            }

            public string Jobtitle
            {
                get
                {
                    return _jobtitle;
                }

                set
                {
                    _jobtitle = value;
                }
            }

            public string Jobnameid
            {
                get
                {
                    return _jobnameid;
                }

                set
                {
                    _jobnameid = value;
                }
            }

            public string Status
            {
                get
                {
                    return _status;
                }

                set
                {
                    _status = value;
                }
            }

            public string Privatephone
            {
                get
                {
                    return _privatephone;
                }

                set
                {
                    _privatephone = value;
                }
            }

            public string Dutymemo
            {
                get
                {
                    return _dutymemo;
                }

                set
                {
                    _dutymemo = value;
                }
            }

            public string Empnumber
            {
                get
                {
                    return _empnumber;
                }

                set
                {
                    _empnumber = value;
                }
            }

            public string Eid
            {
                get
                {
                    return _eid;
                }

                set
                {
                    _eid = value;
                }
            }

            public string Penname
            {
                get
                {
                    return _penname;
                }

                set
                {
                    _penname = value;
                }
            }

            public string Mobilphone
            {
                get
                {
                    return _mobilphone;
                }

                set
                {
                    _mobilphone = value;
                }
            }

            public string Companyid
            {
                get
                {
                    return _companyid;
                }

                set
                {
                    _companyid = value;
                }
            }

            public string Sex
            {
                get
                {
                    return _sex;
                }

                set
                {
                    _sex = value;
                }
            }

            public string Entertime
            {
                get
                {
                    return _entertime;
                }

                set
                {
                    _entertime = value;
                }
            }

            public string Realname
            {
                get
                {
                    return _realname;
                }

                set
                {
                    _realname = value;
                }
            }

            public string Emailaddress
            {
                get
                {
                    return _emailaddress;
                }

                set
                {
                    _emailaddress = value;
                }
            }

            public string Isusing
            {
                get
                {
                    return _isusing;
                }

                set
                {
                    _isusing = value;
                }
            }

            public string Jobtitleid
            {
                get
                {
                    return _jobtitleid;
                }

                set
                {
                    _jobtitleid = value;
                }
            }

            public string Departmentstr
            {
                get
                {
                    return _departmentstr;
                }

                set
                {
                    _departmentstr = value;
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

            public string Lft
            {
                get
                {
                    return _lft;
                }

                set
                {
                    _lft = value;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnurl_Click(object sender, EventArgs e)
        {
            string url = string.Format("http://eswebapi.test.sci99.com/api/txl/get/?keyword={0}&size=15",tburl.Text.ToString());
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse webreponse = (HttpWebResponse)webrequest.GetResponse();
            Stream stream = webreponse.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            string str = "[]";
            try
            {
                str = reader.ReadToEnd();
            }
            catch (Exception exp)
            {
                str = exp.ToString();
            }
            List<Employee> list = JsonDeserialize<Employee>(str.Replace("\"", "").Replace("'", "\"").Replace("\r", string.Empty).Replace("\n", string.Empty));
            rplist.DataSource = list;
            rplist.DataBind();
        }

        public static List<Employee> JsonDeserialize<Employee>(string jsonString)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Employee>));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            List<Employee> obj = (List<Employee>)ser.ReadObject(ms);
            return obj;
        }

        protected void btncurl_Click(object sender, EventArgs e)
        {
            string url = tbcurl.Text.ToString();
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse webreponse = (HttpWebResponse)webrequest.GetResponse();
            Stream stream = webreponse.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            string str = "[]";
            try
            {
                str = reader.ReadToEnd();
            }
            catch (Exception exp)
            {
                str = exp.ToString();
            }
            List<Employee> list = JsonDeserialize<Employee>(str.Replace("\"", "").Replace("'", "\"").Replace("\r", string.Empty).Replace("\n", string.Empty));
            rplist.DataSource = list;
            rplist.DataBind();
        }
    }
}