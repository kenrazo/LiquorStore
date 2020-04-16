using System;
using System.Collections.Generic;
using System.Text;
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

        /// <summary>
        /// Initializes a new instance of the <see cref="LiquorStoreContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public LiquorStoreContext(DbContextOptions<LiquorStoreContext> options) :
            base(options)
        {
            //   Database.EnsureCreated();
        }
    }
}
