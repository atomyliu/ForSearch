using common;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.admin
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bindData();
        }
        private void bindData()
        {
            string sql = "select TOP(30) ID,UserName,IPAdress,LoginTime,Keyword,Operation from News_UserTracks order by LoginTime DESC";
            SqlParameter[] para = new SqlParameter[] { };
            SqlDataReader dr = DBHelper.Select(sql, para, System.Data.CommandType.Text);
            rpTrack.DataSource = dr;
            rpTrack.DataBind();
        }
        public string oper(int str)
        {
            string opstr = "登录";
            if (str == 1)
            {
                opstr = "搜索";
            }
            return opstr;
        }
    }
}