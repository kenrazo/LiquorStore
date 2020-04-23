using System;
using System.Collections.Generic;
using System.Text;
using LiquorStore.Common.Entities;

namespace LiquorStore.Common.Exceptions
{
    public class UnauthorizedException : BaseException
    {
        public UnauthorizedException(ErrorResponse errorResponse) : base(errorResponse)
        {
        }
    }
}
