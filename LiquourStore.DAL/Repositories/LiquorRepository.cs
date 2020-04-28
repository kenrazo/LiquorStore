using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiquorStore.DAL.Entities;
using LiquorStore.DAL.Entities.DatabaseEntities;
using LiquorStore.DAL.Entities.ParameterEntities;
using LiquorStore.DAL.Entities.ReadEntities;
using LiquorStore.DAL.Helper;
using LiquourStore.DAL.Context;
using LiquourStore.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LiquorStore.DAL.Repositories
{
    public class LiquorRepository : RepositoryBase<Liquor, int>, ILiquorRepository
    {
        public LiquorRepository(LiquorStoreContext context) : base(context)
        {
        }

        public async Task<PaginatedOutput<LiquorOutput>> GetPaginatedData(PaginatedDataInput input)
        {
            return await PaginationHelper<LiquorOutput>
                .ToPagedList( LiquorStoreContext.Liquors.Select(m=> new LiquorOutput()
                {
                    LiquorType = m.LiquorType.LiquorTypeName,
                    LiquorId = m.LiquorId,
                    LiquorName = m.LiquorName
                }).OrderBy(m=> m.LiquorId), input);
        }

        public LiquorStoreContext LiquorStoreContext => Context as LiquorStoreContext;
    }
}
