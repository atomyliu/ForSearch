using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common
{
    public class ThousandPoints
    {
        /// <summary>
        /// 将数字添加千分符
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static string tPoints(int i)
        {
            System.Globalization.NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();
            nfi.NumberDecimalDigits = 0;
            string ii = i.ToString("N", nfi);
            return ii;
        }
    }
}
