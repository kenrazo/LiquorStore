using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiquorStore.Business.Dtos
{
    public class PaginatedOutputDto<T>
    {
        public PaginatedOutputDto()
        {
            Information = new PaginatedInformationOutputDto();
        }

        public PaginatedInformationOutputDto Information { get; set; }
        public IEnumerable<T> Value { get; set; }
    }
}
