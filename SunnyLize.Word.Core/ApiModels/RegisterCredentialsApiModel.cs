using System;
using System.Collections.Generic;
using System.Text;

namespace SunnyLize.Word.Core
{
    /// <summary>
    /// the credential for an Api register to the server
    /// </summary>
    public class RegisterCredentialsApiModel
    {
        #region public properties
        /// <summary>
        /// the users username 
        /// </summary>
        public string Username { set;  get; }

        /// <summary>
        /// the users username 
        /// </summary>
        public string Email { set; get; }

        /// <summary>
        /// the user first name
        /// </summary>
        public string FirstName { set; get; }

        /// <summary>
        /// the user last name
        /// </summary>
        public string LastName { set; get; }

        /// <summary>
        /// the users password
        /// </summary>
        public string Password { set;  get; }

        #endregion

    }
}
