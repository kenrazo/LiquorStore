using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LiquorStore.Business.Dtos;
using LiquorStore.Common.Helpers;
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
        public async Task<IEnumerable<LiquorOutputDto>> Get()
        {
            var result = new List<LiquorOutputDto>();
            using (var unitOfWork = UnitOfWorkFactory.Create())
            {
                var data = await unitOfWork.Liquors.GetAll();
                return Mapper.Map<IEnumerable<LiquorOutputDto>>(data);
            }
        }
    }
}
