using System;
using System.Collections.Generic;
using System.Text;
using LiquourStore.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace LiquourStore.DAL.Context
{
    public class LiquorStoreContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public LiquorStoreContext(DbContextOptions<LiquorStoreContext> options) :
            base(options)
        {
            Database.EnsureCreated();
        }
    }
}
