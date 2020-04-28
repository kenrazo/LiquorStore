using System;
using System.Collections.Generic;
using System.Text;

namespace LiquorStore.Business.Dtos
{
    public class PaginatedInputDto
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; }
        public string SearchKeyWord { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }
	}
}
