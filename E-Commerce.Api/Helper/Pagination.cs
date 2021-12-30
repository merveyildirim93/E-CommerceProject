﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Api.Helper
{
    public class Pagination<T> where T :class
    {
        public Pagination(int PageIndex, int PageSize, int Count, IReadOnlyList<T> Data)
        {
            this.Count = Count;
            this.Data = Data;
            this.PageIndex = PageIndex;
            this.PageSize = PageSize;
        }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public IReadOnlyList<T> Data { get; set; }
    }
}
