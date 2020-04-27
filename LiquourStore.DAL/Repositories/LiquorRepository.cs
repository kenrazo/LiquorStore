using System;
using System.Collections.Generic;
using System.Text;
using LiquorStore.DAL.Entities;
using LiquourStore.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LiquorStore.DAL.Repositories
{
    public class LiquorRepository : RepositoryBase<Liquor, int>, ILiquorRepository
    {
        public LiquorRepository(DbContext context) : base(context)
        {
        }
    }
}
