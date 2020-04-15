using System;
using System.Collections.Generic;
using System.Text;

namespace LiquorStore.DAL.UnitOfWork
{
    /// <summary>
    /// Unit of work factory.
    /// </summary>
    /// <seealso cref="LiquorStore.DAL.UnitOfWork.IUnitOfWorkFactory" />
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IUnitOfWork _unitOfWork;

        public UnitOfWorkFactory(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        public IUnitOfWork Create()
        {
            return _unitOfWork;
        }
    }
}
