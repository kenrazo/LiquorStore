using System;
using System.Collections.Generic;
using System.Text;

namespace LiquorStore.Business.Dtos
{
    /// <summary>
    /// Authentication input dto
    /// </summary>
    public class AuthenticationInputDto
    {
        /// <summary>
        /// The user name.
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// The password.
        /// </summary>
        public string Password { get; set; }
    }
}
