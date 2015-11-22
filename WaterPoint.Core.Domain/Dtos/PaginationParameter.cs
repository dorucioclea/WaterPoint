﻿namespace WaterPoint.Core.Domain.Dtos
{
    public class PaginationParamter : IUriQueryParamter
    {
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
        public string Sort { get; set; }
        public bool? IsDesc { get; set; }
    }
}