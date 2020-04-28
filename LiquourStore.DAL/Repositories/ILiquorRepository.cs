using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LiquorStore.DAL.Entities;
using LiquorStore.DAL.Entities.ParameterEntities;
using LiquorStore.DAL.Entities.ReadEntities;
using LiquourStore.DAL.Repositories;

namespace LiquorStore.DAL.Repositories
{
    public interface ILiquorRepository : IRepositoryBase<Liquor, int>
    {
        Task<PaginatedOutput<Liquor>> GetPaginatedData(PaginatedDataInput input);
    }
}
