using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace common
{
    public class RemoveHtml
    {
        /// <summary>
        /// 获取content中80个字符的内容,并去掉HTML标签
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string substr(string str)
        {
            string restr = Regex.Replace(str, "<.*?>", string.Empty); //去掉html标志
            string endstr = "...";
            if (string.IsNullOrEmpty(restr))
            {
                restr = restr + endstr;
            }
            if (restr.Length > 80)
            {
                string newstr = restr.Substring(0, 80) + endstr;
                restr = newstr;
            }
            return restr;
        }
    }
}
