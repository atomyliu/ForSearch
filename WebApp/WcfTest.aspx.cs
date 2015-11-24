using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.MemberServ;
using WebApp.VSmsClassServ;

namespace WebApp
{
    public partial class WcfTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            MemberServClient msc = new MemberServClient();
            string type = ddlist.SelectedValue.ToString();
            string kw = tb1.Text.ToString();
            int start = 0;
            int size = 10;
            int count = msc.GetCount(kw, type);
            lbCount.Text = count.ToString();
            List<Model.Member> list = new List<Model.Member>();
            list = msc.GetList(kw, type, start, size);
            //Model.Member[]mem = msc.GetList(kw,type,start,size);
            RpMem.DataSource = list;
            RpMem.DataBind();
            msc.Close();
        }
    }
}