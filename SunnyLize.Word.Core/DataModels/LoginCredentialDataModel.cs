using System;
using System.Collections.Generic;
using System.Text;

namespace SunnyLize.Word.Core
{
    /// <summary>
    /// data model for login credential of our client
    /// </summary>
    public class LoginCredentialDataModel
    {
        /// <summary>
        /// Unique id 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// User username
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// User firstName
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// User astName
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// User email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// User token
        /// </summary>
        public string Token { get; set; }

    }
}
