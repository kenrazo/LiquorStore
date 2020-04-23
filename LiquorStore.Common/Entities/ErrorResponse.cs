using System;
using System.Collections.Generic;
using System.Text;

namespace LiquorStore.Common.Entities
{
    public class ErrorResponse
    {
        public ErrorResponse()
        {
        }

        public ErrorResponse(string message, string referenceKey = null)
        {
            Message = message;
            ReferenceKey = referenceKey;
        }

        public string Message { get; set; }
        public string ReferenceKey { get; set; }
        public IDictionary<string, string[]> Errors { get; set; }
    }
}
