using System;
using System.Collections.Generic;
using System.Text;
using LiquorStore.Common.Entities;

namespace LiquorStore.Common.Exceptions
{
    public class BaseException : Exception
    {
        public ErrorResponse ErrorResponse { get; }
        public BaseException(ErrorResponse errorResponse)
        {
            ErrorResponse = errorResponse;
        }
    }
}
