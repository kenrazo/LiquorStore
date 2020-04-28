using System;
using System.Collections.Generic;
using System.Text;

namespace LiquorStore.Business.Dtos
{
    public class PaginatedInformationOutputDto
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
    }
}
