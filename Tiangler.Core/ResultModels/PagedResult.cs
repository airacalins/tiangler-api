﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiangler.Core.ResultModels
{
    public class PagedResult<T> where T : class
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public long RowCount { get; set; }

        public IList<T> Data { get; set; }

        public PagedResult()
        {
            Data = new List<T>();
        }
    }
}
