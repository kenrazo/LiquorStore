using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LiquorStore.Business.Dtos;
using LiquorStore.Common.Helpers;
using LiquorStore.DAL.Entities.DatabaseEntities;
using LiquorStore.DAL.Entities.ParameterEntities;
using LiquorStore.DAL.Entities.ReadEntities;
using LiquorStore.DAL.UnitOfWork;

namespace LiquorStore.Business.LogicCollections
{
    /// <summary>
    /// The liquor business
    /// </summary>
    /// <seealso cref="LiquorStore.Business.LogicCollections.BaseBusiness{LiquorStore.Business.LogicCollections.LiquorBusiness}" />
    /// <seealso cref="LiquorStore.Business.LogicCollections.ILiquorBusiness" />
    public class LiquorBusiness : BaseBusiness<LiquorBusiness>, ILiquorBusiness
    {
        public LiquorBusiness(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper,
            IRequestInfo requestInfo, ILoggerAdapter<LiquorBusiness> logger)
            : base(unitOfWorkFactory, mapper, requestInfo, logger)
        {
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public async Task<PaginatedOutputDto<LiquorOutputDto>> GetPaginatedData(PaginatedInputDto input)
        {
            using (var unitOfWork = UnitOfWorkFactory.Create())
            {
                var parameter = Mapper.Map<PaginatedDataInput>(input);
                var data = await unitOfWork.Liquors.GetPaginatedData(parameter);
                return Mapper.Map<PaginatedOutputDto<LiquorOutputDto>>(data);
            }
        }

        /// <summary>
        /// Adds the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        public async Task Add(LiquorInputDto input)
        {
            using (var unitOfWork = UnitOfWorkFactory.Create())
            {
                var parameter = new Liquor()
                {
                    LiquorName = input.LiquorName,
                    LiquorTypeId = input.LiquorTypeId
                };
                await unitOfWork.Liquors.Add(parameter);
                await unitOfWork.CompleteAsync();
            }
        }
    }
}
