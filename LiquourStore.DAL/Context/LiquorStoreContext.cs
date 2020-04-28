using System;
using System.Collections.Generic;
using System.Text;
using LiquorStore.DAL.Entities;
using LiquourStore.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace LiquourStore.DAL.Context
{
    /// <summary>
    /// The liquor store database context
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class LiquorStoreContext : DbContext
    {
        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        public DbSet<User> Users { get; set; }
        public DbSet<Liquor> Liquors { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LiquorStoreContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public LiquorStoreContext(DbContextOptions<LiquorStoreContext> options) :
            base(options)
        {
            //   Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
