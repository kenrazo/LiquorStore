using System;
using System.Collections.Generic;

namespace LiquorStore.DAL.Entities.ReadEntities
{
    public class PaginatedOutput<T>
    {
        public PaginatedOutput(List<T> items, int count, int pageNumber, int pageSize)
        {
            Information = new PaginatedInformationOutput()
            {
                TotalCount = count,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize)

            };
            Value = items;
        }
        public PaginatedInformationOutput Information { get; set; }
        public IEnumerable<T> Value { get; set; }
    }

}