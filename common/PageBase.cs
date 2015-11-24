using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common
{
    public class PageBase : System.Web.UI.Page
    {
        protected void Page_Unload(object sender, EventArgs e)
        {

        }
        protected override void OnInit(EventArgs e)
        {
            if (Session["userInfo"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            base.OnInit(e);
        }

    }
}
