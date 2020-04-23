using System;
using System.Collections.Generic;
using System.Text;
using LiquorStore.Common.Entities;

namespace LiquorStore.Common.Exceptions
{
    public class ValidationException : BaseException
    {
        public ValidationException(ErrorResponse errorResponse) : base(errorResponse)
        {
        }
    }
}
