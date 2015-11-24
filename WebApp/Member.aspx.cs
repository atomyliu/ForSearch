using common;
using Service.Implement;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class Member : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Session["kword"] as string))
                {
                    tb1.Text = Session["kword"] as string;
                }
                try
                {
                    page_index = Convert.ToInt32(Request.QueryString["page"]);
                    if (page_index == 0)
                    {
                        page_index = 1;
                    }
                    else
                    {
                        tb1.Text = Session["kword"] as string;
                        ddlist.SelectedValue = Session["ddlstate"] as string;
                    }
                }
                catch (Exception)
                {
                    page_index = 1;
                }
                if (string.IsNullOrEmpty(tb1.Text.ToString()))
                { nullDate(); }
                else {
                    //排序点击实现
                    searchType = ddlist.SelectedValue.ToString();
                    kw = tb1.Text.ToString();
                    if (!string.IsNullOrEmpty(kw))
                    {
                        switch (searchType)
                        {
                            case "_all":
                                type = "";
                                break;
                            case "_ep":
                                type = "Enterprise";
                                break;
                            case "_pd":
                                type = "Products";
                                break;
                            case "_memo":
                                type = "Memo";
                                break;
                            case "_wn":
                                type = "WebName";
                                break;
                        }
                        if (string.IsNullOrEmpty(type))
                        {
                            count = (int)Session["escount"];
                            bindData();
                        }
                        else
                        {
                            count = (int)Session["escount"];
                            bindData(type);
                        }
                    }

                }
            }
        }
        private IMemberService ims = new MemberService();
        string searchType = "_all";
        string type = "";
        string kw = "";
        public int page_index = 1;
        public int count = 0;
        protected void btnSearch_Click(object sender, EventArgs e)
        {
           
            searchType = ddlist.SelectedValue.ToString();
            kw = tb1.Text.ToString();
            if (!string.IsNullOrEmpty(kw))
            {
                switch (searchType)
                {
                    case "_all":
                        type = "";
                        break;
                    case "_ep":
                        type = "Enterprise";
                        break;
                    case "_pd":
                        type = "Products";
                        break;
                    case "_memo":
                        type = "Memo";
                        break;
                    case "_wn":
                        type = "WebName";
                        break;
                }
                Session["ddlstate"] = searchType;
                if (string.IsNullOrEmpty(type))
                {
                    count = ims.GetCount(kw);
                    Session["escount"] = count;
                    Session["kword"] = kw;
                    bindData();
                }
                else
                {
                    count = ims.GetCount(kw,type);
                    Session["escount"] = count;
                    Session["kword"] = kw;
                    bindData(type);
                }
            }
            else {
                nullDate();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void bindData()
        {
            int myPageSize = 10;
            DoCookie.doCook("myPageSize", myPageSize.ToString());
            kw = tb1.Text.ToString();
            int start = (page_index - 1) * myPageSize;
            if (Session["escount"] != null)
            {
                count = (int)Session["escount"];
            }
            if (count >= 760)
            {
                memPager.Page_Count = "760";
            }
            else
            {
                memPager.Page_Count = count.ToString();
            }
            lbCount.Text = ThousandPoints.tPoints(count);
            memPager.Text_Type = "CN";
            memPager.Get_URL();
            List<Model.Member> list = ims.GetList(kw, start, myPageSize);
            RpMem.DataSource = list;
            RpMem.DataBind();
        }
        private void bindData(string type)
        {
            int myPageSize = 10;
            DoCookie.doCook("myPageSize", myPageSize.ToString());
            kw = tb1.Text.ToString();
            int start = (page_index - 1) * myPageSize;
            if (Session["escount"] != null)
            {
                count = (int)Session["escount"];
            }
            if (count >= 760)
            {
                memPager.Page_Count = "760";
            }
            else
            {
                memPager.Page_Count = count.ToString();
            }
            lbCount.Text = ThousandPoints.tPoints(count);
            memPager.Text_Type = "CN";
            memPager.Get_URL();
            List<Model.Member> list = ims.GetList(kw, type, start, myPageSize);
            RpMem.DataSource = list;
            RpMem.DataBind();
        }
        private void nullDate()
        {
            List<Model.Member> list = null;
            RpMem.DataSource = list;
            RpMem.DataBind();
        }
    }
}