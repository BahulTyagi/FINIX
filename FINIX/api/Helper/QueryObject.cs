﻿namespace api.Helper
{
    public class QueryObject
    {
        public string? Symbol { get; set; }

        public string? CompanyName { get; set; }

        public string? SortBy { get; set; }

        public bool IsDescending { get; set; }
    }
}
