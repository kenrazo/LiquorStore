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
        Task<PaginatedOutputDto<LiquorOutputDto>> GetPaginatedData(PaginatedInputDto input);

        /// <summary>
        /// Adds the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        Task Add(LiquorInputDto input);
    }
}
