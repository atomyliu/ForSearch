using common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            string ip = common.GetIP.getIPAddress();
            if (isRightUser(tbuser.Text.ToString(), tbpwd.Text.ToString()))
            {
                UserTrack userinfo = new UserTrack(tbuser.Text.ToString(), tbpwd.Text.ToString(), ip.ToString(), "", 0);
                Context.Session["userInfo"] = userinfo;
                Log log = new Log();
                log.InsertUserTrack(0);
                Response.Write("<script>alert('登陆成功! IP:" + userinfo.Ip.ToString() + "');window.location='Default.aspx'</script>");
            }
            else if (isAdmin(tbuser.Text.ToString(), tbpwd.Text.ToString()))
            {
                UserTrack userinfo = new UserTrack(tbuser.Text.ToString(), tbpwd.Text.ToString(), ip.ToString(), "", 0);
                Context.Session["userInfo"] = userinfo;
                Log log = new Log();
                log.InsertUserTrack(0);
                Response.Write("<script>alert('欢迎管理员!');window.location='/admin/Default.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('登陆失败，请重新登陆');window.location='/Login.aspx'</script>");
            }
            Response.End();
        }
        private bool isRightUser(string username, string pwd)
        {
            bool rightUser = false;
            string u = "zbyxc2015";
            string p = "zczxaa147..";
            string u0 = "changbin";
            string p0 = "1234abcd..";
            if (username == u && pwd == p)
            {
                rightUser = true;
            }
           else if (username == u0 && pwd == p0)
            {
                rightUser = true;
            }
            return rightUser;
        }
        private bool isAdmin(string username, string pwd)
        {
            bool isadmin = false;
            string u = "admin";
            string p = "admin";
            if (username == u && pwd == p)
            {
                isadmin = true;
            }
            return isadmin;
        }
    }
}