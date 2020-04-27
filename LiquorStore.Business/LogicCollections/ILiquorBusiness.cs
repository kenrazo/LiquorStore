using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LiquorStore.Business.Dtos;

namespace LiquorStore.Business.LogicCollections
{
    /// <summary>
    /// Liquor business
    /// </summary>
    public interface ILiquorBusiness
    {
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<LiquorOutputDto>> Get();
    }
}
