using System;
using System.Collections.Generic;

namespace hospitals.Utilities
{
    public class PagedResult<T> where T : class
    {
        public PagedResult()
        {
            Data = new List<T>();
        }

        public List<T> Data { get; set; }
        public int TotalItems { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
