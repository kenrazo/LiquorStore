using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LiquourStore.DAL.Repositories
{
    /// <summary>
    /// The Repository base.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TPrimaryKey">The type of the primary key.</typeparam>
    /// <seealso cref="LiquourStore.DAL.Repositories.IRepositoryBase{TEntity, TPrimaryKey}" />
    public class RepositoryBase<TEntity, TPrimaryKey> : IRepositoryBase<TEntity, TPrimaryKey> where TEntity : class
    {
        protected readonly DbContext Context;

        public RepositoryBase(DbContext context)
        {
            Context = context;
        }
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<TEntity> Get(int id)
        {
           return await Context.Set<TEntity>().FindAsync(id);
        }
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }
        /// <summary>
        /// Finds the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().Where(predicate).ToListAsync();
        }
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public async Task Add(TEntity entity)
        {
             await Context.Set<TEntity>().AddAsync(entity);
        }
        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public async Task AddRange(IEnumerable<TEntity> entities)
        {
            await Context.Set<TEntity>().AddRangeAsync(entities);
        }
        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Remove(TEntity entity)
        {
             Context.Set<TEntity>().Remove(entity);
        }
        /// <summary>
        /// Removes the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }
    }
}
