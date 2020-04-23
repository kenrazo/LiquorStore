using System;
using System.Collections.Generic;
using System.Text;
using LiquorStore.Common.Entities;

namespace LiquorStore.Common.Exceptions
{
    public class ForbiddenException : BaseException
    {
        public ForbiddenException(ErrorResponse errorResponse) : base(errorResponse)
        {
        }
    }
}
