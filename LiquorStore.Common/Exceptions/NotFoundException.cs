using System;
using System.Collections.Generic;
using System.Text;
using LiquorStore.Common.Entities;

namespace LiquorStore.Common.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(ErrorResponse errorResponse) : base(errorResponse)
        {
        }
    }
}
