﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Pagings
{
    public class PagedResult<T>:PagedResultBase
    {
        public List<T> Items { get; set; }
    }
}
