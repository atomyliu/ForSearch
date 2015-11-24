using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;


namespace common
{
    public class Log 
    {
        public Log() { }
        HttpSessionState Session = HttpContext.Current.Session;
        public void InsertUserTrack(int operation)
        {
            SqlParameter[] para = new SqlParameter[] { };
            string kw = Session["kword"] as string;
            UserTrack userinfo = (UserTrack)Session["userInfo"];
            string sql = string.Format("INSERT INTO News_UserTracks(UserName ,IPAdress,LoginTime,Keyword ,Operation) VALUES ('{0}', '{1}', '{2}', '{3}',{4})",userinfo.Username.ToString(),userinfo.Ip.ToString(),DateTime.Now.ToString("G"), kw, operation);
            int i = DBHelper.UpDeInstu(sql, para, System.Data.CommandType.Text);
            DBHelper.close();
        }
    }
}
