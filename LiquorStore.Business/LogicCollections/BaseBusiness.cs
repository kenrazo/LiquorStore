using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using LiquorStore.Common.Helpers;
using LiquorStore.DAL.UnitOfWork;

namespace LiquorStore.Business.LogicCollections
{
    public abstract class BaseBusiness<T>
    {
        protected BaseBusiness(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper, IRequestInfo requestInfo, ILoggerAdapter<T> logger)
        {
            UnitOfWorkFactory = unitOfWorkFactory;
            Mapper = mapper;
            RequestInfo = requestInfo;
            Logger = logger;
        }

        protected IUnitOfWorkFactory UnitOfWorkFactory { get; }
        protected IMapper Mapper { get; }
        protected IRequestInfo RequestInfo { get; }
        protected ILoggerAdapter<T> Logger { get; } 
    }
}
