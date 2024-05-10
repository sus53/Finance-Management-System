using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.helpers
{
    public class QueryObject
    {
        public string? Symbol { get; set; } = null;
        public string? CompanyName { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public Boolean IsDecending { get; set; } = false;
        public int PageSize { get; set; } = 5;
        public int PageNumber { get; set; } = 1;
    }
}