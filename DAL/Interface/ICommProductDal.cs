﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public partial interface ICommProductDal
    {
        string Get(Implement.CommProductDal.SearchCondition sc);
    }
}
