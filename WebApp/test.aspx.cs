using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Model;
using DAL.Implement;
using DAL.Interface;
using Service.Interface;
using Service.Implement;
using System.IO;
using System.Runtime.Serialization.Json;
using WebApp.MemberServ;

namespace WebApp
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetAll();
        }
        public void GetAll()
        {
            MemberServClient msc = new MemberServClient();
            int count = msc.GetCount("鸡蛋","Products");
            int c = msc.GetList("鸡蛋", "Products", 0, 100000).Count();
            Response.Write(c);
        }
        
    }
}