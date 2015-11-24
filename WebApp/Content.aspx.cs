using Nest;
using Service.Implement;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class Content : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["_id"];
            //Response.Write(Server.UrlDecode(id));
            List<Model.NewsBase> list = SearchList(id);

            dataRepeater.DataSource = list;
            dataRepeater.DataBind();
        }
        
        private INewsBaseService inbs = new NewsBaseService();
        public List<Model.NewsBase> SearchList(string nid)
        {
            List<Model.NewsBase> list = inbs.GetList(nid, "newsid", 0, 1);
            return list;
        }
    }
}