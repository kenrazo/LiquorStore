
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading;
using System.Threading.Tasks;
using LiquourStore.DAL.Context;
using LiquourStore.DAL.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace LiquourStore.DAL.Repositories
{
    /// <summary>
    /// User repository
    /// </summary>
    /// <seealso cref="int" />
    /// <seealso cref="LiquourStore.DAL.Repositories.IUserRepository" />
    public class UserRepository : RepositoryBase<User, int>, IUserRepository
    {
        public UserRepository(LiquorStoreContext context) : base(context)
        {
        }
        /// <summary>
        /// Authenticates the specified username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public async Task<User> Authenticate(string username, string password)
        {
            var param1 = new SqlParameter("@Username", username);
            var param2 = new SqlParameter("@Password", password);
            var users = await LiquorStoreContext.Users
                .FromSqlRaw("EXECUTE usp_LoginUser @Username, @Password", param1, param2).ToListAsync();
            return users.FirstOrDefault();
        }
        /// <summary>
        /// Gets the liquor store context.
        /// </summary>
        /// <value>
        /// The liquor store context.
        /// </value>
        public LiquorStoreContext LiquorStoreContext => Context as LiquorStoreContext;
    }
}
