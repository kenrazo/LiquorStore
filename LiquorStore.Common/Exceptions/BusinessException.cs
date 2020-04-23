using System;
using System.Collections.Generic;
using System.Text;
using LiquorStore.Common.Entities;

namespace LiquorStore.Common.Exceptions
{
    public class BusinessException : BaseException
    {
        public BusinessException(ErrorResponse errorResponse) : base(errorResponse)
        {
        }
    }
}
