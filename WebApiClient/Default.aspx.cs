using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApiClient
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tbtime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                tbmd5.Text = CreateSignature(Regex.Replace(tbk.Text.ToString(),",",string.Empty), tbflag.Text.ToString(), tbfield.Text.ToString(), Convert.ToDateTime(tbtime.Text.ToString()));
            }
        }
        public class Member
        {
            private string _id;
            private string _addtime;
            private string _enterprise;
            private string _country;
            private string _province;
            private string _city;
            private string _address;
            private string _zipcode;
            private string _homeurl;
            private string _webname;
            private string _enterpriseintro;
            private string _adminid;
            private string _enttypeid;
            private string _tracktypeid;
            private string _classid;
            private string _sourceid;
            private string _matdegreeid;
            private string _startdate;
            private string _enddate;
            private string _nextcontactdate;
            private string _lastcontacttime;
            private string _products;
            private string _class1;
            private string _class2;
            private string _class3;
            private string _class4;
            private string _class5;
            private string _class6;
            private string _class7;
            private string _class8;
            private string _class9;
            private string _class10;
            private string _ispub;
            private string _isdel;
            private string _meetingid;
            private string _allocatecontinuedate;
            private string _siteclass;
            private string _revisitadminid;
            private string _ontrack;
            private string _idformal;
            private string _aftersalesid;
            private string _adminname;
            private string _masterlinkman;
            private string _masterphone;
            private string _version;
            private string _memo;
            private string _zzadminid;
            private string _weightingsort;
            private string _meetinglastcontacttime;
            private string _zztrack;
            private string _trackreason;
            private string _isstar;
            private string _trackreasondate;
            private string _limitdays;
            private string _updatedaysadmin;
            private string _updatetracktype;
            private string _continueadminid;
            private string _istaxpayer;
            private string _iscta;
            public string id
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
            public string addtime
            {
                get
                {
                    return _addtime;
                }
                set
                {
                    _addtime = value;
                }
            }
            public string enterprise
            {
                get
                {
                    return _enterprise;
                }
                set
                {
                    _enterprise = value;
                }
            }
            public string country
            {
                get
                {
                    return _country;
                }
                set
                {
                    _country = value;
                }
            }
            public string province
            {
                get
                {
                    return _province;
                }
                set
                {
                    _province = value;
                }
            }
            public string city
            {
                get
                {
                    return _city;
                }
                set
                {
                    _city = value;
                }
            }
            public string address
            {
                get
                {
                    return _address;
                }
                set
                {
                    _address = value;
                }
            }
            public string zipcode
            {
                get
                {
                    return _zipcode;
                }
                set
                {
                    _zipcode = value;
                }
            }
            public string homeurl
            {
                get
                {
                    return _homeurl;
                }
                set
                {
                    _homeurl = value;
                }
            }
            public string webname
            {
                get
                {
                    return _webname;
                }
                set
                {
                    _webname = value;
                }
            }
            public string enterpriseintro
            {
                get
                {
                    return _enterpriseintro;
                }
                set
                {
                    _enterpriseintro = value;
                }
            }
            public string adminid
            {
                get
                {
                    return _adminid;
                }
                set
                {
                    _adminid = value;
                }
            }
            public string enttypeid
            {
                get
                {
                    return _enttypeid;
                }
                set
                {
                    _enttypeid = value;
                }
            }
            public string tracktypeid
            {
                get
                {
                    return _tracktypeid;
                }
                set
                {
                    _tracktypeid = value;
                }
            }
            public string classid
            {
                get
                {
                    return _classid;
                }
                set
                {
                    _classid = value;
                }
            }
            public string sourceid
            {
                get
                {
                    return _sourceid;
                }
                set
                {
                    _sourceid = value;
                }
            }
            public string matdegreeid
            {
                get
                {
                    return _matdegreeid;
                }
                set
                {
                    _matdegreeid = value;
                }
            }
            public string startdate
            {
                get
                {
                    return _startdate;
                }
                set
                {
                    _startdate = value;
                }
            }
            public string enddate
            {
                get
                {
                    return _enddate;
                }
                set
                {
                    _enddate = value;
                }
            }
            public string nextcontactdate
            {
                get
                {
                    return _nextcontactdate;
                }
                set
                {
                    _nextcontactdate = value;
                }
            }
            public string lastcontacttime
            {
                get
                {
                    return _lastcontacttime;
                }
                set
                {
                    _lastcontacttime = value;
                }
            }
            public string class1
            {
                get
                {
                    return _class1;
                }
                set
                {
                    _class1 = value;
                }
            }
            public string class2
            {
                get
                {
                    return _class2;
                }
                set
                {
                    _class2 = value;
                }
            }
            public string class3
            {
                get
                {
                    return _class3;
                }
                set
                {
                    _class3 = value;
                }
            }
            public string class4
            {
                get
                {
                    return _class4;
                }
                set
                {
                    _class4 = value;
                }
            }
            public string class5
            {
                get
                {
                    return _class5;
                }
                set
                {
                    _class5 = value;
                }
            }
            public string class6
            {
                get
                {
                    return _class6;
                }
                set
                {
                    _class6 = value;
                }
            }
            public string class7
            {
                get
                {
                    return _class7;
                }
                set
                {
                    _class7 = value;
                }
            }
            public string class8
            {
                get
                {
                    return _class8;
                }
                set
                {
                    _class8 = value;
                }
            }
            public string class9
            {
                get
                {
                    return _class9;
                }
                set
                {
                    _class9 = value;
                }
            }
            public string class10
            {
                get
                {
                    return _class10;
                }
                set
                {
                    _class10 = value;
                }
            }
            public string ispub
            {
                get
                {
                    return _ispub;
                }
                set
                {
                    _ispub = value;
                }
            }
            public string isdel
            {
                get
                {
                    return _isdel;
                }
                set
                {
                    _isdel = value;
                }
            }
            public string meetingid
            {
                get
                {
                    return _meetingid;
                }
                set
                {
                    _meetingid = value;
                }
            }
            public string allocatecontinuedate
            {
                get
                {
                    return _allocatecontinuedate;
                }
                set
                {
                    _allocatecontinuedate = value;
                }
            }
            public string siteclass
            {
                get
                {
                    return _siteclass;
                }
                set
                {
                    _siteclass = value;
                }
            }
            public string revisitadminid
            {
                get
                {
                    return _revisitadminid;
                }
                set
                {
                    _revisitadminid = value;
                }
            }
            public string ontrack
            {
                get
                {
                    return _ontrack;
                }
                set
                {
                    _ontrack = value;
                }
            }
            public string idformal
            {
                get
                {
                    return _idformal;
                }
                set
                {
                    _idformal = value;
                }
            }
            public string aftersalesid
            {
                get
                {
                    return _aftersalesid;
                }
                set
                {
                    _aftersalesid = value;
                }
            }
            public string adminname
            {
                get
                {
                    return _adminname;
                }
                set
                {
                    _adminname = value;
                }
            }
            public string masterlinkman
            {
                get
                {
                    return _masterlinkman;
                }
                set
                {
                    _masterlinkman = value;
                }
            }
            public string masterphone
            {
                get
                {
                    return _masterphone;
                }
                set
                {
                    _masterphone = value;
                }
            }
            public string version
            {
                get
                {
                    return _version;
                }
                set
                {
                    _version = value;
                }
            }
            public string memo
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
            public string zzadminid
            {
                get
                {
                    return _zzadminid;
                }
                set
                {
                    _zzadminid = value;
                }
            }
            public string weightingsort
            {
                get
                {
                    return _weightingsort;
                }
                set
                {
                    _weightingsort = value;
                }
            }
            public string meetinglastcontacttime
            {
                get
                {
                    return _meetinglastcontacttime;
                }
                set
                {
                    _meetinglastcontacttime = value;
                }
            }
            public string zztrack
            {
                get
                {
                    return _zztrack;
                }
                set
                {
                    _zztrack = value;
                }
            }
            public string trackreason
            {
                get
                {
                    return _trackreason;
                }
                set
                {
                    _trackreason = value;
                }
            }
            public string isstar
            {
                get
                {
                    return _isstar;
                }
                set
                {
                    _isstar = value;
                }
            }
            public string trackreasondate
            {
                get
                {
                    return _trackreasondate;
                }
                set
                {
                    _trackreasondate = value;
                }
            }
            public string limitdays
            {
                get
                {
                    return _limitdays;
                }
                set
                {
                    _limitdays = value;
                }
            }
            public string updatedaysadmin
            {
                get
                {
                    return _updatedaysadmin;
                }
                set
                {
                    _updatedaysadmin = value;
                }
            }
            public string updatetracktype
            {
                get
                {
                    return _updatetracktype;
                }
                set
                {
                    _updatetracktype = value;
                }
            }
            public string continueadminid
            {
                get
                {
                    return _continueadminid;
                }
                set
                {
                    _continueadminid = value;
                }
            }
            public string istaxpayer
            {
                get
                {
                    return _istaxpayer;
                }
                set
                {
                    _istaxpayer = value;
                }
            }
            public string iscta
            {
                get
                {
                    return _iscta;
                }
                set
                {
                    _iscta = value;
                }
            }
            public string products
            {
                get
                {
                    return _products;
                }
                set
                {
                    _products = value;
                }
            }
        }

        protected void btntime_Click(object sender, EventArgs e)
        {
            tbtime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        protected void btnmd5_Click(object sender, EventArgs e)
        {
            tbmd5.Text = CreateSignature(Regex.Replace(tbk.Text.ToString(), ",", string.Empty), tbflag.Text.ToString(), tbfield.Text.ToString(), Convert.ToDateTime(tbtime.Text.ToString()));
        }
        protected void btnurl_Click(object sender, EventArgs e)
        {
            string url = tburl.Text.ToString();
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
            List<Member> list = JsonDeserialize<Member>(str.Replace("\"", "").Replace("'", "\"").Replace("\r",string.Empty).Replace("\n",string.Empty));
            rplist.DataSource = list;
            rplist.DataBind();
            Label1.Text = str.Replace("\"", "").Replace("'", "\"");
        }

        protected void btnmake_Click(object sender, EventArgs e)
        {
            string urlp = string.Format("http://eswebapi.test.sci99.com/api/member/getme/?flag={0}&field={1}&keyword={2}&start=0&size=15&timestamp={3}&sign={4}", tbflag.Text.ToString(), tbfield.Text.ToString(), tbk.Text.ToString(), tbtime.Text.ToString(), tbmd5.Text.ToString()); ;
            tburl.Text = urlp;
        }

        private string CreateSignature(string keyword, string flag, string field, DateTime timestamp)
        {
            string sign = "";
            try
            {
                TimeSpan toNow = DateTime.Now.Subtract(timestamp);
                string nowTS = toNow.TotalSeconds.ToString();
                int ts = 0;
                if (toNow.TotalSeconds != 0)
                {
                    ts = int.Parse(nowTS.Substring(0, nowTS.IndexOf('.')));
                }
                if (Math.Abs(ts) < 120)
                {
                    sign = ("keyword=" + keyword + "&flag=" + flag + "&field=" + field + "&timestamp=" + timestamp.ToString("yyyy-MM-dd HH:mm:ss")).ToUpper();
                    sign = GetMD5HashFromStr(sign);
                }
            }
            catch (Exception)
            {
                sign = "";
            }
            return sign;
        }

        private static string GetMD5HashFromStr(string str)
        {
            try
            {
                if (!string.IsNullOrEmpty(str))
                {
                    MD5 md5Hash = MD5.Create();
                    byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(str));
                    StringBuilder sBuilder = new StringBuilder();
                    for (int i = 0; i < data.Length; i++)
                    {
                        sBuilder.Append(data[i].ToString("x2"));
                    }
                    return sBuilder.ToString().ToUpper();
                }
                else
                {
                    return str;
                }
            }
            catch (Exception)
            {
                return str;
            }
        }
        /// <summary>
        /// Json返序列化集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static List<Member> JsonDeserialize<Member>(string jsonString)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Member>));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            List<Member> obj = (List<Member>)ser.ReadObject(ms);
            return obj;
        }

    }
}