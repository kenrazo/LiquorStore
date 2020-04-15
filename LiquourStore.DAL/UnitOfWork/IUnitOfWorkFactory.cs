using System;
using System.Collections.Generic;
using System.Text;

namespace LiquorStore.DAL.UnitOfWork
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
