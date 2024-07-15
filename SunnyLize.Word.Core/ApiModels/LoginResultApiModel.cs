using System;
using System.Collections.Generic;
using System.Text;

namespace SunnyLize.Word.Core
{
    /// <summary>
    /// The result of a successful api request via api
    /// </summary>
    public class LoginResultApiModel
    {
        /// <summary>
        /// The authentication token used to stay authenticated through future request
        /// </summary>
        public string Token { set; get; }

        /// <summary>
        /// the user first name
        /// </summary>
        public string FirstName { set; get; }

        /// <summary>
        /// the user last name
        /// </summary>
        public string LastName { set; get; }

        /// <summary>
        /// the user username
        /// </summary>
        public string Username { set; get; }

        /// <summary>
        /// the user username
        /// </summary>
        public string Email { set; get; }
    }
}

