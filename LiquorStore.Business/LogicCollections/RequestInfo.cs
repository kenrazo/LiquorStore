using System;
using System.Collections.Generic;
using System.Text;
using LiquorStore.Business.Dtos.Auth;

namespace LiquorStore.Business.LogicCollections
{
    /// <summary>
    /// Request info
    /// </summary>
    /// <seealso cref="LiquorStore.Business.LogicCollections.IRequestInfo" />
    public class RequestInfo : IRequestInfo
    {
        /// <summary>
        /// Gets the current.
        /// </summary>
        /// <value>
        /// The current.
        /// </value>
        public RequestInformationOutputDto Current => CurrentRequestInfoPrivate;
        private RequestInformationOutputDto CurrentRequestInfoPrivate { get; set; }
        /// <summary>
        /// Sets the current.
        /// </summary>
        /// <param name="requestInfo">The request information.</param>
        public void SetCurrent(RequestInformationOutputDto requestInfo)
        {
            CurrentRequestInfoPrivate = requestInfo;
        }
    }
}
