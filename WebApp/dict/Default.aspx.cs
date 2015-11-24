using common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.dict
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetDict();
        }
        public void GetDict()
        {
            
            string[] lines = File.ReadAllLines("E:\\ForSearch\\ForSearch_v1.0\\WebApp\\dict\\updict.dic");
            foreach (string line in lines)
            {
                Response.Write(line+"\n");
            }
        }

    }
}