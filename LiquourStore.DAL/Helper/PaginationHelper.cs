using System.Linq;
using System.Threading.Tasks;
using LiquorStore.DAL.Entities.ParameterEntities;
using LiquorStore.DAL.Entities.ReadEntities;
using Microsoft.EntityFrameworkCore;

namespace LiquorStore.DAL.Helper
{
    public partial class PaginationHelper<T>
    {
        public static async Task <PaginatedOutput<T>> ToPagedList(IQueryable<T> source, PaginatedDataInput input)
        {
            var count = source.Count();
            var items = await source
                .Skip((input.PageNumber - 1) * input.PageSize)
                .Take(input.PageSize)
                .ToListAsync();

            return new PaginatedOutput<T>(items, count, input.PageNumber, input.PageSize);
        }
    }
}
