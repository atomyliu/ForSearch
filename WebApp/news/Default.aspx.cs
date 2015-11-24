using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nest;
using System.Configuration;
using System.Text.RegularExpressions;
using Model;
using common;
using Service.Interface;
using Service.Implement;


namespace WebApp.news
{
    public partial class Default : System.Web.UI.Page
    {
        
         
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    page_index = Convert.ToInt32(Request.QueryString["page"]);
                    if (page_index == 0)
                    {
                        page_index = 1;
                    }
                    else
                    {
                        tbSearch.Text = Session["kword"] as string;
                    }
                }
                catch (Exception)
                {
                    page_index = 1;
                }
                if (string.IsNullOrEmpty(tbSearch.Text.ToString()))
                { nullDate(); }
                else
                {
                    string rbstate = Session["rbstate"] as string;
                    if (rbstate == "rb1")
                    {
                        rb1.Checked = true;
                        bindData();
                    }
                    else if (rbstate == "rb2")
                    {
                        rb2.Checked = true;
                        //bindMData();
                    }
                    
                }
            }
        }
        private INewsBaseService inbs = new NewsBaseService();

        public int page_index = 1;
        public int count = 0;
        /// <summary>
        /// 获取content中80个字符的内容
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string substr(string str)
        {
            return RemoveHtml.substr(str);
        }
        /// <summary>
        /// 格式化时间
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string subtime(object str)
        {
            string newstr = "";
            if (str != null)
            {
                newstr = str.ToString();
                if (newstr.ToString().Length > 10)
                {
                    newstr = newstr.ToString().Substring(0, 10);
                }
            }
            return newstr;
        }
        /// Search按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string sstr = tbSearch.Text.ToString();
            if (rb1.Checked == true)
            {
                if (string.IsNullOrEmpty(sstr))
                {
                    nullDate();
                    lbCount.Text = "请在搜索框输入关键字";
                }
                else
                {
                    count = inbs.GetCount(sstr);
                    Session["rbstate"] = "rb1";
                    Session["escount"] = count;
                    Session["kword"] = sstr;
                    bindData();  

                }
            }
            else if (rb2.Checked == true)
            {
                if (string.IsNullOrEmpty(sstr))
                {
                    nullDate();
                    lbCount.Text = "请在搜索框输入关键字";
                }
                else
                {
                    
                }
            }

            Page.ClientScript.RegisterStartupScript(Page.GetType(), "myscript", "<script>hei()</script>");
        }
        /// <summary>
        /// 清空list
        /// </summary>
        private void nullDate()
        {
            List<NewsBase> list = new List<NewsBase>();
            RpNews.DataSource = list;
            RpNews.DataBind();

        }
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void bindData()
        {
            //每页显示像素
            int myPageSize = 10;
            DoCookie.doCook("myPageSize", myPageSize.ToString());
            string keyword = tbSearch.Text.ToString();
            int start = (page_index - 1) * myPageSize;
            if (Session["escount"] != null)
            {
                count = (int)Session["escount"];
            }
            if (count >= 760)
            {
                pager.Page_Count = "760";
            }
            else
            {
                pager.Page_Count = count.ToString();
            }
            lbCount.Text = ThousandPoints.tPoints(count);
            pager.Text_Type = "CN";
            pager.Get_URL();
            
            //INewsBaseService inbs = new NewsBaseService();
            List<NewsBase> list = inbs.GetList(keyword, start, myPageSize);
            RpNews.DataSource = list;
            RpNews.DataBind();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "myscript", "<script>shownews()</script>");
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "myscript", "<script>hei()</script>");
        }
   

        /// <summary>
        /// 创建索引
        /// </summary>
        public void CreateIndex()
        {
            string espath = ConfigurationManager.AppSettings["ESPath"].ToString();
            string indexname = ConfigurationManager.AppSettings["IndexName"].ToString();
            string typename = ConfigurationManager.AppSettings["TypeName"].ToString();
            var node = new Uri(espath);
            var settings = new ConnectionSettings(node);
            var client = new ElasticClient(settings);
            var newbase = new NewsBase();
            client.CreateIndex(indexname);
            client.Map<NewsBase>(m => m.MapFromAttributes());
        }
        /// <summary>
        /// 删除索引
        /// </summary>
        public void DeleteIndex()
        {
            string espath = ConfigurationManager.AppSettings["ESPath"].ToString();
            string indexname = ConfigurationManager.AppSettings["IndexName"].ToString();
            string typename = ConfigurationManager.AppSettings["TypeName"].ToString();
            var node = new Uri(espath);
            var settings = new ConnectionSettings(node);
            var client = new ElasticClient(settings);
            client.DeleteIndex(new DeleteIndexRequest(new IndexNameMarker() { Name = indexname }));
        }
        /// <summary>
        /// 创建索引按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                CreateIndex();

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteIndex();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}