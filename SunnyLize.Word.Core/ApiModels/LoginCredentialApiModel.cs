using System;
using System.Collections.Generic;
using System.Text;

namespace SunnyLize.Word.Core
{
    /// <summary>
    /// the credential for an Api log to the server and receive a token back
    /// </summary>
    public class LoginCredentialApiModel
    {
        #region public properties
        /// <summary>
        /// the users username or email
        /// </summary>
        public string UsernameOrEmail { set;  get; }

        /// <summary>
        /// the users password
        /// </summary>
        public string Password { set;  get; }

        #endregion

    }
}
